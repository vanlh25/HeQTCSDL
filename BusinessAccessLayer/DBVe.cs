using DataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BusinessAccessLayer
{
    public class DBVe
    {
        private DAL db; // Đối tượng DAL

        public DBVe()
        {
            db = new DAL();
        }

        public DataTable LayDanhSachVe()
        {
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();
                string query = "SELECT * FROM View_DanhSachVe";
                using (SqlCommand cmd = new SqlCommand(query, db.getConnection))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách vé: " + ex.Message);
            }
            finally
            {
                db.closeConnection();
            }
            return dt;
        }

        public DataTable LayDanhSachVeTheoMaChuyen(string maChuyen)
        {
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();
                string sql = "EXEC LayDanhSachVeTheoMaChuyen @MaChuyen"; // Gọi stored procedure
                using (SqlCommand cmd = new SqlCommand(sql, db.getConnection))
                {
                    cmd.Parameters.AddWithValue("@MaChuyen", maChuyen.Trim());
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách vé theo mã chuyến: " + ex.Message);
            }
            finally
            {
                db.closeConnection();
            }
            return dt;
        }
    }
}
