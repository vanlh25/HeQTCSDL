using BusinessAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace WFQLDatXeTrucTuyen
{
    public partial class FrmVe : Form
    {
        private DBVe dbVe;
        private DataTable dtVe;
        private string maChuyen;
        public FrmVe(string maChuyen)
        {
            InitializeComponent();
            dbVe = new DBVe();
            this.maChuyen = maChuyen;
        }
        private void dgvVe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvVe.Rows[e.RowIndex];
                row.Cells[0].Value.ToString(); // Mã Chuyến
                row.Cells[1].Value.ToString(); // Tên Tuyến
                row.Cells[2].Value.ToString(); // Mã Vé
                row.Cells[3].Value.ToString(); // Mã Đơn Hàng
                row.Cells[4].Value.ToString(); // Mã Khách
                row.Cells[5].Value.ToString(); // Tên Khách
                row.Cells[6].Value.ToString(); // Mã Ghế
                row.Cells[7].Value.ToString(); // Tên Ghế
                row.Cells[8].Value.ToString(); // Tình trạng}

            }
        }
        private void LoadData()
        {
            try
            {
                if (string.IsNullOrEmpty(maChuyen))
                {
                    MessageBox.Show("Mã chuyến không hợp lệ!");
                    return;
                }

                dtVe = dbVe.LayDanhSachVeTheoMaChuyen(maChuyen);
                dgvVe.DataSource = dtVe;
                if (dtVe.Rows.Count == 0)
                {
                    MessageBox.Show("Không có vé nào cho chuyến này!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu vé: " + ex.Message);
            }
        }
        private void FrmVe_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}




