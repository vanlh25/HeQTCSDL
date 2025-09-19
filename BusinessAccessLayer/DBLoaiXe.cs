using System;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;

namespace BusinessAccessLayer
{
    public class DBLoaiXe
    {
        private DAL db;

        // Constructor khởi tạo đối tượng DAL
        public DBLoaiXe()
        {
            db = new DAL();
        }

        // Lấy danh sách loại xe
        public DataTable LayLoaiXe()
        {
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM vi_LoaiXeView", db.getConnection))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy dữ liệu loại xe: " + ex.Message);
            }
            finally
            {
                db.closeConnection();
            }
            return dt;
        }

        //  Thêm loại xe
        public bool ThemLoaiXe(ref string err, string MaLoaiXe, string TenLoaiXe, int SoLuongGhe)
        {
            try
            {
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand("spThemLoaiXe", db.getConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaLoaiXe", MaLoaiXe);
                    cmd.Parameters.AddWithValue("@TenLoaiXe", TenLoaiXe);
                    cmd.Parameters.AddWithValue("@SoLuongGhe", SoLuongGhe);

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

        //  Xóa loại xe
        public bool XoaLoaiXe(ref string err, string MaLoaiXe)
        {
            try
            {
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand("spXoaLoaiXe", db.getConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaLoaiXe", MaLoaiXe);

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

        //  Cập nhật loại xe
        public bool CapNhatLoaiXe(ref string err, string MaLoaiXe, string TenLoaiXe, int SoLuongGhe)
        {
            try
            {
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand("spCapNhatLoaiXe", db.getConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaLoaiXe", MaLoaiXe);
                    cmd.Parameters.AddWithValue("@TenLoaiXe", TenLoaiXe);
                    cmd.Parameters.AddWithValue("@SoLuongGhe", SoLuongGhe);

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
