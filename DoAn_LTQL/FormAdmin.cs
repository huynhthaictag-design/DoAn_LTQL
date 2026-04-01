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

            LoadTaiKhoan();
        }

        private void LoadTaiKhoan()
        {
            string query = "SELECT * FROM TAIKHOAN";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            dtgTaiKhoan.DataSource = data;
            dtgTaiKhoan.ReadOnly = true;

            if (dtgTaiKhoan.Columns.Contains("PhanQuyenCheckBox"))
                dtgTaiKhoan.Columns.Remove("PhanQuyenCheckBox");


            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "PhanQuyenCheckBox";
            checkColumn.HeaderText = "Quyền Admin";
            checkColumn.DataPropertyName = "PhanQuyen";
            checkColumn.TrueValue = 1;
            checkColumn.FalseValue = 0;

            dtgTaiKhoan.Columns.Add(checkColumn);


            dtgTaiKhoan.Columns["TenDangNhap"].HeaderText = "Tên đăng nhập";
            dtgTaiKhoan.Columns["MatKhau"].HeaderText = "Mật khẩu";
            dtgTaiKhoan.Columns["TenHienThi"].HeaderText = "Tên hiển thị";
            dtgTaiKhoan.Columns["PhanQuyen"].Visible = false;

            dtgTaiKhoan.Columns["TenHienThi"].DisplayIndex = 0;
            dtgTaiKhoan.Columns["TenDangNhap"].DisplayIndex = 1;
            dtgTaiKhoan.Columns["MatKhau"].DisplayIndex = 2;
            dtgTaiKhoan.Columns["PhanQuyenCheckBox"].DisplayIndex = 3;


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

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnThemTK_Click(object sender, EventArgs e)
        {
            frmThongtinTaiKhoan f = new frmThongtinTaiKhoan();
            f.ShowDialog();
            LoadTaiKhoan();
        }

        private void btnSuaTK_Click(object sender, EventArgs e)
        {
            if (dtgTaiKhoan.SelectedRows.Count > 0)
            {
                // Lấy dòng đang chọn
                DataGridViewRow row = dtgTaiKhoan.SelectedRows[0];
                string tenHienThi = row.Cells["TenHienThi"].Value.ToString();
                string tenDangNhap = row.Cells["TenDangNhap"].Value.ToString();
                string matKhau = row.Cells["MatKhau"].Value.ToString();
                int phanQuyen = Convert.ToInt32(row.Cells["PhanQuyen"].Value);

                bool isEdit = true;

                // Mở form và truyền dữ liệu qua Constructor hoặc Property
                frmThongtinTaiKhoan f = new frmThongtinTaiKhoan(tenHienThi, tenDangNhap, matKhau, phanQuyen, isEdit);
                f.ShowDialog();
                LoadTaiKhoan();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tài khoản muốn sửa!");
            }
        }

        private void btnXoaTK_Click(object sender, EventArgs e)
        {
            if (dtgTaiKhoan.SelectedRows.Count > 0)
            {
                string userName = dtgTaiKhoan.SelectedRows[0].Cells["TenDangNhap"].Value.ToString();


                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa tài khoản {userName}?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    string query = $"DELETE TAIKHOAN WHERE TenDangNhap = '{userName}'";
                    if (DataProvider.Instance.ExecuteNonQuery(query) > 0)
                    {
                        MessageBox.Show("Xóa thành công!");
                        LoadTaiKhoan();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!");
            }
        }

        private void btnTimTK_Click(object sender, EventArgs e)
        {
            string keyword = txtTimTK.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                LoadTaiKhoan();
                return;
            }

            string query = "";

            if (rdNameTK.Checked)
            {
                // Tìm theo tên hiển thị
                query = $"SELECT * FROM TAIKHOAN WHERE TenHienThi LIKE N'%{keyword}%'";
            }
            else if (rdAccTK.Checked)
            {
                // Tìm theo tên đăng nhập
                query = $"SELECT * FROM TAIKHOAN WHERE TenDangNhap LIKE '%{keyword}%'";
            }
            else
            {
                MessageBox.Show("Vui lòng chọn kiểu tìm kiếm!");
                return;
            }

            dtgTaiKhoan.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        private void btnHuyTK_Click(object sender, EventArgs e)
        {
            txtTimTK.Clear();
            rdAccTK.Checked = false;
            rdNameTK.Checked = false;
            LoadTaiKhoan() ;
        }
    }
}
