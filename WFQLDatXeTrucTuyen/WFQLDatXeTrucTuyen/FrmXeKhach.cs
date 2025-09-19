using BusinessAccessLayer;
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
using System.Security.Permissions;
namespace WFQLDatXeTrucTuyen
{
    public partial class FrmXeKhach : Form
    {
        private DBXeKhach dbxk;
        private DataTable dtXeKhach;
        private DBLoaiXe dblx;
        private DataTable dtLoaiXe;
        private bool Them;
        public FrmXeKhach()
        {
            InitializeComponent();
            dbxk = new DBXeKhach();
            dblx = new DBLoaiXe();
        }

        private void FrmXeKhach_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadComboBox();
            LoadTheme();
        }
        private void LoadData()
        {
            try
            {
                dtXeKhach = dbxk.LayXeKhach();
                dgvXeKhach.DataSource = dtXeKhach;

                dtLoaiXe = dblx.LayLoaiXe();
                dgvLoaiXe.DataSource = dtLoaiXe;


                // Format DataGridView
                dgvLoaiXe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvLoaiXe.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvLoaiXe.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvLoaiXe.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                dgvLoaiXe.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dgvLoaiXe.RowTemplate.Height = 30;
                dgvLoaiXe.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dgvLoaiXe.AllowUserToAddRows = false;
                dgvLoaiXe.ReadOnly = true;
                dgvLoaiXe.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

                // Format DataGridView
                dgvXeKhach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvXeKhach.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvXeKhach.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvXeKhach.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                dgvXeKhach.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dgvXeKhach.RowTemplate.Height = 30;
                dgvXeKhach.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dgvXeKhach.AllowUserToAddRows = false;
                dgvXeKhach.ReadOnly = true;
                dgvXeKhach.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;


                ResetFields();
                ToggleControls(false);
                ConfigureDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void LoadComboBox()
        {
            cbb_MaLoaiXe.DataSource = dtLoaiXe;
            cbb_MaLoaiXe.DisplayMember = "MaLoaiXe_LoaiXe";
            cbb_MaLoaiXe.ValueMember = "MaLoaiXe";
            cbb_TinhTrang.Items.AddRange(new string[] { "Hoạt động", "Ngưng hoạt động" });
            cbb_TinhTrang.SelectedIndex = 0;
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
        private void ConfigureDataGridView()
        {
            dgvXeKhach.Columns["MaLoaiXe_XeKhach"].HeaderText = "Mã Loại Xe";
            if (dgvXeKhach.Columns.Contains("TenLoaiXe"))
                dgvXeKhach.Columns["TenLoaiXe"].HeaderText = "Tên Loại Xe";

            dgvLoaiXe.Columns["MaLoaiXe"].HeaderText = "Mã Loại Xe";
            dgvLoaiXe.Columns["TenLoaiXe"].HeaderText = "Tên Loại Xe";
            dgvLoaiXe.Columns["SoLuongGhe"].HeaderText = "Số Lượng Ghế";
        }
        private void ResetFields()
        {
            this.txt_MaXeKhach.ResetText();
            this.txt_TenXe.ResetText();
            this.txt_BienSo.ResetText();
            this.cbb_TinhTrang.SelectedIndex = -1;
            this.cbb_MaLoaiXe.SelectedIndex = -1;
            this.txt_MaLoaiXe.ResetText();
            this.txt_TenLoaiXe.ResetText();
            this.txt_SoLuongGhe.ResetText();
        }

        private void ToggleControls(bool enableEditing)
        {
            btnLuu.Enabled = enableEditing;
            btnHuyBo.Enabled = enableEditing;

            btnThem.Enabled = !enableEditing;
            btnSua.Enabled = !enableEditing;
            btnXoa.Enabled = !enableEditing;
            btnReLoad.Enabled = !enableEditing;
        }
        private void dgvXeKhach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
                DataGridViewRow row = dgvXeKhach.Rows[e.RowIndex];

                // Lấy các thông tin về xe khách
                this.txt_MaXeKhach.Text = row.Cells["MaXeKhach"].Value.ToString();
                this.txt_TenXe.Text = row.Cells["TenXe"].Value.ToString();
                this.txt_BienSo.Text = row.Cells["BienSo"].Value.ToString();
                this.cbb_TinhTrang.SelectedItem = row.Cells["TinhTrang"].Value.ToString();
                this.cbb_MaLoaiXe.SelectedValue = row.Cells["MaLoaiXe_XeKhach"].Value.ToString();

                // Lấy mã loại xe từ xe khách, sau đó tìm tên loại xe trong dgvLoaiXe
                string maLoaiXe = row.Cells["MaLoaiXe_XeKhach"].Value.ToString();

                // Lọc bảng LoaiXe để lấy tên loại xe tương ứng với mã loại xe đã chọn
                foreach (DataGridViewRow loaiXeRow in dgvLoaiXe.Rows)
                {
                    if (loaiXeRow.Cells["MaLoaiXe"].Value.ToString() == maLoaiXe)
                    {
                        // Điền tên loại xe vào txt_TenLoaiXe
                        this.txt_TenLoaiXe.Text = loaiXeRow.Cells["TenLoaiXe"].Value.ToString();
                        this.txt_MaLoaiXe.Text = loaiXeRow.Cells["MaLoaiXe"].Value.ToString();
                        this.txt_TenLoaiXe.Text = loaiXeRow.Cells["TenLoaiXe"].Value.ToString();
                        this.txt_SoLuongGhe.Text = loaiXeRow.Cells["SoLuongGhe"].Value.ToString();
                        break;
                    }
             
            }
        }


        private void dgvLoaiXe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLoaiXe.Rows[e.RowIndex];
                this.txt_MaLoaiXe.Text = row.Cells["MaLoaiXe"].Value.ToString();
                this.txt_TenLoaiXe.Text = row.Cells["TenLoaiXe"].Value.ToString();
                this.txt_SoLuongGhe.Text = row.Cells["SoLuongGhe"].Value.ToString();
            }
        }

       
        private void btnReLoad_Click(object sender, EventArgs e)
        {
            ResetFields();
            ToggleControls(true);
            LoadData();
            txt_MaXeKhach.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            ResetFields();
            ToggleControls(true);
            txt_MaXeKhach.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Them = false;
            ToggleControls(true);
            txt_MaXeKhach.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = dgvXeKhach.CurrentCell.RowIndex;
                string maXeKhach = dgvXeKhach.Rows[rowIndex].Cells[0].Value.ToString();
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                string err = "";
                if (result == DialogResult.Yes && dbxk.XoaXeKhach(ref err, maXeKhach))
                {
                    LoadData();
                    MessageBox.Show("Xóa thành công!");
                }
                else
                {
                    MessageBox.Show("Không thể xóa: " + err);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi hệ thống khi xóa.");
            }
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            ResetFields();
            ToggleControls(false);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string err ="";

            bool result;

            if (string.IsNullOrWhiteSpace(txt_MaXeKhach.Text) ||
                string.IsNullOrWhiteSpace(cbb_MaLoaiXe.Text) ||
                string.IsNullOrWhiteSpace(txt_TenXe.Text) ||
                string.IsNullOrWhiteSpace(txt_BienSo.Text) ||
                string.IsNullOrWhiteSpace(cbb_TinhTrang.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (Them)
            {
                result = dbxk.ThemXeKhach(ref err,
                        this.txt_MaXeKhach.Text,
                        this.cbb_MaLoaiXe.SelectedValue.ToString(),
                        this.txt_TenXe.Text,
                        this.txt_BienSo.Text,
                        this.cbb_TinhTrang.SelectedItem.ToString());
            }
            else
            {
                result = dbxk.CapNhatXeKhach(ref err,
                        this.txt_MaXeKhach.Text,
                        this.cbb_MaLoaiXe.SelectedValue.ToString(),
                        this.txt_TenXe.Text,
                        this.txt_BienSo.Text,
                        this.cbb_TinhTrang.SelectedItem.ToString());
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
    }
}
