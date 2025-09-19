using System;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer; // Import lớp DAL

namespace BusinessAccessLayer
{
    public class DBChuyenXe
    {
        private DAL db; // Đối tượng DAL

        // Constructor khởi tạo đối tượng DAL
        public DBChuyenXe()
        {
            db = new DAL();
        }

        //  Lấy danh sách chuyến xe
        public DataTable LayChuyenXe()
        {
            DataTable dt = new DataTable();
            try
            {
                db.openConnection(); // Mở kết nối
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM vi_ChuyenXeView", db.getConnection))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy dữ liệu chuyến xe: " + ex.Message);
            }
            finally
            {
                db.closeConnection(); // Đóng kết nối
            }
            return dt;
        }

        // Thêm chuyến xe mới
        public bool ThemChuyenXe(ref string err, string MaChuyen, string MaXeKhach, string MaTaiXe, string MaPhuXe, string MaTuyen, DateTime ThoiGianXP, float GiaVe)
        {
            try
            {
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand("spThemChuyenXe", db.getConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaChuyen", MaChuyen);
                    cmd.Parameters.AddWithValue("@MaXeKhach", MaXeKhach);
                    cmd.Parameters.AddWithValue("@MaTaiXe", MaTaiXe);
                    cmd.Parameters.AddWithValue("@MaPhuXe", MaPhuXe);
                    cmd.Parameters.AddWithValue("@MaTuyen", MaTuyen);
                    cmd.Parameters.AddWithValue("@ThoiGianXP", ThoiGianXP);
                    cmd.Parameters.AddWithValue("@GiaVe", GiaVe);

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

        // Xóa chuyến xe
        public bool XoaChuyenXe(ref string err, string MaChuyen)
        {
            try
            {
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand("spXoaChuyenXe", db.getConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaChuyen", MaChuyen);

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

        //  Cập nhật chuyến xe
        public bool CapNhatChuyenXe(ref string err, string MaChuyen, string MaXeKhach, string MaTaiXe, string MaPhuXe, string MaTuyen, DateTime ThoiGianXP, float GiaVe)
        {
            try
            {
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand("spCapNhatChuyenXe", db.getConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaChuyen", MaChuyen);
                    cmd.Parameters.AddWithValue("@MaXeKhach", MaXeKhach);
                    cmd.Parameters.AddWithValue("@MaTaiXe", MaTaiXe);
                    cmd.Parameters.AddWithValue("@MaPhuXe", MaPhuXe);
                    cmd.Parameters.AddWithValue("@MaTuyen", MaTuyen);
                    cmd.Parameters.AddWithValue("@ThoiGianXP", ThoiGianXP);
                    cmd.Parameters.AddWithValue("@GiaVe", GiaVe);

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
        public DataTable GetChuyenXeInfo()
        {
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();
                string query = "SELECT * FROM GetChuyenXeInfo()"; // Gọi hàm GetChuyenXeInfo
                using (SqlCommand cmd = new SqlCommand(query, db.getConnection))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách lịch trình: " + ex.Message);
            }
            finally
            {
                db.closeConnection();
            }
            return dt; // Trả về dt trực tiếp
        }
    }
}
