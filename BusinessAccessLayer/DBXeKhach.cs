using System;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

namespace BusinessAccessLayer
{
    public class DBXeKhach
    {
        private DAL db; // Đối tượng DAL

        // Constructor khởi tạo đối tượng DAL
        public DBXeKhach()
        {
            db = new DAL();
        }

        //  Lấy danh sách xe khách
        public DataTable LayXeKhach()
        {
            DataTable dt = new DataTable();
            try
            {
                db.openConnection(); // Mở kết nối
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM View_XeKhach_LoaiXe", db.getConnection))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy dữ liệu xe khách: " + ex.Message);
            }
            finally
            {
                db.closeConnection(); // Đóng kết nối
            }
            return dt;
        }

        //  Thêm xe khách mới
        public bool ThemXeKhach(ref string err, string MaXeKhach, string MaLoaiXe, string TenXe, string BienSo, string TinhTrang)
        {
            try
            {
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand("spThemXeKhach", db.getConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaXeKhach", MaXeKhach);
                    cmd.Parameters.AddWithValue("@MaLoaiXe", MaLoaiXe);
                    cmd.Parameters.AddWithValue("@TenXe", TenXe);
                    cmd.Parameters.AddWithValue("@BienSo", BienSo);
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

        //  Xóa xe khách
        public bool XoaXeKhach(ref string err, string MaXeKhach)
        {
            try
            {
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand("spXoaXeKhach", db.getConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaXeKhach", MaXeKhach);

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

        //  Cập nhật xe khách
        public bool CapNhatXeKhach(ref string err, string MaXeKhach, string MaLoaiXe, string TenXe, string BienSo, string TinhTrang)
        {
            try
            {
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand("spCapNhatXeKhach", db.getConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaXeKhach", MaXeKhach);
                    cmd.Parameters.AddWithValue("@MaLoaiXe", MaLoaiXe);
                    cmd.Parameters.AddWithValue("@TenXe", TenXe);
                    cmd.Parameters.AddWithValue("@BienSo", BienSo);
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
