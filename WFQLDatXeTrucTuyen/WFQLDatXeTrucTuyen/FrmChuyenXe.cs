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
using System.Data.SqlClient;
namespace WFQLDatXeTrucTuyen
{
    public partial class FrmChuyenXe : Form
    {
        bool Them;
        DBChuyenXe dbcx;
        DBXeKhach dbxk;
        DBTaiXe dbtx;
        DBNhanVien dbnv;
        DBTuyenDuong dbtd;

        DataTable dtChuyenXe = null;

        public FrmChuyenXe()
        {
            InitializeComponent();
            dbcx = new DBChuyenXe();
            dbxk = new DBXeKhach();
            dbtx = new DBTaiXe();
            dbnv = new DBNhanVien();
            dbtd = new DBTuyenDuong();
            txtTimKiem.GotFocus += RemoveText;
            txtTimKiem.LostFocus += AddText;
        }
     
        private void FrmChuyenXe_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadComboBox();
            LoadTheme();


        }

        private void LoadData()
        {
            try
            {
                dtChuyenXe = dbcx.LayChuyenXe();
                dgvChuyenXe.DataSource = dtChuyenXe;

                // Format DataGridView
                dgvChuyenXe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvChuyenXe.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvChuyenXe.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvChuyenXe.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                dgvChuyenXe.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dgvChuyenXe.RowTemplate.Height = 30;
                dgvChuyenXe.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dgvChuyenXe.AllowUserToAddRows = false;
                dgvChuyenXe.ReadOnly = true;
                dgvChuyenXe.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                    
                ResetFields();
                ToggleControls(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        void LoadComboBox()
        {

            cbb_MaTaiXe.DataSource = dbtx.LayTaiXe();
            cbb_MaTaiXe.DisplayMember = "MaNhanVien";
            cbb_MaTaiXe.ValueMember = "MaNhanVien";

            cbb_MaPhuXe.DataSource = dbnv.LayNhanVien();
            cbb_MaPhuXe.DisplayMember = "MaNhanVien";
            cbb_MaPhuXe.ValueMember = "MaNhanVien";

            cbb_MaTuyen.DataSource = dbtd.LayTuyenDuong();
            cbb_MaTuyen.DisplayMember = "MaTuyen";
            cbb_MaTuyen.ValueMember = "MaTuyen";

            cbb_MaXeKhach.DataSource = dbxk.LayXeKhach();
            cbb_MaXeKhach.DisplayMember = "MaXeKhach";
            cbb_MaXeKhach.ValueMember = "MaXeKhach";
        }
        private void ResetFields()
        {
            txt_MaChuyen.ResetText();
            cbb_MaXeKhach.ResetText();
            cbb_MaTaiXe.ResetText();
            cbb_MaPhuXe.ResetText();
            cbb_MaTuyen.ResetText();
            date_ThoiGianXP.Value = DateTime.Now;
            txt_GiaVe.ResetText();
        }

        private void ToggleControls(bool isEditing)
        {
            btnLuu.Enabled = isEditing;

            btnThem.Enabled = !isEditing;
            btnXoa.Enabled = !isEditing;
            btnSua.Enabled = !isEditing;
        }

        private void dgvChuyenXe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvChuyenXe.Rows[e.RowIndex];
                txt_MaChuyen.Text = row.Cells["MaChuyen"].Value.ToString();
                cbb_MaXeKhach.Text = row.Cells["MaXeKhach"].Value.ToString();
                cbb_MaTaiXe.SelectedValue = row.Cells["MaTaiXe"].Value.ToString();
                cbb_MaPhuXe.SelectedValue = row.Cells["MaPhuXe"].Value.ToString();
                cbb_MaTuyen.SelectedValue = row.Cells["MaTuyen"].Value.ToString();
                date_ThoiGianXP.Value = Convert.ToDateTime(row.Cells["ThoiGianXP"].Value);
                txt_GiaVe.Text = row.Cells["GiaVe"].Value.ToString();
            }
        }
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
        }
        private void btnReLoad_Click(object sender, EventArgs e)
        { 
            LoadData(); 
        }

        private void btnThem_Click(object sender, EventArgs e) 
        {
            Them = true;
            ResetFields();
            ToggleControls(true);
            txt_MaChuyen.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;
            ToggleControls(true);
            txt_MaChuyen.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string err = "";
                if (dbcx.XoaChuyenXe(ref err, txt_MaChuyen.Text))
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

            if (string.IsNullOrWhiteSpace(txt_MaChuyen.Text) ||
                string.IsNullOrWhiteSpace(cbb_MaXeKhach.Text) ||
                string.IsNullOrWhiteSpace(cbb_MaTaiXe.Text) ||
                string.IsNullOrWhiteSpace(cbb_MaPhuXe.Text) ||
                string.IsNullOrWhiteSpace(cbb_MaTuyen.Text) ||
                string.IsNullOrWhiteSpace(date_ThoiGianXP.Text) ||
                string.IsNullOrWhiteSpace(txt_GiaVe.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (Them)
            {
                result = dbcx.ThemChuyenXe(ref err,
                        this.txt_MaChuyen.Text.ToString(),
                        this.cbb_MaXeKhach.SelectedValue.ToString(),
                        this.cbb_MaTaiXe.SelectedValue.ToString(),
                        this.cbb_MaPhuXe.SelectedValue.ToString(),
                        this.cbb_MaTuyen.SelectedValue.ToString(),
                        this.date_ThoiGianXP.Value,
                        float.Parse(this.txt_GiaVe.Text));
            }
            else
            {
                result = dbcx.ThemChuyenXe(ref err,
                        this.txt_MaChuyen.Text.ToString(),
                        this.cbb_MaXeKhach.SelectedValue.ToString(),
                        this.cbb_MaTaiXe.SelectedValue.ToString(),
                        this.cbb_MaPhuXe.SelectedValue.ToString(),
                        this.cbb_MaTuyen.SelectedValue.ToString(),
                        this.date_ThoiGianXP.Value,
                        float.Parse(this.txt_GiaVe.Text));
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

        private void txtTimKiem_TextChanged(object sender, EventArgs e){ }
        private void TimKiem()
        {
            try
            {
                string connectionString = "Data Source=HUUVAN140225\\SQLEXPRESS;Initial Catalog=QuanLyDatXe;Integrated Security=True";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.SearchChuyenXeByKeyword(@Keyword)", conn))
                    {
                        string keyword = txtTimKiem.Text.Trim();
                        cmd.Parameters.AddWithValue("@Keyword", keyword);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvChuyenXe.DataSource = dt;
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

        private void btn_XemVe_Click(object sender, EventArgs e)
        {
            if (txt_MaChuyen.Text == "")
            {
                MessageBox.Show("Vui lòng chọn chuyến xe!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FrmVe formXemVe = new FrmVe(txt_MaChuyen.Text);
            formXemVe.ShowDialog(); // Hiển thị form theo kiểu modal (đè lên)
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
