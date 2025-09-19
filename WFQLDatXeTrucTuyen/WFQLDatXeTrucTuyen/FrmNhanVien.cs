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
    public partial class FrmNhanVien : Form
    {
        private DBNhanVien dbnv;
        private DataTable dtNhanVien;
        private bool Them;
        public FrmNhanVien()
        {
            InitializeComponent();
            dbnv = new DBNhanVien();
            txtTimKiem.GotFocus += RemoveText;
            txtTimKiem.LostFocus += AddText;
        }
        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            dgvNhanVien.CellClick -= dgvNhanVien_CellClick;
            dgvNhanVien.CellClick += dgvNhanVien_CellClick;
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                dtNhanVien = dbnv.LayNhanVien();
                dgvNhanVien.DataSource = dtNhanVien;

                // Format DataGridView
                dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvNhanVien.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvNhanVien.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvNhanVien.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                dgvNhanVien.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dgvNhanVien.RowTemplate.Height = 30;
                dgvNhanVien.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dgvNhanVien.AllowUserToAddRows = false;
                dgvNhanVien.ReadOnly = true;
                dgvNhanVien.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

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
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string colName = dgvNhanVien.Columns[e.ColumnIndex].Name;

                if (colName == "Edit" || colName == "Delete")
                {
                    var cell = dgvNhanVien.Rows[e.RowIndex].Cells["MaNhanVien"];
                    if (cell == null || cell.Value == null)
                    {
                        MessageBox.Show("Không lấy được mã nhân viên.");
                        return;
                    }

                    string maNhanVien = cell.Value.ToString();

                    if (colName == "Edit")
                    {
                        FrmEditNhanVien frmSua = new FrmEditNhanVien(maNhanVien);
                        frmSua.ShowDialog();
                        LoadData(); // reload sau khi sửa
                    }
                    else if (colName == "Delete")
                    {
                        colName = "";
                        if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            string err = "";
                            if (dbnv.XoaNhanVien(ref err, maNhanVien))
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
            FrmEditNhanVien frmThem = new FrmEditNhanVien();
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
            if (dgvNhanVien.Columns.Contains("Edit"))
                dgvNhanVien.Columns.Remove("Edit");
            if (dgvNhanVien.Columns.Contains("Delete"))
                dgvNhanVien.Columns.Remove("Delete");

            // Thêm nút Sửa
            DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
            editButton.Name = "Edit";
            editButton.HeaderText = "";
            editButton.Text = "Sửa";
            editButton.UseColumnTextForButtonValue = true;
            dgvNhanVien.Columns.Add(editButton);

            // Thêm nút Xóa
            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "Delete";
            deleteButton.HeaderText = "";
            deleteButton.Text = "Xóa";
            deleteButton.UseColumnTextForButtonValue = true;
            dgvNhanVien.Columns.Add(deleteButton);
        }
        private void TimKiem()
        {
            try
            {
                string connectionString = "Data Source=HUUVAN140225\\SQLEXPRESS;Initial Catalog=QuanLyDatXe;Integrated Security=True";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.SearchNhanVienByKeyword(@Keyword)", conn))
                    {
                        string keyword = txtTimKiem.Text.Trim();
                        cmd.Parameters.AddWithValue("@Keyword", keyword);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvNhanVien.DataSource = dt;
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
