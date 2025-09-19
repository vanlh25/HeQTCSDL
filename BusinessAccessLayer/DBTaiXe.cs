using DataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BusinessAccessLayer
{
    public class DBTaiXe
    {
        private DAL db;

        public DBTaiXe()
        {
            db = new DAL();
        }

        // Lấy danh sách tài xế
        public DataTable LayTaiXe()
        {
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM vi_TaiXeView", db.getConnection))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy dữ liệu tài xế: " + ex.Message);
            }
            finally
            {
                db.closeConnection();
            }
            return dt;
        }

        // Thêm tài xế mới
        public bool ThemTaiXe(ref string err, string MaNhanVien, string HoTen, string CCCD, DateTime? NgaySinh,
                              string DiaChi, string MaGPLX, DateTime? NgayHetHan, DateTime? NgayThem,
                              string TinhTrang, string SDT, string TaiKhoan, string MatKhau)
        {
            try
            {
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand("spThemTaiXe", db.getConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                    cmd.Parameters.AddWithValue("@HoTen", HoTen);
                    cmd.Parameters.AddWithValue("@CCCD", CCCD);
                    cmd.Parameters.AddWithValue("@NgaySinh", (object)NgaySinh ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DiaChi", DiaChi);
                    cmd.Parameters.AddWithValue("@MaGPLX", MaGPLX);
                    cmd.Parameters.AddWithValue("@NgayHetHan", (object)NgayHetHan ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@NgayThem", (object)NgayThem ?? DBNull.Value);
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

        // Xóa tài xế theo mã nhân viên
        public bool XoaTaiXe(ref string err, string MaNhanVien)
        {
            try
            {
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand("spXoaTaiXe", db.getConnection))
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

        // Cập nhật thông tin tài xế
        public bool CapNhatTaiXe(ref string err, string MaNhanVien, string HoTen, string CCCD, DateTime? NgaySinh,
                                 string DiaChi, string MaGPLX, DateTime? NgayHetHan, DateTime? NgayThem,
                                 string TinhTrang, string SDT, string TaiKhoan, string MatKhau)
        {
            try
            {
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand("spCapNhatTaiXe", db.getConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                    cmd.Parameters.AddWithValue("@HoTen", HoTen);
                    cmd.Parameters.AddWithValue("@CCCD", CCCD);
                    cmd.Parameters.AddWithValue("@NgaySinh", (object)NgaySinh ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DiaChi", DiaChi);
                    cmd.Parameters.AddWithValue("@MaGPLX", MaGPLX);
                    cmd.Parameters.AddWithValue("@NgayHetHan", (object)NgayHetHan ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@NgayThem", (object)NgayThem ?? DBNull.Value);
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
        public DataTable LayTaiXeTheoMa(string maNV)
        {
            DataTable dt = new DataTable();

            try
            {
                db.openConnection();

                string sql = "EXEC LayTaiXeTheoMa @MaNhanVien";

                using (SqlCommand cmd = new SqlCommand(sql, db.getConnection))
                {
                    cmd.Parameters.AddWithValue("@MaNhanVien", maNV.Trim());

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy tài xế theo mã: " + ex.Message);
            }
            finally
            {
                db.closeConnection();
            }

            return dt;
        }
    }
}
