using System;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer; // Import lớp DAL

namespace BusinessAccessLayer
{
    public class DBTuyenDuong
    {
        private DAL db; // Đối tượng DAL

        // Constructor khởi tạo đối tượng DAL
        public DBTuyenDuong()
        {
            db = new DAL();
        }

        // 📌 Lấy danh sách tuyến đường
        public DataTable LayTuyenDuong()
        {
            DataTable dt = new DataTable();
            try
            {
                db.openConnection(); // Mở kết nối
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM vi_TuyenDuongView", db.getConnection))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy dữ liệu tuyến đường: " + ex.Message);
            }
            finally
            {
                db.closeConnection(); // Đóng kết nối
            }
            return dt;
        }

        // 📌 Thêm tuyến đường mới
        public bool ThemTuyenDuong(ref string err, string MaTuyen, string TenTuyen, string DiemDau, string DiemCuoi, float DoDai_TB, float ThoiGianTB, string TinhTrang)
        {
            try
            {
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand("spThemTuyenDuong", db.getConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaTuyen", MaTuyen);
                    cmd.Parameters.AddWithValue("@TenTuyen", TenTuyen);
                    cmd.Parameters.AddWithValue("@DiemDau", DiemDau);
                    cmd.Parameters.AddWithValue("@DiemCuoi", DiemCuoi);
                    cmd.Parameters.AddWithValue("@DoDai_TB", DoDai_TB);
                    cmd.Parameters.AddWithValue("@ThoiGianTB", ThoiGianTB);
                    cmd.Parameters.AddWithValue("@TinhTrang", TinhTrang);

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

        // 📌 Xóa tuyến đường
        public bool XoaTuyenDuong(ref string err, string MaTuyen)
        {
            try
            {
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand("spXoaTuyenDuong", db.getConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaTuyen", MaTuyen);

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

        // 📌 Cập nhật tuyến đường
        public bool CapNhatTuyenDuong(ref string err, string MaTuyen, string TenTuyen, string DiemDau, string DiemCuoi, float DoDai_TB, float ThoiGianTB, string TinhTrang)
        {
            try
            {
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand("spCapNhatTuyenDuong", db.getConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaTuyen", MaTuyen);
                    cmd.Parameters.AddWithValue("@TenTuyen", TenTuyen);
                    cmd.Parameters.AddWithValue("@DiemDau", DiemDau);
                    cmd.Parameters.AddWithValue("@DiemCuoi", DiemCuoi);
                    cmd.Parameters.AddWithValue("@DoDai_TB", DoDai_TB);
                    cmd.Parameters.AddWithValue("@ThoiGianTB", ThoiGianTB);
                    cmd.Parameters.AddWithValue("@TinhTrang", TinhTrang);

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
