using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using BusinessAccessLayer;

namespace WFQLDatXeTrucTuyen
{
    public partial class FrmTuyenDuong : Form
    {
        private DBTuyenDuong dbtd;
        private DataTable dtTuyenDuong;
        private bool Them;
        public FrmTuyenDuong()
        {
            InitializeComponent();
            dbtd = new DBTuyenDuong();
            txtTimKiem.GotFocus += RemoveText;
            txtTimKiem.LostFocus += AddText;
        }
        private void LoadData()
        {
            try
            {
                dtTuyenDuong = dbtd.LayTuyenDuong();
                dgvTuyenDuong.DataSource = dtTuyenDuong;


                // Format DataGridView
                dgvTuyenDuong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvTuyenDuong.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvTuyenDuong.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvTuyenDuong.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                dgvTuyenDuong.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dgvTuyenDuong.RowTemplate.Height = 30;
                dgvTuyenDuong.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dgvTuyenDuong.AllowUserToAddRows = false;
                dgvTuyenDuong.ReadOnly = true;
                dgvTuyenDuong.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

                ResetFields();
                ToggleControls(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void ResetFields()
        {
            txt_MaTuyen.ResetText();
            txt_TenTuyen.ResetText();
            txt_DiemDau.ResetText();
            txt_DiemCuoi.ResetText();
            txt_DoDaiTB.ResetText();
            txt_ThoiGianTB.ResetText();
            txt_TinhTrang.ResetText();
        }

        private void ToggleControls(bool isEditing)
        {
            btnLuu.Enabled = isEditing;
            btnHuyBo.Enabled = isEditing;

            btnThem.Enabled = !isEditing;
            btnSua.Enabled = !isEditing;
            btnXoa.Enabled = !isEditing;
        }

        private void dgvTuyenDuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTuyenDuong.Rows[e.RowIndex];
                txt_MaTuyen.Text = row.Cells["MaTuyen"].Value.ToString();
                txt_TenTuyen.Text = row.Cells["TenTuyen"].Value.ToString();
                txt_DiemDau.Text = row.Cells["DiemDau"].Value.ToString();
                txt_DiemCuoi.Text = row.Cells["DiemCuoi"].Value.ToString();
                txt_DoDaiTB.Text = row.Cells["DoDai_TB"].Value.ToString();
                txt_ThoiGianTB.Text = row.Cells["ThoiGianTB"].Value.ToString();
                txt_TinhTrang.Text = row.Cells["TinhTrang"].Value.ToString();
            }
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            Them = true;
            ResetFields();
            ToggleControls(true);
            LoadData(); 
            txt_MaTuyen.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            ResetFields();
            ToggleControls(true);
            txt_MaTuyen.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;
            ToggleControls(true);
            txt_MaTuyen.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string err = "";
                if (dbtd.XoaTuyenDuong(ref err, txt_MaTuyen.Text))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Lỗi: " + err);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string err = "";
            bool result;

            if (Them)
            {
                result = dbtd.ThemTuyenDuong(ref err, txt_MaTuyen.Text, txt_TenTuyen.Text, txt_DiemDau.Text, txt_DiemCuoi.Text, float.Parse(txt_DoDaiTB.Text), float.Parse(txt_ThoiGianTB.Text), txt_TinhTrang.Text);
            }
            else
            {
                result = dbtd.CapNhatTuyenDuong(ref err, txt_MaTuyen.Text, txt_TenTuyen.Text, txt_DiemDau.Text, txt_DiemCuoi.Text, float.Parse(txt_DoDaiTB.Text), float.Parse(txt_ThoiGianTB.Text), txt_TinhTrang.Text);
            }

            if (result)
            {
                MessageBox.Show(Them ? "Thêm thành công!" : "Cập nhật thành công!");
                LoadData();
            }
            else
            {
                MessageBox.Show("Lỗi: " + err);
            }
        }

        private void FrmTuyenDuong_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            ResetFields();
            ToggleControls(false);
        }

        // Gọi hàm khi nhấn nút tìm kiếm
        private void TimKiemTuyenDuong()
        {
            try
            {
                string connectionString = "Data Source=HUUVAN140225\\SQLEXPRESS;Initial Catalog=QuanLyDatXe;Integrated Security=True";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.SearchTuyenDuongByKeyword(@Keyword)", conn))
                    {
                        string keyword = txtTimKiem.Text.Trim();
                        cmd.Parameters.AddWithValue("@Keyword", keyword);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvTuyenDuong.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }
        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {
            TimKiemTuyenDuong();
        }
        public void RemoveText(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "Search")
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = Color.Black;
            }
        }

        public void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                txtTimKiem.Text = "Search";
                txtTimKiem.ForeColor = Color.Gray;
            }
        }
    }
}
