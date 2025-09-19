using System;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer; // Import lớp DAL

namespace BusinessAccessLayer
{
    public class DBKhuyenMai
    {
        private DAL db; // Đối tượng DAL

        // Constructor khởi tạo đối tượng DAL
        public DBKhuyenMai()
        {
            db = new DAL();
        }

        //  Lấy danh sách khuyến mãi
        public DataTable LayKhuyenMai()
        {
            DataTable dt = new DataTable();
            try
            {
                db.openConnection(); // Mở kết nối
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM vi_KhuyenMaiView", db.getConnection))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy dữ liệu khuyến mãi: " + ex.Message);
            }
            finally
            {
                db.closeConnection(); // Đóng kết nối
            }
            return dt;
        }

        //  Thêm khuyến mãi mới
        public bool ThemKhuyenMai(ref string err, string MaKM, string TenChuongTrinh, DateTime NgayAD, DateTime NgayKT, float MucGiam)
        {
            try
            {
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand("spThemKhuyenMai", db.getConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaKM", MaKM);
                    cmd.Parameters.AddWithValue("@TenChuongTrinh", TenChuongTrinh);
                    cmd.Parameters.AddWithValue("@NgayAD", NgayAD);
                    cmd.Parameters.AddWithValue("@NgayKT", NgayKT);
                    cmd.Parameters.AddWithValue("@MucGiam", MucGiam);

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

        //  Xóa khuyến mãi
        public bool XoaKhuyenMai(ref string err, string MaKM)
        {
            try
            {
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand("spXoaKhuyenMai", db.getConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaKM", MaKM);

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

        //  Cập nhật khuyến mãi
        public bool CapNhatKhuyenMai(ref string err, string MaKM, string TenChuongTrinh, DateTime NgayAD, DateTime NgayKT, float MucGiam)
        {
            try
            {
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand("spCapNhatKhuyenMai", db.getConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaKM", MaKM);
                    cmd.Parameters.AddWithValue("@TenChuongTrinh", TenChuongTrinh);
                    cmd.Parameters.AddWithValue("@NgayAD", NgayAD);
                    cmd.Parameters.AddWithValue("@NgayKT", NgayKT);
                    cmd.Parameters.AddWithValue("@MucGiam", MucGiam);

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
    }
}
