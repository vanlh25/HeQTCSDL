using System;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer; // Import lớp DAL

namespace BusinessAccessLayer
{
    public class DBNhanVien
    {
        private DAL db; // Đối tượng DAL

        // Constructor khởi tạo đối tượng DAL
        public DBNhanVien()
        {
            db = new DAL();
        }

        // 📌 Lấy danh sách nhân viên
        public DataTable LayNhanVien()
        {
            DataTable dt = new DataTable();
            try
            {
                db.openConnection(); // Mở kết nối
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM vi_NhanVienView", db.getConnection))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy dữ liệu nhân viên: " + ex.Message);
            }
            finally
            {
                db.closeConnection(); // Đóng kết nối
            }
            return dt;
        }

        // 📌 Thêm nhân viên mới
        public bool ThemNhanVien(ref string err, string MaNhanVien, string HoTen, string CCCD, DateTime NgaySinh, string DiaChi, DateTime NgayThem, string TinhTrang, string SDT, string TaiKhoan, string MatKhau)
        {
            try
            {
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand("spThemNhanVien", db.getConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                    cmd.Parameters.AddWithValue("@HoTen", HoTen);
                    cmd.Parameters.AddWithValue("@CCCD", CCCD);
                    cmd.Parameters.AddWithValue("@NgaySinh", NgaySinh);
                    cmd.Parameters.AddWithValue("@DiaChi", DiaChi);
                    cmd.Parameters.AddWithValue("@NgayThem", NgayThem);
                    cmd.Parameters.AddWithValue("@TinhTrang", TinhTrang);
                    cmd.Parameters.AddWithValue("@SDT", SDT);
                    cmd.Parameters.AddWithValue("@TaiKhoan", TaiKhoan);
                    cmd.Parameters.AddWithValue("@MatKhau", MatKhau);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
            finally
            {
                db.closeConnection();
            }
        }

        // 📌 Xóa nhân viên
        public bool XoaNhanVien(ref string err, string MaNhanVien)
        {
            try
            {
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand("spXoaNhanVien", db.getConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
            finally
            {
                db.closeConnection();
            }
        }

        // 📌 Cập nhật nhân viên
        public bool CapNhatNhanVien(ref string err, string MaNhanVien, string HoTen, string CCCD, DateTime NgaySinh, string DiaChi, DateTime NgayThem, string TinhTrang, string SDT, string TaiKhoan, string MatKhau)
        {
            try
            {
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand("spCapNhatNhanVien", db.getConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                    cmd.Parameters.AddWithValue("@HoTen", HoTen);
                    cmd.Parameters.AddWithValue("@CCCD", CCCD);
                    cmd.Parameters.AddWithValue("@NgaySinh", NgaySinh);
                    cmd.Parameters.AddWithValue("@DiaChi", DiaChi);
                    cmd.Parameters.AddWithValue("@NgayThem", NgayThem);
                    cmd.Parameters.AddWithValue("@TinhTrang", TinhTrang);
                    cmd.Parameters.AddWithValue("@SDT", SDT);
                    cmd.Parameters.AddWithValue("@TaiKhoan", TaiKhoan);
                    cmd.Parameters.AddWithValue("@MatKhau", MatKhau);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
            finally
            {
                db.closeConnection();
            }
        }
        public DataTable LayNhanVienTheoMa(string maNV)
        {
            DataTable dt = new DataTable();

            try
            {
                db.openConnection();

                string sql = "EXEC LayNhanVienTheoMa @MaNhanVien";

                using (SqlCommand cmd = new SqlCommand(sql, db.getConnection))
                {
                    cmd.Parameters.AddWithValue("@MaNhanVien", maNV.Trim());

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy nhân viên theo mã: " + ex.Message);
            }
            finally
            {
                db.closeConnection();
            }

            return dt;
        }
    }
}