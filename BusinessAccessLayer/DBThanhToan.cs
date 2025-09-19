using DataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BusinessAccessLayer
{
    public class DBThanhToan
    {
        private DAL db; // Đối tượng DAL
        public DBThanhToan()
        {
            db = new DAL();
        }
        public DataTable LayThanhToan()
        {
            DataTable dt = new DataTable();
            try
            {
                db.openConnection(); // Mở kết nối
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM View_ThongTinThanhToan", db.getConnection))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy dữ liệu thanh toán: " + ex.Message);
            }
            finally
            {
                db.closeConnection(); // Đóng kết nối
            }
            return dt;
        }
        public DataTable GetRevenueByRoute()
        {
                DataTable dt = new DataTable();
                try
                {
                    db.openConnection();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM GetRevenueByRoute()", db.getConnection))
                    {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    }    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi lấy dữ liệu thanh toán: " + ex.Message);
                }
                finally
                {
                    db.closeConnection(); // Đóng kết nối
                }
                return dt;
        }
        public DataTable GetRevenueByPaymentMethod()
        {
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM GetRevenueByPaymentMethod()", db.getConnection))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy dữ liệu thanh toán: " + ex.Message);
            }
            finally
            {
                db.closeConnection(); // Đóng kết nối
            }
            return dt;
        }
        public DataTable GetRevenueByMonth()
        {
            DataTable dt = new DataTable();
            try
            {
                db.openConnection();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM GetRevenueByMonth()", db.getConnection))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy dữ liệu thanh toán: " + ex.Message);
            }
            finally
            {
                db.closeConnection(); // Đóng kết nối
            }
            return dt;
        }
    }
}
