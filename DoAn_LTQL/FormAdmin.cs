using System.Data;

namespace DoAn_LTQL
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM ThucUong";
            dtgvThucUong.DataSource = DataProvider.Instance.ExecuteQuery(query);
            string queryDanhMuc = "SELECT * FROM DanhMuc";
            DataTable dataDanhMuc = DataProvider.Instance.ExecuteQuery(queryDanhMuc);

            cbDanhMuc.DataSource = dataDanhMuc;
            cbDanhMuc.DisplayMember = "TenDanhMuc"; // Cái chữ hiện ra trên màn hình cho người dùng thấy
            cbDanhMuc.ValueMember = "MaDanhMuc";
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM ThucUong";
            dtgvThucUong.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            string tenMon = txtTenMon.Text;
            string danhMuc = cbDanhMuc.SelectedValue.ToString();
            float giaTien = (float)ndGiaTien.Value;

            // 2. Viết câu lệnh SQL Thêm dữ liệu
            string query = $"INSERT INTO ThucUong (TenThucUong, MaDanhMuc, GiaBan) VALUES (N'{tenMon}', {danhMuc}, {giaTien})";

            // 3. Thực thi và kiểm tra
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            if (result > 0)
            {
                MessageBox.Show("Thêm món mới thành công!", "Thông báo");
                // Gọi lại nút Xem để làm mới cái bảng bên trái
                btnXem_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm món!", "Lỗi");
            }
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            btnThem.Visible = true;
            txtMaMon.Visible = true;
            txtTenMon.Visible = true;
            cbDanhMuc.Visible = true;
            ndGiaTien.Visible = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có để trống Mã món không
            if (string.IsNullOrWhiteSpace(txtMaMon.Text))
            {
                MessageBox.Show("Vui lòng nhập hoặc chọn Mã món cần sửa!", "Nhắc nhở");
                return;
            }

            // Lấy dữ liệu
            string id = txtMaMon.Text;
            string tenMon = txtTenMon.Text;
            string danhMuc = cbDanhMuc.SelectedValue.ToString(); // Lấy mã số từ ComboBox
            float giaTien = (float)ndGiaTien.Value;

            // Câu lệnh SQL UPDATE
            string query = $"UPDATE ThucUong SET TenThucUong = N'{tenMon}', MaDanhMuc = {danhMuc}, GiaBan = {giaTien} WHERE MaThucUong = {id}";

            try
            {
                int result = DataProvider.Instance.ExecuteNonQuery(query);

                if (result > 0)
                {
                    MessageBox.Show("Sửa món thành công!", "Thông báo");
                    btnXem_Click(sender, e); // Load lại lưới để thấy thay đổi
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi SQL");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có để trống Mã món không
            if (string.IsNullOrWhiteSpace(txtMaMon.Text))
            {
                MessageBox.Show("Vui lòng nhập hoặc chọn Mã món cần xóa!", "Nhắc nhở");
                return;
            }

            string id = txtMaMon.Text;

            // Câu lệnh SQL DELETE
            string query = $"DELETE FROM ThucUong WHERE MaThucUong = {id}";

            try
            {
                // Hiển thị hộp thoại hỏi lại cho chắc chắn (tránh lỡ tay bấm nhầm)
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa món này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int result = DataProvider.Instance.ExecuteNonQuery(query);

                    if (result > 0)
                    {
                        MessageBox.Show("Xóa món thành công!", "Thông báo");
                        btnXem_Click(sender, e); // Load lại lưới
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi SQL");
            }
        }

        private void dtgvThucUong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.RowIndex >= 0)
            {
    
                DataGridViewRow row = dtgvThucUong.Rows[e.RowIndex];

           
                txtMaMon.Text = row.Cells["MaThucUong"].Value.ToString();
                txtTenMon.Text = row.Cells["TenThucUong"].Value.ToString();
                cbDanhMuc.SelectedValue = row.Cells["MaDanhMuc"].Value;
                ndGiaTien.Value = Convert.ToDecimal(row.Cells["GiaBan"].Value);
            }
        }
    }
}
