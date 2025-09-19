using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFQLDatXeTrucTuyen
{
    public partial class FrmManHinhChinh : Form
    {
        bool sidebarExpand;
        bool NhanSuCollapsed;
        bool DatXeCollapsed;
        bool HoaDonCollapsed;

        private Button currentButton;
        private Random random;
        private int tempIndex;

        // Constructor mặc định
        public FrmManHinhChinh()
        {
            InitializeComponent();
            random = new Random();
            btnCloseChild.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[tempIndex];
            return ColorTranslator.FromHtml(color);
        }

        private void ActiveButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    panelTitleBar.BackColor = color;
                    buttonMENU.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnCloseChild.Visible = true;
                }
            }
        }

        private void DisableButton()
        {
            // Duyệt qua tất cả các control trong sidebarContainer
            foreach (Control control in sidebarContainer.Controls)
            {
                // Nếu control là Button thì đặt lại màu
                if (control is Button btn)
                {
                    btn.BackColor = Color.FromArgb(30, 40, 45);
                    btn.ForeColor = Color.Gainsboro;
                }
                // Nếu control là Panel, duyệt tiếp các control bên trong nó
                else if (control is Panel panel)
                {
                    foreach (Control subControl in panel.Controls)
                    {
                        if (subControl is Button subBtn)
                        {
                            subBtn.BackColor = Color.FromArgb(30, 40, 45);
                            subBtn.ForeColor = Color.Gainsboro;
                        }
                    }
                }
            }
        }


        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebarContainer.Width -= 10;
                if (sidebarContainer.Width == sidebarContainer.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                sidebarContainer.Width += 10;
                if (sidebarContainer.Width == sidebarContainer.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }
            }
        }

        private void buttonMENU_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void NhanSuTimer_Tick(object sender, EventArgs e)
        {
            if (NhanSuCollapsed)
            {
                NhanSuContainer.Height += 10;
                if (NhanSuContainer.Height == NhanSuContainer.MaximumSize.Height)
                {
                    NhanSuCollapsed = false;
                    NhanSuTimer.Stop();
                }
            }
            else
            {
                NhanSuContainer.Height -= 10;
                if (NhanSuContainer.Height == NhanSuContainer.MinimumSize.Height)
                {
                    NhanSuCollapsed = true;
                    NhanSuTimer.Stop();
                }
            }
        }

        private void Button_NhanSu_Click(object sender, EventArgs e)
        {
            NhanSuTimer.Start();
        }

        private void DatXeTimer_Tick(object sender, EventArgs e)
        {
            if (DatXeCollapsed)
            {
                DatXeContainer.Height += 10;
                if (DatXeContainer.Height == DatXeContainer.MaximumSize.Height)
                {
                    DatXeCollapsed = false;
                    DatXeTimer.Stop();
                }
            }
            else
            {
                DatXeContainer.Height -= 10;
                if (DatXeContainer.Height == DatXeContainer.MinimumSize.Height)
                {
                    DatXeCollapsed = true;
                    DatXeTimer.Stop();
                }
            }
        }

        private void Button_DatXe_Click(object sender, EventArgs e)
        {
            DatXeTimer.Start();
        }

        private void HoaDonTimer_Tick(object sender, EventArgs e)
        {
            if (HoaDonCollapsed)
            {
                HoaDonContainer.Height += 10;
                if (HoaDonContainer.Height == HoaDonContainer.MaximumSize.Height)
                {
                    HoaDonCollapsed = false;
                    HoaDonTimer.Stop();
                }
            }
            else
            {
                HoaDonContainer.Height -= 10;
                if (HoaDonContainer.Height == HoaDonContainer.MinimumSize.Height)
                {
                    HoaDonCollapsed = true;
                    HoaDonTimer.Stop();
                }
            }
        }

        private void Button_HoaDon_Click(object sender, EventArgs e)
        {
            HoaDonTimer.Start();
        }

        private Form currentFormChild;
        public void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_Body.Controls.Add(childForm);
            panel_Body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            labelTitle.Text = childForm.Text;
        }

        private void button_TaiXe_Click(object sender, EventArgs e)
        {
            ActiveButton(sender);
            OpenChildForm(new FrmTaiXe());
        }

        private void button_NhanVien_Click(object sender, EventArgs e)
        {
            ActiveButton(sender);
            OpenChildForm(new FrmNhanVien());
        }

        private void button_ThanhToan_Click(object sender, EventArgs e)
        {
            ActiveButton(sender);
            OpenChildForm(new FrmThanhToan());
        }

        private void button_KhuyenMai_Click(object sender, EventArgs e)
        {
            ActiveButton(sender);
            OpenChildForm(new FrmKhuyenMai());
        }

        private void button_XeKhach_Click(object sender, EventArgs e)
        {
            ActiveButton(sender);
            OpenChildForm(new FrmXeKhach());
        }

        private void button_TuyenXe_Click(object sender, EventArgs e)
        {
            ActiveButton(sender);
            OpenChildForm(new FrmTuyenDuong());
        }

        private void button_ChuyenXe_Click(object sender, EventArgs e)
        {
            ActiveButton(sender);
            OpenChildForm(new FrmChuyenXe());
        }

        private void button_KhachHang_Click(object sender, EventArgs e)
        {
            ActiveButton(sender);
            OpenChildForm(new FrmKhachHang());
        }
        private void Resert()
        {
            DisableButton();
            labelTitle.Text = "HOME";
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            buttonMENU.BackColor = Color.FromArgb(35, 40, 50);
            currentButton = null;
            btnCloseChild.Visible = false;

        }
        private void btnCloseChild_Click_1(object sender, EventArgs e)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            Resert();
        }

        private void btnCloseApp_Click_1(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đóng ứng dụng?",
                "Xác nhận đóng",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Button_Logout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide(); // Ẩn màn hình chính

                FrmLogin loginForm = new FrmLogin();
                loginForm.ShowDialog(); // Hiển thị lại màn hình đăng nhập

                this.Close();
            }
        }


        private void btn_Home_Click(object sender, EventArgs e)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            Resert();
        }

        private void btn_LichLamViec_Click(object sender, EventArgs e)
        {
            ActiveButton(sender);
            OpenChildForm(new FrmLichLamViec());
        }

        private void btn_DoanhThu_Click(object sender, EventArgs e)
        {
            ActiveButton(sender);
            OpenChildForm(new FrmDoanhThu());
        }
    }
}
