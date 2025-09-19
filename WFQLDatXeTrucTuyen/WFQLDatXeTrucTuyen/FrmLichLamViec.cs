using BusinessAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFQLDatXeTrucTuyen
{
    public partial class FrmLichLamViec : Form
    {
        private DBChuyenXe dbChuyenXe;

        public FrmLichLamViec()
        {
            InitializeComponent();
            dbChuyenXe = new DBChuyenXe();
            LoadDataGridView();
            LoadTheme();
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

            txt_MaKhachHang.GotFocus += RemoveText;
            txt_MaKhachHang.LostFocus += AddText;
        }
        public void RemoveText(object sender, EventArgs e)
        {
            if (txt_MaKhachHang.Text == "Search")
            {
                txt_MaKhachHang.Text = "";
                txt_MaKhachHang.ForeColor = Color.Black;
            }
        }

        public void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_MaKhachHang.Text))
            {
                txt_MaKhachHang.Text = "Search";
                txt_MaKhachHang.ForeColor = Color.Gray;
            }
        }
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
        }
        private void LoadDataGridView()
        {
            try
            {
                // Lấy dữ liệu từ DBChuyenXe
                DataTable dt = dbChuyenXe.GetChuyenXeInfo();

                // Kiểm tra nếu không có dữ liệu
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị.");
                    return;
                }

                // Gán dữ liệu vào DataGridView
                dataGridViewChuyenXe.DataSource = dt;

                // Đặt tiêu đề cho các cột
                dataGridViewChuyenXe.Columns["MaXeKhach"].HeaderText = "Mã Xe Khách";
                dataGridViewChuyenXe.Columns["TenTaiXe"].HeaderText = "Tên Tài Xế";
                dataGridViewChuyenXe.Columns["TenPhuXe"].HeaderText = "Tên Phụ Xe";
                dataGridViewChuyenXe.Columns["TenTuyen"].HeaderText = "Tên Tuyến";
                dataGridViewChuyenXe.Columns["ThoiGianXP"].HeaderText = "Thời Gian Xuất Phát";

                // Format DataGridView
                dataGridViewChuyenXe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewChuyenXe.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewChuyenXe.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewChuyenXe.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                dataGridViewChuyenXe.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dataGridViewChuyenXe.RowTemplate.Height = 30;
                dataGridViewChuyenXe.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dataGridViewChuyenXe.AllowUserToAddRows = false;
                dataGridViewChuyenXe.ReadOnly = true;
                dataGridViewChuyenXe.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;



                // Tùy chỉnh định dạng cột ThoiGianXP
                dataGridViewChuyenXe.Columns["ThoiGianXP"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadDataGridView();
        }

        private void TimKiem()
        {
            try
            {
                string connectionString = "Data Source=HUUVAN140225\\SQLEXPRESS;Initial Catalog=QuanLyDatXe;Integrated Security=True";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.SearchLTByKeyword(@Keyword)", conn))
                    {
                        string keyword = txt_MaKhachHang.Text.Trim();
                        cmd.Parameters.AddWithValue("@Keyword", keyword);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridViewChuyenXe.DataSource = dt;
                            // Đặt tiêu đề cho các cột
                            dataGridViewChuyenXe.Columns["MaXeKhach"].HeaderText = "Mã Xe Khách";
                            dataGridViewChuyenXe.Columns["TenTaiXe"].HeaderText = "Tên Tài Xế";
                            dataGridViewChuyenXe.Columns["TenPhuXe"].HeaderText = "Tên Phụ Xe";
                            dataGridViewChuyenXe.Columns["TenTuyen"].HeaderText = "Tên Tuyến";
                            dataGridViewChuyenXe.Columns["ThoiGianXP"].HeaderText = "Thời Gian Xuất Phát";

                            // Format DataGridView
                            dataGridViewChuyenXe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                            dataGridViewChuyenXe.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            dataGridViewChuyenXe.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            dataGridViewChuyenXe.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                            dataGridViewChuyenXe.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                            dataGridViewChuyenXe.RowTemplate.Height = 30;
                            dataGridViewChuyenXe.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                            dataGridViewChuyenXe.AllowUserToAddRows = false;
                            dataGridViewChuyenXe.ReadOnly = true;
                            dataGridViewChuyenXe.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;



                            // Tùy chỉnh định dạng cột ThoiGianXP
                            dataGridViewChuyenXe.Columns["ThoiGianXP"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TimKiem();
        }
    }
}
