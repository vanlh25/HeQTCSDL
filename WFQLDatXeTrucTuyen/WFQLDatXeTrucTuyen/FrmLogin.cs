using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using DataAccessLayer; // Import lớp kết nối DAL

namespace WFQLDatXeTrucTuyen
{
    public partial class FrmLogin : Form
    {
        private DAL dal = new DAL(); // Khởi tạo đối tượng DAL

        public FrmLogin()
        {
            InitializeComponent();
            this.AcceptButton = btnDangNhap;
        }

        public static string LoggedInUser = "";

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                dal.openConnection(); // Mở kết nối

                string username = txtNhapTaiKhoan.Text.Trim();
                string password = txtNhapMatKhau.Text.Trim();

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = @"
                    SELECT TaiKhoan FROM NhanVien 
                    WHERE TaiKhoan = @username AND MatKhau = @password
                    UNION ALL 
                    SELECT TaiKhoan FROM TaiXe 
                    WHERE TaiKhoan = @username AND MatKhau = @password";

                using (SqlCommand cmd = new SqlCommand(query, dal.getConnection))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string taikhoan = reader["TaiKhoan"].ToString().Trim();

                        // Danh sách các tiền tố cho từng vai trò
                        List<string> quanLyPrefix = new List<string> { "QuanLy" };
                        List<string> nhanVienPrefix = new List<string> { "CSKH" };

                        if (quanLyPrefix.Any(p => taikhoan.StartsWith(p)))
                        {
                            FrmManHinhChinh mainForm = new FrmManHinhChinh();
                            mainForm.Show();
                            this.Hide();
                        }
                        else if (nhanVienPrefix.Any(p => taikhoan.StartsWith(p)))
                        {
                            FrmManHinhChinh_NhanVien mainForm_NhanVien = new FrmManHinhChinh_NhanVien();
                            mainForm_NhanVien.Show();
                            this.Hide();
                        }
                        else 
                        {
                            FrmManHinhChinh_LaiXe mainForm = new FrmManHinhChinh_LaiXe();
                            mainForm.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtNhapMatKhau.Text = "";
                        txtNhapTaiKhoan.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dal.closeConnection(); // Đóng kết nối
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi = MessageBox.Show("Bạn có chắc muốn thoát không?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traloi == DialogResult.Yes)
                Application.Exit();
        }
    }
}
