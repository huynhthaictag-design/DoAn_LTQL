using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DoAn_LTQL
{
    public partial class FormBanHang : Form
    {
        private int idBanHienTai = -1;
        public FormBanHang()
        {
            InitializeComponent();
        }

        private void FormBanHang_Load(object sender, EventArgs e)
        {
         
            LoadBan();
            LoadDanhMuc();
        }

        // ================= KHU VỰC 1: SƠ ĐỒ BÀN =================
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

             
                if (trangThai == "Trống")
                {
                    btn.BackColor = Color.LightCyan; // Xanh lơ
                }
                else
                {
                    btn.BackColor = Color.LightPink; // Đỏ hồng
                }

          
                btn.Click += btn_Click;

                flpBan.Controls.Add(btn);
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            int maBan = Convert.ToInt32(((Button)sender).Tag);
            idBanHienTai = maBan;
            ShowBill(maBan);
        }

        // ================= KHU VỰC 2: HIỂN THỊ HÓA ĐƠN =================
        private void ShowBill(int idBan)
        {
            lsvBill.Items.Clear();
            float tongTien = 0;

            string query = $"SELECT t.TenThucUong, c.SoLuong, c.DonGia, c.SoLuong * c.DonGia AS ThanhTien " +
                           $"FROM ChiTietHoaDon c " +
                           $"JOIN HoaDon h ON c.MaHoaDon = h.MaHoaDon " +
                           $"JOIN ThucUong t ON c.MaThucUong = t.MaThucUong " +
                           $"WHERE h.MaBan = {idBan} AND h.TrangThaiThanhToan = 0";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                ListViewItem lsvItem = new ListViewItem(row["TenThucUong"].ToString());

                lsvItem.SubItems.Add(row["SoLuong"].ToString());
                lsvItem.SubItems.Add(row["DonGia"].ToString());
                lsvItem.SubItems.Add(row["ThanhTien"].ToString());

                lsvBill.Items.Add(lsvItem);

                tongTien += Convert.ToSingle(row["ThanhTien"]);
            }

          
            txtTongTien.Text = tongTien.ToString("c", new System.Globalization.CultureInfo("vi-VN"));
        }

        // ================= KHU VỰC 3: XỬ LÝ MENU GỌI MÓN =================
        private void LoadDanhMuc()
        {
            string query = "SELECT * FROM DanhMuc";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            cbDanhMuc.DataSource = data;
            cbDanhMuc.DisplayMember = "TenDanhMuc";
            cbDanhMuc.ValueMember = "MaDanhMuc";
        }

        private void LoadThucUongTheoID(int maDanhMuc)
        {
            string query = $"SELECT * FROM ThucUong WHERE MaDanhMuc = {maDanhMuc}";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            cbThucUong.DataSource = data;
            cbThucUong.DisplayMember = "TenThucUong";
            cbThucUong.ValueMember = "MaThucUong";
        }

        private void cbDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null) return;

            try
            {
                int id = Convert.ToInt32(cb.SelectedValue);
                LoadThucUongTheoID(id);
            }
            catch { }
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
       
            if (idBanHienTai == -1)
            {
                MessageBox.Show("Khoan đã! Bạn phải click chọn một cái bàn bên trái trước khi gọi món nhé.", "Nhắc nhở nhẹ");
                return;
            }

            int idThucUong = Convert.ToInt32(cbThucUong.SelectedValue);
            int soLuong = (int)nmSoLuong.Value;

            if (soLuong == 0) return; 

         
       
            string queryCheckBill = $"SELECT MaHoaDon FROM HoaDon WHERE MaBan = {idBanHienTai} AND TrangThaiThanhToan = 0";
            DataTable dtBill = DataProvider.Instance.ExecuteQuery(queryCheckBill);

            int idHoaDon = -1;

            if (dtBill.Rows.Count > 0)
            {
              
                idHoaDon = Convert.ToInt32(dtBill.Rows[0]["MaHoaDon"]);
            }
            else
            {
               
                DataProvider.Instance.ExecuteNonQuery($"INSERT INTO HoaDon (MaBan, TrangThaiThanhToan, GioVao) VALUES ({idBanHienTai}, 0, GETDATE())");

           
                idHoaDon = Convert.ToInt32(DataProvider.Instance.ExecuteQuery("SELECT MAX(MaHoaDon) FROM HoaDon").Rows[0][0]);

              
                DataProvider.Instance.ExecuteNonQuery($"UPDATE Ban SET TrangThai = N'Có người' WHERE MaBan = {idBanHienTai}");
            }

           
            string queryCheckChiTiet = $"SELECT * FROM ChiTietHoaDon WHERE MaHoaDon = {idHoaDon} AND MaThucUong = {idThucUong}";
            DataTable dtChiTiet = DataProvider.Instance.ExecuteQuery(queryCheckChiTiet);

            if (dtChiTiet.Rows.Count > 0)
            {
               
                DataProvider.Instance.ExecuteNonQuery($"UPDATE ChiTietHoaDon SET SoLuong = SoLuong + {soLuong} WHERE MaHoaDon = {idHoaDon} AND MaThucUong = {idThucUong}");
            }
            else
            {
              
                float donGia = Convert.ToSingle(DataProvider.Instance.ExecuteQuery($"SELECT GiaBan FROM ThucUong WHERE MaThucUong = {idThucUong}").Rows[0][0]);
                DataProvider.Instance.ExecuteNonQuery($"INSERT INTO ChiTietHoaDon (MaHoaDon, MaThucUong, SoLuong, DonGia) VALUES ({idHoaDon}, {idThucUong}, {soLuong}, {donGia})");
            }

          
            ShowBill(idBanHienTai); 
            LoadBan();           
            nmSoLuong.Value = 1;  
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            
            if (idBanHienTai == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn cần thanh toán!", "Nhắc nhở nhẹ");
                return;
            }

           
            string queryCheckBill = $"SELECT MaHoaDon FROM HoaDon WHERE MaBan = {idBanHienTai} AND TrangThaiThanhToan = 0";
            DataTable dtBill = DataProvider.Instance.ExecuteQuery(queryCheckBill);

          
            if (dtBill.Rows.Count == 0)
            {
                MessageBox.Show("Bàn này đang trống hoặc chưa gọi món nào!", "Thông báo");
                return;
            }

            int idHoaDon = Convert.ToInt32(dtBill.Rows[0]["MaHoaDon"]);
            int giamGia = (int)nmGiamGia.Value; 

          
            double tongTien = 0;
            foreach (ListViewItem item in lsvBill.Items)
            {
                tongTien += Convert.ToDouble(item.SubItems[3].Text);
            }

         
            double tongTienCuoiCung = tongTien - (tongTien / 100 * giamGia);

         
            string thongBao = $"Bạn có chắc chắn thanh toán hóa đơn cho bàn này không?\n\n- Tổng tiền: {tongTien} đ\n- Giảm giá: {giamGia}%\n\n=> KHÁCH PHẢI TRẢ: {tongTienCuoiCung} đ";

            if (MessageBox.Show(thongBao, "Xác nhận thanh toán", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
              
                string queryUpdateBill = $"UPDATE HoaDon SET TrangThaiThanhToan = 1, GioRa = GETDATE(), GiamGia = {giamGia}, TongTien = {tongTienCuoiCung} WHERE MaHoaDon = {idHoaDon}";
                DataProvider.Instance.ExecuteNonQuery(queryUpdateBill);

            
                string queryUpdateBan = $"UPDATE Ban SET TrangThai = N'Trống' WHERE MaBan = {idBanHienTai}";
                DataProvider.Instance.ExecuteNonQuery(queryUpdateBan);

               
                ShowBill(idBanHienTai);     
                LoadBan();                  
                nmGiamGia.Value = 0;        

                MessageBox.Show("Thanh toán thành công! Tiền đã vào két.", "Chốt sổ");
            }
        }
    }
}