using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace DoAn_LTQL 
{
    public partial class FormThongKe : Form
    {
        public FormThongKe()
        {
            InitializeComponent();
        }
        private void VeBieuDo(DataTable data)
        {
            
            pnChart.Controls.Clear();

           
            Chart chartDoanhThu = new Chart();
            chartDoanhThu.Dock = DockStyle.Fill; 

         
            ChartArea chartArea = new ChartArea("MainArea");
            chartArea.AxisX.Title = "Ngày";
            chartArea.AxisY.Title = "Doanh Thu (VNĐ)";
            
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
            chartDoanhThu.ChartAreas.Add(chartArea);

           
            Series series = new Series("Doanh Thu");
            series.ChartType = SeriesChartType.Column;
            series.XValueMember = "Ngày";              
            series.YValueMembers = "Doanh Thu";        
            series.IsValueShownAsLabel = true;       
            series.Color = System.Drawing.Color.MediumSeaGreen; 

            
            chartDoanhThu.Series.Add(series);
            chartDoanhThu.DataSource = data;
            chartDoanhThu.DataBind();

           
            pnChart.Controls.Add(chartDoanhThu);
        }
        private void FormThongKe_Load(object sender, EventArgs e)
        {
      
            DateTime today = DateTime.Now;
            dtpTuNgay.Value = new DateTime(today.Year, today.Month, 1);
            dtpDenNgay.Value = today;

            btnThongKe_Click(sender, e);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            
            string tuNgay = dtpTuNgay.Value.ToString("yyyy-MM-dd");
            string denNgay = dtpDenNgay.Value.ToString("yyyy-MM-dd");

           
            string query = $"SELECT CAST(GioRa AS DATE) AS [Ngày], SUM(TongTien) AS [Doanh Thu] " +
                           $"FROM HoaDon " +
                           $"WHERE TrangThaiThanhToan = 1 AND GioRa >= '{tuNgay} 00:00:00' AND GioRa <= '{denNgay} 23:59:59' " +
                           $"GROUP BY CAST(GioRa AS DATE)";

            
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            dtgvDoanhThu.DataSource = data;

           
            double tongTien = 0;
            foreach (DataRow row in data.Rows)
            {
                tongTien += Convert.ToDouble(row["Doanh Thu"]);
            }
            txtTongDoanhThu.Text = tongTien.ToString("c", new System.Globalization.CultureInfo("vi-VN"));
            VeBieuDo(data);
        }
    }
}