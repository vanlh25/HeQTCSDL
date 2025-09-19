using BusinessAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WFQLDatXeTrucTuyen
{
    public partial class FrmThanhToan : Form
    {
        private DBThanhToan dbThanhToan;
        private DataTable dtThanhToan;
        public FrmThanhToan()
        {
            InitializeComponent();
            dbThanhToan = new DBThanhToan();
            txt_MaKhachHang.GotFocus += RemoveText;
            txt_MaKhachHang.LostFocus += AddText;
        }
        private void LoadData()
        {
            try
            {
                DataTable dt = dbThanhToan.LayThanhToan();
                dgvThanhToan.DataSource = dt;

                // Format DataGridView
                dgvThanhToan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvThanhToan.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvThanhToan.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvThanhToan.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                dgvThanhToan.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dgvThanhToan.RowTemplate.Height = 30;
                dgvThanhToan.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dgvThanhToan.AllowUserToAddRows = false;
                dgvThanhToan.ReadOnly = true;
                dgvThanhToan.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FrmThanhToan_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvThanhToan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvThanhToan.Rows[e.RowIndex];
                row.Cells[0].Value.ToString(); // Mã Thanh Toán
                row.Cells[1].Value.ToString(); // Mã Đơn Hàng
                row.Cells[2].Value.ToString(); // Mã Khách Hàng
                row.Cells[3].Value.ToString(); // Tên KH
                row.Cells[4].Value.ToString(); // Mã KM
                row.Cells[5].Value.ToString(); // Phương thức
                row.Cells[6].Value.ToString(); // Tổng tiền
                row.Cells[7].Value.ToString(); // Ngày thanh toán
            }
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        //  XỬ LÝ NÚT "SEARCH"
        private void TimKiemTheoMaKhachHang(string maKhachHang)
        {
            try
            {
                string connectionString = "Data Source=HUUVAN140225\\SQLEXPRESS;Initial Catalog=QuanLyDatXe;Integrated Security=True";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.SearchThanhToanByMaKhachHang(@MaKhachHang)", conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKhachHang", maKhachHang);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvThanhToan.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }
        private void btn_Search_Click(object sender, EventArgs e)
        {
            TimKiemTheoMaKhachHang(txt_MaKhachHang.Text.Trim());
        }
        public void RemoveText(object sender, EventArgs e)
        {
            if (txt_MaKhachHang.Text == "Nhập mã khách hàng")
            {
                txt_MaKhachHang.Text = "";
                txt_MaKhachHang.ForeColor = Color.Black;
            }
        }

        public void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_MaKhachHang.Text))
            {
                txt_MaKhachHang.Text = "Nhập mã khách hàng";
                txt_MaKhachHang.ForeColor = Color.Gray;
            }
        }

        private void txt_MaKhachHang_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
