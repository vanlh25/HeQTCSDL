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
using System.Windows.Forms.DataVisualization.Charting;

namespace WFQLDatXeTrucTuyen
{
    public partial class FrmDoanhThu : Form
    {
        DBThanhToan dbtt;
        public FrmDoanhThu()
        {
            InitializeComponent();
            dbtt = new DBThanhToan();
            SetupComboBox();
            LoadPieChart();
        }
        private void SetupComboBox()
        {
            comboBoxChartType.Items.AddRange(new string[]
            {
                "Doanh thu theo phương thức thanh toán",
                "Doanh thu theo từng tuyến xe",
                "Doanh thu theo tháng"
            });
            comboBoxChartType.SelectedIndex = 0;
        }
        private void comboBoxChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPieChart();
        }
        private void FrmDoanhThu_Load(object sender, EventArgs e)
        {

        }
        private void LoadPieChart()
        {
            try
            {
                if (chart1 == null)
                {
                    MessageBox.Show("Chart1 chưa được khởi tạo. Vui lòng kiểm tra designer.");
                    return;
                }

                DataTable dt;
                string chartTitle;
                string labelField;

                // Chọn dữ liệu dựa trên lựa chọn trong ComboBox
                int selectedIndex = comboBoxChartType.SelectedIndex;
                switch (selectedIndex)
                {
                    case 0: // Doanh thu theo phương thức thanh toán
                        dt = dbtt.GetRevenueByPaymentMethod();
                        chartTitle = "Thống kê doanh thu theo phương thức thanh toán";
                        labelField = "PhuongThuc";
                        break;

                    case 1: // Doanh thu theo tuyến xe
                        dt = dbtt.GetRevenueByRoute();
                        chartTitle = "Thống kê doanh thu theo tuyến xe";
                        labelField = "TenTuyen";
                        break;
                    case 2: // Doanh thu theo tháng
                        dt = dbtt.GetRevenueByMonth();
                        chartTitle = "Thống kê doanh thu theo tháng";
                        labelField = "Thang";
                        break;

                    default:
                        return;
                }

                // Kiểm tra nếu dt là null hoặc không có dữ liệu
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị biểu đồ.");
                    chart1.Series.Clear();
                    chart1.Legends.Clear();
                    chart1.Titles.Clear();
                    return;
                }

                // Kiểm tra cột tồn tại
                if (!dt.Columns.Contains("TongDoanhThu") || !dt.Columns.Contains(labelField))
                {
                    MessageBox.Show($"Dữ liệu trả về không chứa cột 'TongDoanhThu' hoặc '{labelField}'.");
                    return;
                }

                // Xóa các series và legends cũ để tránh trùng lặp
                chart1.Series.Clear();
                chart1.Legends.Clear();

                // Thêm tiêu đề cho biểu đồ
                chart1.Titles.Clear();
                chart1.Titles.Add(chartTitle);

                // Tạo series mới
                Series series = chart1.Series.Add("DoanhThu");
                series.ChartType = SeriesChartType.Pie;

                // Tính tổng doanh thu để tính phần trăm
                double totalRevenue = 0;
                foreach (DataRow row in dt.Rows)
                {
                    totalRevenue += Convert.ToDouble(row["TongDoanhThu"]);
                }

                // Danh sách màu sắc
                Color[] colors = new Color[]
                {
                    Color.Green,
                    Color.Blue,
                    Color.Orange,
                    Color.Red,
                    Color.Purple,
                    Color.Cyan,
                    Color.Magenta
                };

                // Thêm dữ liệu vào biểu đồ và gán màu
                int colorIndex = 0;
                foreach (DataRow row in dt.Rows)
                {
                    string labelValue = row[labelField].ToString();
                    double tongDoanhThu = Convert.ToDouble(row["TongDoanhThu"]);

                    // Tính phần trăm
                    double percentage = (tongDoanhThu / totalRevenue) * 100;

                    // Thêm điểm dữ liệu
                    DataPoint point = series.Points.Add(tongDoanhThu);
                    point.Label = $"{labelValue}: {percentage:F1}%";
                    point.LegendText = labelValue;

                    // Gán màu
                    if (selectedIndex == 0) // Doanh thu theo phương thức thanh toán
                    {
                        switch (labelValue)
                        {
                            case "Tiền mặt":
                                point.Color = Color.Green;
                                break;
                            case "Chuyển khoản":
                                point.Color = Color.Blue;
                                break;
                            case "Ví điện tử":
                                point.Color = Color.Orange;
                                break;
                            default:
                                point.Color = colors[colorIndex % colors.Length];
                                break;
                        }
                    }
                    else // Doanh thu theo tuyến xe
                    {
                        point.Color = colors[colorIndex % colors.Length];
                    }
                    colorIndex++;
                }

                // Tùy chỉnh nhãn và legend
                series["PieLabelStyle"] = "Outside";
                series["PieLineColor"] = "Black";
                chart1.Legends.Add(new Legend("Legend1"));
                chart1.Legends[0].Enabled = true;
                chart1.Legends[0].Docking = Docking.Right;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi vẽ biểu đồ: " + ex.Message);
            }
        }

    }
}
