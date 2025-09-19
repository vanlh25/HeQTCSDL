using System;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer; // Import lớp DAL

namespace BusinessAccessLayer
{
    public class DBKhachHang
    {
        private DAL db; // Đối tượng DAL

        // Constructor khởi tạo đối tượng DAL
        public DBKhachHang()
        {
            db = new DAL();
        }

        // 📌 Lấy danh sách khách hàng
        public DataTable LayKhachHang()
        {
            DataTable dt = new DataTable();
            try
            {
                db.openConnection(); // Mở kết nối
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM vi_KhachHangView", db.getConnection))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy dữ liệu khách hàng: " + ex.Message);
            }
            finally
            {
                db.closeConnection(); // Đóng kết nối
            }
            return dt;
        }

        // 📌 Thêm khách hàng mới
        public bool ThemKhachHang(ref string err, string MaKhach, string TenKhach, DateTime NgaySinh, string DiaChi, string CCCD, string Email, string SDT)
        {
            try
            {
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand("spThemKhachHang", db.getConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaKhach", MaKhach);
                    cmd.Parameters.AddWithValue("@TenKhach", TenKhach);
                    cmd.Parameters.AddWithValue("@NgaySinh", NgaySinh);
                    cmd.Parameters.AddWithValue("@DiaChi", DiaChi);
                    cmd.Parameters.AddWithValue("@CCCD", CCCD);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@SDT", SDT);

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

        // 📌 Xóa khách hàng
        public bool XoaKhachHang(ref string err, string MaKhach)
        {
            try
            {
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand("spXoaKhachHang", db.getConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaKhach", MaKhach);

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

        // 📌 Cập nhật khách hàng
        public bool CapNhatKhachHang(ref string err, string MaKhach, string TenKhach, DateTime NgaySinh, string DiaChi, string CCCD, string Email, string SDT)
        {
            try
            {
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand("spCapNhatKhachHang", db.getConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaKhach", MaKhach);
                    cmd.Parameters.AddWithValue("@TenKhach", TenKhach);
                    cmd.Parameters.AddWithValue("@NgaySinh", NgaySinh);
                    cmd.Parameters.AddWithValue("@DiaChi", DiaChi);
                    cmd.Parameters.AddWithValue("@CCCD", CCCD);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@SDT", SDT);

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
        public DataTable LayKhachHangTheoMa(string maKH)
        {
            DataTable dt = new DataTable();

            try
            {
                db.openConnection();

                string sql = "EXEC LayKhachHangTheoMa @MaKhach";

                using (SqlCommand cmd = new SqlCommand(sql, db.getConnection))
                {
                    cmd.Parameters.AddWithValue("@MaKhach", maKH.Trim());

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy khách hàng theo mã: " + ex.Message);
            }
            finally
            {
                db.closeConnection();
            }

            return dt;
        }
    }
}
