using BusinessAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WFQLDatXeTrucTuyen
{
    public partial class FrmKhuyenMai : Form
    {
        private DBKhuyenMai dbkm;
        private DataTable dtKhuyenMai;
        private bool Them;
        public FrmKhuyenMai()
        {
            InitializeComponent();
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            dbkm = new DBKhuyenMai();


            txtTimKiem.GotFocus += RemoveText;
            txtTimKiem.LostFocus += AddText;
        }

        private void FrmKhuyenMai_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                dtKhuyenMai = dbkm.LayKhuyenMai();
                dgvKhuyenMai.DataSource = dtKhuyenMai;

                // Format DataGridView
                dgvKhuyenMai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvKhuyenMai.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvKhuyenMai.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvKhuyenMai.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                dgvKhuyenMai.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dgvKhuyenMai.RowTemplate.Height = 30;
                dgvKhuyenMai.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dgvKhuyenMai.AllowUserToAddRows = false;
                dgvKhuyenMai.ReadOnly = true;
                dgvKhuyenMai.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

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
            txt_MaKM.ResetText();
            txt_TenChuongTrinh.ResetText();
            date_NgayAD.Value = DateTime.Now;
            date_NgayKT.Value = DateTime.Now;
            txt_MucGiam.ResetText();
        }

        private void ToggleControls(bool isEditing)
        {
            btnLuu.Enabled = isEditing;
            btnHuyBo.Enabled = isEditing;
            panel_KhuyenMai.Enabled = isEditing;

            btnThem.Enabled = !isEditing;
            btnSua.Enabled = !isEditing;
            btnXoa.Enabled = !isEditing;
            btnReload.Enabled = !isEditing;
        }
        private void dgvKhuyenMai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                DataGridViewRow row = dgvKhuyenMai.Rows[index];
                txt_MaKM.Text = row.Cells[0].Value.ToString();
                txt_TenChuongTrinh.Text = row.Cells[1].Value.ToString();
                date_NgayAD.Value = Convert.ToDateTime(row.Cells[2].Value);
                date_NgayKT.Value = Convert.ToDateTime(row.Cells[3].Value);

                if (double.TryParse(row.Cells[4].Value?.ToString(), out double mucGiam))
                    txt_MucGiam.Text = mucGiam.ToString("0.##");
                else
                    txt_MucGiam.Text = "0";
            }
        }
        private void dgvKhuyenMai_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvKhuyenMai.Columns[e.ColumnIndex].Name == "MucGiam" && e.Value != null)
            {
                if (double.TryParse(e.Value.ToString(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double mucGiam))
                {
                    e.Value = mucGiam.ToString("0.00"); // Hiển thị 2 chữ số thập phân
                    e.FormattingApplied = true;
                }
            }
        }



        private void btnReLoad_Click(object sender, EventArgs e) 
        { LoadData(); 
        }

        private void btnThem_Click(object sender, EventArgs e) 
        {
            Them = true;
            ResetFields();
            ToggleControls(true);
            txt_MaKM.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;
            ToggleControls(true);
            txt_MaKM.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string err = "";
                if (dbkm.XoaKhuyenMai(ref err, txt_MaKM.Text))
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

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            ResetFields();
            ToggleControls(false);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string err = "";
            bool result;

            if (string.IsNullOrWhiteSpace(txt_MaKM.Text) ||
                string.IsNullOrWhiteSpace(txt_TenChuongTrinh.Text) ||
                string.IsNullOrWhiteSpace(txt_MucGiam.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (Them)
            {
                result = dbkm.ThemKhuyenMai(ref err, txt_MaKM.Text, txt_TenChuongTrinh.Text, date_NgayAD.Value, date_NgayKT.Value, ConvertStringToFloat(txt_MucGiam.Text));
            }
            else
            {
                result = dbkm.CapNhatKhuyenMai(ref err, txt_MaKM.Text, txt_TenChuongTrinh.Text, date_NgayAD.Value, date_NgayKT.Value, ConvertStringToFloat(txt_MucGiam.Text));
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
        private float ConvertStringToFloat(string input)
        {
            if (float.TryParse(input, out float result))
                return result;

            MessageBox.Show("Giá trị nhập không hợp lệ! Vui lòng nhập số.", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return 0;
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
        private void TimKiem()
        {
            try
            {
                string connectionString = "Data Source=HUUVAN140225\\SQLEXPRESS;Initial Catalog=QuanLyDatXe;Integrated Security=True";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.SearchKhuyenMaiByKeyword(@Keyword)", conn))
                    {
                        string keyword = txtTimKiem.Text.Trim();
                        cmd.Parameters.AddWithValue("@Keyword", keyword);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvKhuyenMai.DataSource = dt;
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
            TimKiem();
        }
    }
}
