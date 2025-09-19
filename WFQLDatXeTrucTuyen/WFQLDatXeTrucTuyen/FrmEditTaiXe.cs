using BusinessAccessLayer;
using System;
using System.Data;
using System.Windows.Forms;

namespace WFQLDatXeTrucTuyen
{
    public partial class FrmEditTaiXe : Form
    {
        private string maNV;
        private DBTaiXe dbtx;

        public FrmEditTaiXe(string maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
            dbtx = new DBTaiXe();
            this.Load += FrmSuaNhanVien_Load;
            this.btnLuu.Click += btnLuu_Click;
            this.btnHuyBo.Click += btnHuy_Click;
            StartPosition = FormStartPosition.CenterScreen;
        }

        public FrmEditTaiXe()
        {
            InitializeComponent();
            dbtx = new DBTaiXe();
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
                DataTable dt = dbtx.LayTaiXeTheoMa(maNV);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txt_MaNV.Text = row["MaNhanVien"].ToString();
                    txt_HoTen.Text = row["HoTen"].ToString();
                    txt_CCCD.Text = row["CCCD"].ToString();
                    date_NgaySinh.Value = Convert.ToDateTime(row["NgaySinh"]);
                    txt_DiaChi.Text = row["DiaChi"].ToString();
                    txt_MaGPLX.Text = row["MaGPLX"].ToString();
                    date_NgayHetHan.Value = Convert.ToDateTime(row["NgayHetHan"]);
                    date_NgayThem.Value = Convert.ToDateTime(row["NgayThem"]);
                    txt_TinhTrang.Text = row["TinhTrang"].ToString();
                    txt_SDT.Text = row["SDT"].ToString();
                    txt_TaiKhoan.Text = row["TaiKhoan"].ToString();
                    txt_MatKhau.Text = row["MatKhau"].ToString();
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

            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrWhiteSpace(txt_MaNV.Text) ||
                string.IsNullOrWhiteSpace(txt_HoTen.Text) ||
                string.IsNullOrWhiteSpace(txt_CCCD.Text) ||
                string.IsNullOrWhiteSpace(txt_SDT.Text) ||
                string.IsNullOrWhiteSpace(txt_TaiKhoan.Text) ||
                string.IsNullOrWhiteSpace(txt_MatKhau.Text) ||
                string.IsNullOrWhiteSpace(txt_DiaChi.Text) ||
                string.IsNullOrWhiteSpace(txt_MaGPLX.Text) ||
                string.IsNullOrWhiteSpace(txt_TinhTrang.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin tài xế!");
                return;
            }

            // Kiểm tra ngày hợp lệ
            if (date_NgayHetHan.Value <= DateTime.Now)
            {
                MessageBox.Show("Ngày hết hạn bằng lái phải lớn hơn ngày hiện tại.");
                return;
            }

            // Gọi hàm thêm dữ liệu
            bool result = dbtx.ThemTaiXe(ref err,
                txt_MaNV.Text,
                txt_HoTen.Text,
                txt_CCCD.Text,
                date_NgaySinh.Value,
                txt_DiaChi.Text,
                txt_MaGPLX.Text,
                date_NgayHetHan.Value,
                date_NgayThem.Value,
                 txt_TinhTrang.SelectedItem.ToString(),
                txt_SDT.Text,
                txt_TaiKhoan.Text,
                txt_MatKhau.Text
            );

            if (result)
            {
                MessageBox.Show("Thêm tài xế thành công!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Lỗi khi thêm tài xế: " + err);
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string err = "";

            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrWhiteSpace(txt_MaNV.Text) ||
                string.IsNullOrWhiteSpace(txt_HoTen.Text) ||
                string.IsNullOrWhiteSpace(txt_CCCD.Text) ||
                string.IsNullOrWhiteSpace(txt_SDT.Text) ||
                string.IsNullOrWhiteSpace(txt_TaiKhoan.Text) ||
                string.IsNullOrWhiteSpace(txt_MatKhau.Text) ||
                string.IsNullOrWhiteSpace(txt_DiaChi.Text) ||
                string.IsNullOrWhiteSpace(txt_MaGPLX.Text) ||
                string.IsNullOrWhiteSpace(txt_TinhTrang.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin tài xế!");
                return;
            }


            // Gọi hàm cập nhật dữ liệu
            bool result = dbtx.CapNhatTaiXe(ref err,
                txt_MaNV.Text,
                txt_HoTen.Text,
                txt_CCCD.Text,
                date_NgaySinh.Value,
                txt_DiaChi.Text,
                txt_MaGPLX.Text,
                date_NgayHetHan.Value,
                date_NgayThem.Value,
                txt_TinhTrang.SelectedItem.ToString(),
                txt_SDT.Text,
                txt_TaiKhoan.Text,
                txt_MatKhau.Text
            );

            if (result)
            {
                MessageBox.Show("Cập nhật tài xế thành công!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Lỗi khi cập nhật: " + err);
            }
        }



        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
