using BusinessAccessLayer;
using System;
using System.Data;
using System.Windows.Forms;

namespace WFQLDatXeTrucTuyen
{
    public partial class FrmEditNhanVien : Form
    {
        private string maNV;
        private DBNhanVien dbnv;

        public FrmEditNhanVien(string maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
            dbnv = new DBNhanVien();
            StartPosition = FormStartPosition.CenterScreen;
            this.Load += FrmSuaNhanVien_Load;
            this.btnLuu.Click += btnLuu_Click;
            this.btnHuyBo.Click += btnHuy_Click;
        }

        public FrmEditNhanVien()
        {
            InitializeComponent();
            dbnv = new DBNhanVien();
            this.Load += FrmThemNhanVien_Load;
            this.btnLuu.Click += btnThem_Click;
            this.btnHuyBo.Click += btnHuy_Click;
        }

        private void FrmSuaNhanVien_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            LoadNhanVien();
            txt_MaNV.Enabled = false;
        }

        private void FrmThemNhanVien_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            txt_MaNV.Enabled = true;
        }

        private void LoadComboBoxes()
        {
            txt_TinhTrang.Items.Clear();
            txt_TinhTrang.Items.Add("Hoạt động");
            txt_TinhTrang.Items.Add("Ngưng hoạt động");
        }

        private void LoadNhanVien()
        {
            try
            {
                DataTable dt = dbnv.LayNhanVienTheoMa(maNV);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txt_MaNV.Text = row["MaNhanVien"].ToString();
                    txt_HoTen.Text = row["HoTen"].ToString();
                    date_NgaySinh.Value = Convert.ToDateTime(row["NgaySinh"]);
                    txt_DiaChi.Text = row["DiaChi"].ToString();
                    txt_CCCD.Text = row["CCCD"].ToString();
                    txt_SDT.Text = row["SDT"].ToString();
                    txt_TaiKhoan.Text = row["TaiKhoan"].ToString();
                    txt_MatKhau.Text = row["MatKhau"].ToString();
                    date_NgayThem.Value = Convert.ToDateTime(row["NgayThem"]);
                    txt_TinhTrang.Text = row["TinhTrang"].ToString();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin: " + ex.Message);
                this.Close();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string err = "";
            bool result;

            if (string.IsNullOrWhiteSpace(txt_MaNV.Text) ||
                string.IsNullOrWhiteSpace(txt_HoTen.Text) ||
string.IsNullOrWhiteSpace(txt_CCCD.Text) ||
                string.IsNullOrWhiteSpace(txt_SDT.Text) ||
                string.IsNullOrWhiteSpace(txt_TaiKhoan.Text) ||
                string.IsNullOrWhiteSpace(txt_MatKhau.Text) ||
                string.IsNullOrWhiteSpace(txt_DiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            result = dbnv.ThemNhanVien(ref err,
                        txt_MaNV.Text,
                        txt_HoTen.Text,
                        txt_CCCD.Text,
                        date_NgaySinh.Value,
                        txt_DiaChi.Text,
                        date_NgayThem.Value,
                        txt_TinhTrang.Text,
                        txt_SDT.Text,
                        txt_TaiKhoan.Text,
                        txt_MatKhau.Text);

            if (result)
            {
                MessageBox.Show("Thêm mới nhân viên thành công!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Lỗi khi thêm: " + err);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string err = "";
            bool result;

            if (string.IsNullOrWhiteSpace(txt_MaNV.Text) ||
                string.IsNullOrWhiteSpace(txt_HoTen.Text) ||
                string.IsNullOrWhiteSpace(txt_CCCD.Text) ||
                string.IsNullOrWhiteSpace(txt_SDT.Text) ||
                string.IsNullOrWhiteSpace(txt_TaiKhoan.Text) ||
                string.IsNullOrWhiteSpace(txt_MatKhau.Text) ||
                string.IsNullOrWhiteSpace(txt_DiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            result = dbnv.CapNhatNhanVien(ref err,
                        txt_MaNV.Text,
                        txt_HoTen.Text,
                        txt_CCCD.Text,
                        date_NgaySinh.Value,
                        txt_DiaChi.Text,
                        date_NgayThem.Value,
                        txt_TinhTrang.Text,
                        txt_SDT.Text,
                        txt_TaiKhoan.Text,
                        txt_MatKhau.Text);

            if (result)
            {
                MessageBox.Show("Cập nhật thành công!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Lỗi: " + err);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
