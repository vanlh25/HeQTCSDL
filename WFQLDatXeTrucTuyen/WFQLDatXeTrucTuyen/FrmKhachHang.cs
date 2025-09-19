using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BusinessAccessLayer;
namespace WFQLDatXeTrucTuyen
{
    public partial class FrmKhachHang : Form
    {
        private DBKhachHang dbkh;
        private DataTable dtKhachHang;
        private bool Them;
        public FrmKhachHang()
        {
            InitializeComponent();
            dbkh = new DBKhachHang();

            txtTimKiem.GotFocus += RemoveText;
            txtTimKiem.LostFocus += AddText;
        }
        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            dgvKhachHang.CellClick -= dgvKhachHang_CellClick;
            dgvKhachHang.CellClick += dgvKhachHang_CellClick;
            LoadData();

        }
        private void ToggleControls(bool isEditing)
        {
            btnThem.Enabled = !isEditing;
            btnReload.Enabled = !isEditing;
        }

        private void LoadData()
        {
            try
            {
                dtKhachHang = dbkh.LayKhachHang();
                dgvKhachHang.DataSource = dtKhachHang;
                //ResetFields();
                ToggleControls(false);
                // Format DataGridView
                dgvKhachHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvKhachHang.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvKhachHang.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvKhachHang.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                dgvKhachHang.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dgvKhachHang.RowTemplate.Height = 30;
                dgvKhachHang.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dgvKhachHang.AllowUserToAddRows = false;
                dgvKhachHang.ReadOnly = true;
                dgvKhachHang.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }
        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string colName = dgvKhachHang.Columns[e.ColumnIndex].Name;
            }
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {

            ToggleControls(true);
            LoadData();
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            FrmEditKhachHang frmThem = new FrmEditKhachHang();
            frmThem.ShowDialog();
            LoadData(); // Reload lại danh sách sau khi thêm
        }


        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            //ResetFields();
            ToggleControls(false);
        }

        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Chuỗi kết nối tới database
                string connectionString = "Data Source=HUUVAN140225\\SQLEXPRESS;Initial Catalog=QuanLyDatXe;Integrated Security=True";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Tạo command gọi function SQL
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.SearchKhachHangByKeyword(@Keyword)", conn))
                    {
                        // Lấy giá trị từ textbox tìm kiếm
                        string keyword = txtTimKiem.Text.Trim();

                        // Thêm tham số
                        cmd.Parameters.AddWithValue("@Keyword", keyword);

                        // Sử dụng SqlDataAdapter để điền dữ liệu vào DataTable
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            // Gán kết quả vào DataGridView
                            dgvKhachHang.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }

        public void RemoveText(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "Search")
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = Color.Black;
            }
        }

        public void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                txtTimKiem.Text = "Search";
                txtTimKiem.ForeColor = Color.Gray;
            }
        }
    }
}
