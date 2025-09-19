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
using BusinessAccessLayer;
using DataAccessLayer;

namespace WFQLDatXeTrucTuyen
{
    public partial class FrmTaiXe : Form
    {
        private DBTaiXe dbtx;
        private DataTable dtTaiXe;
        private bool Them;
        public FrmTaiXe()
        {
            InitializeComponent();
            dbtx = new DBTaiXe();
            txtTimKiem.GotFocus += RemoveText;
            txtTimKiem.LostFocus += AddText;
        }

        private void FrmTaiXe_Load_1(object sender, EventArgs e)
        {
            dgvTaiXe.CellClick -= dgvTaiXe_CellClick;
            dgvTaiXe.CellClick += dgvTaiXe_CellClick;
            LoadData();

        }
        private void LoadData()
        {
            try
            {
                dtTaiXe = dbtx.LayTaiXe();
                dgvTaiXe.DataSource = dtTaiXe;

                // Format DataGridView
                dgvTaiXe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvTaiXe.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvTaiXe.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvTaiXe.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                dgvTaiXe.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dgvTaiXe.RowTemplate.Height = 30;
                dgvTaiXe.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dgvTaiXe.AllowUserToAddRows = false;
                dgvTaiXe.ReadOnly = true;
                dgvTaiXe.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

                AddButtonColumns();


                ToggleControls(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }
        private void ToggleControls(bool isEditing)
        {

            btnThem.Enabled = !isEditing;
            btnReLoad.Enabled = !isEditing;
        }
        private void dgvTaiXe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string colName = dgvTaiXe.Columns[e.ColumnIndex].Name;

                if (colName == "Edit" || colName == "Delete")
                {
                    var cell = dgvTaiXe.Rows[e.RowIndex].Cells["MaNhanVien"];
                    if (cell == null || cell.Value == null)
                    {
                        MessageBox.Show("Không lấy được mã nhân viên.");
                        return;
                    }

                    string maNhanVien = cell.Value.ToString();

                    if (colName == "Edit")
                    {
                        FrmEditTaiXe frmSua = new FrmEditTaiXe(maNhanVien);
                        frmSua.ShowDialog();
                        LoadData(); // reload sau khi sửa
                    }
                    else if (colName == "Delete")
                    {
                        if (MessageBox.Show("Bạn có chắc chắn muốn xóa tài xế này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            string err = "";
                            if (dbtx.XoaTaiXe(ref err, maNhanVien))
                            {
                                MessageBox.Show("Xóa thành công!");
                                LoadData();
                            }
                            else
                            {
                                MessageBox.Show("Lỗi khi xóa: " + err);
                            }
                        }
                    }
                }
            }
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            ToggleControls(true);
            LoadData();
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            FrmEditTaiXe frmThem = new FrmEditTaiXe();
            frmThem.ShowDialog();
            LoadData(); // Reload lại danh sách sau khi thêm
        }


        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            //ResetFields();
            ToggleControls(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            Them = false;
            ToggleControls(true);
        }

        private void AddButtonColumns()
        {
            //  XÓA CÁC CỘT NÚT NẾU ĐÃ CÓ
            if (dgvTaiXe.Columns.Contains("Edit"))
                dgvTaiXe.Columns.Remove("Edit");
            if (dgvTaiXe.Columns.Contains("Delete"))
                dgvTaiXe.Columns.Remove("Delete");

            // Thêm nút Sửa
            DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
            editButton.Name = "Edit";
            editButton.HeaderText = "";
            editButton.Text = "Sửa";
            editButton.UseColumnTextForButtonValue = true;
            dgvTaiXe.Columns.Add(editButton);

            // Thêm nút Xóa
            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "Delete";
            deleteButton.HeaderText = "";
            deleteButton.Text = "Xóa";
            deleteButton.UseColumnTextForButtonValue = true;
            dgvTaiXe.Columns.Add(deleteButton);
        }

        private void TimKiem()
        {
            try
            {
                string connectionString = "Data Source=HUUVAN140225\\SQLEXPRESS;Initial Catalog=QuanLyDatXe;Integrated Security=True";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.SearchTaiXeByKeyword(@Keyword)", conn))
                    {
                        string keyword = txtTimKiem.Text.Trim();
                        cmd.Parameters.AddWithValue("@Keyword", keyword);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvTaiXe.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }
        }

        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {
            TimKiem();
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
