using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DAL
    {
        // Chuỗi kết nối
        private string strCon = "Data Source=HUUVAN140225\\SQLEXPRESS;Initial Catalog=QuanLyDatXe;Integrated Security=True";

        // Đối tượng kết nối
        private SqlConnection sqlCon;

        // Constructor khởi tạo SqlConnection
        public DAL()
        {
            sqlCon = new SqlConnection(strCon);
        }

        // Lấy đối tượng kết nối
        public SqlConnection getConnection
        {
            get { return sqlCon; }
        }

        // 🔹 Đảm bảo phương thức này là `public`
        public void openConnection()
        {
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
        }

        // 🔹 Đảm bảo phương thức này là `public`
        public void closeConnection()
        {
            if (sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
            }
        }
    }
}
