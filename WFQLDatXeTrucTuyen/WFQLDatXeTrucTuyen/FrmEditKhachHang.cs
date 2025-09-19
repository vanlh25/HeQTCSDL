using BusinessAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFQLDatXeTrucTuyen
{
    public partial class FrmEditKhachHang : Form
    {
        private string maKH;
        private DBKhachHang dbkh;

        public FrmEditKhachHang(string maKH)
        {
            InitializeComponent();
            this.maKH = maKH;
            dbkh = new DBKhachHang();
            this.Load += FrmSuaKhachHang_Load;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            this.btnHuyBo.Click += new System.EventHandler(this.btnHuy_Click);
            StartPosition = FormStartPosition.CenterScreen;
        }
        public FrmEditKhachHang()
        {
            InitializeComponent();
            dbkh = new DBKhachHang();
            this.Load += FrmThemKhachHang_Load;
            this.btnLuu.Click += btnThem_Click;
            this.btnHuyBo.Click += btnHuy_Click;
        }

        private void FrmSuaKhachHang_Load(object sender, EventArgs e)
        {
            LoadThongTinKhachHang();
        }
        private void FrmThemKhachHang_Load(object sender, EventArgs e)
        {
            txt_MaKhach.Enabled = true; 
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string err = "";
            bool result;

            if (string.IsNullOrWhiteSpace(txt_MaKhach.Text) ||
                string.IsNullOrWhiteSpace(txt_TenKhach.Text) ||
                string.IsNullOrWhiteSpace(date_NgaySinh.Text) ||
                string.IsNullOrWhiteSpace(txt_DiaChi.Text) ||
                string.IsNullOrWhiteSpace(txt_CCCD.Text) ||
                string.IsNullOrWhiteSpace(txt_Email.Text) ||
                string.IsNullOrWhiteSpace(txt_SDT.Text)
                )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            else
            {
                result = dbkh.ThemKhachHang(ref err,
                        this.txt_MaKhach.Text,
                        this.txt_TenKhach.Text,
                        this.date_NgaySinh.Value,
                        this.txt_DiaChi.Text,
                        this.txt_CCCD.Text,
                        this.txt_Email.Text,
                        this.txt_SDT.Text);
            }

            if (result)
            {
                MessageBox.Show("Thêm mới khách hàng thành công!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Lỗi khi thêm: " + err);
            }
        }
        private void LoadThongTinKhachHang()
        {
            try
            {
                DataTable dt = dbkh.LayKhachHangTheoMa(maKH);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txt_MaKhach.Text = row["MaKhach"].ToString();
                    txt_TenKhach.Text = row["TenKhach"].ToString();
                    date_NgaySinh.Value = Convert.ToDateTime(row["NgaySinh"]);
                    txt_DiaChi.Text = row["DiaChi"].ToString();
                    txt_CCCD.Text = row["CCCD"].ToString();
                    txt_Email.Text = row["Email"].ToString();
                    txt_SDT.Text = row["SDT"].ToString();
                    txt_MaKhach.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin: " + ex.Message);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string err = "";
            bool result;

            if (string.IsNullOrWhiteSpace(txt_MaKhach.Text) ||
                string.IsNullOrWhiteSpace(txt_TenKhach.Text) ||
                string.IsNullOrWhiteSpace(date_NgaySinh.Text) ||
                string.IsNullOrWhiteSpace(txt_DiaChi.Text) ||
                string.IsNullOrWhiteSpace(txt_CCCD.Text) ||
                string.IsNullOrWhiteSpace(txt_Email.Text) ||
                string.IsNullOrWhiteSpace(txt_SDT.Text)
                )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            else
            {
                result = dbkh.CapNhatKhachHang(ref err,
                        this.txt_MaKhach.Text,
                        this.txt_TenKhach.Text,
                        this.date_NgaySinh.Value,
                        this.txt_DiaChi.Text,
                        this.txt_CCCD.Text,
                        this.txt_Email.Text,
                        this.txt_SDT.Text);
            }

            if (result)
            {
                MessageBox.Show("Cập nhật thành công!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Lỗi: " + err);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
