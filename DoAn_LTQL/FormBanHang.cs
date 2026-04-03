using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
// Nhớ thêm thư viện này nếu máy báo gạch đỏ ở DataTable

namespace DoAn_LTQL // Sửa lại đúng tên namespace của bạn nhé
{
    public partial class FormBanHang : Form
    {
        public FormBanHang()
        {
            InitializeComponent();
        }

        private void FormBanHang_Load(object sender, EventArgs e)
        {
            LoadBan();
        }

        
        private void LoadBan()
        {
            flpBan.Controls.Clear();

            string query = "SELECT * FROM Ban";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
   
                Button btn = new Button() { Width = 90, Height = 90 };

               
                string tenBan = row["TenBan"].ToString();
                string trangThai = row["TrangThai"].ToString();
                int maBan = Convert.ToInt32(row["MaBan"]);

                
                btn.Text = tenBan + Environment.NewLine + trangThai;
                btn.Tag = maBan;

                //Đổi màu theo trạng thái
                if (trangThai == "Trống")
                {
                    btn.BackColor = Color.LightCyan; // Xanh lơ
                }
                else
                {
                    btn.BackColor = Color.LightPink; // Đỏ hồng
                }

                //Gắn sự kiện "Click" cho cái nút này
                btn.Click += btn_Click;

                // Thêm nút vừa tạo vào FlowLayoutPanel
                flpBan.Controls.Add(btn);
            }
        }

        // Hàm 1: Load toàn bộ Danh mục lên cái ComboBox đầu tiên
        private void LoadDanhMuc()
        {
            string query = "SELECT * FROM DanhMuc";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            cbDanhMuc.DataSource = data;
            cbDanhMuc.DisplayMember = "TenDanhMuc"; // Chữ để nhìn
            cbDanhMuc.ValueMember = "MaDanhMuc";    // Mã số ngầm bên trong
        }

        // Hàm 2: Lọc Thức uống theo đúng cái Mã Danh Mục
        private void LoadThucUongTheoID(int maDanhMuc)
        {
            // Câu lệnh SQL có thêm điều kiện WHERE để lọc
            string query = $"SELECT * FROM ThucUong WHERE MaDanhMuc = {maDanhMuc}";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            cbThucUong.DataSource = data;
            cbThucUong.DisplayMember = "TenThucUong";
            cbThucUong.ValueMember = "MaThucUong";
        }
        private void btn_Click(object sender, EventArgs e)
        {
            // Lấy cái mã bàn đang được giấu trong nút ra
            int maBan = Convert.ToInt32(((Button)sender).Tag);

            // Tạm thời hiện thông báo để test thử
            MessageBox.Show("Bạn vừa chọn bàn có mã số: " + maBan, "Test chức năng");
        }
    }
}