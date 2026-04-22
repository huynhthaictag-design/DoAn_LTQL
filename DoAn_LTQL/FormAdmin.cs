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
            LoadThucUong();
            string queryDanhMuc = "SELECT * FROM DanhMuc";
            DataTable dataDanhMuc = DataProvider.Instance.ExecuteQuery(queryDanhMuc);

            cbDanhMuc.DataSource = dataDanhMuc;
            cbDanhMuc.DisplayMember = "TenDanhMuc";
            cbDanhMuc.ValueMember = "MaDanhMuc";

            LoadTaiKhoan();

            btnXemDanhMuc_Click(sender, e);

            TrangThaiGiaoDienBan(false);

            TrangThaiGiaoDienMon(false);
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        void LoadThucUong()
        {
            string query = "SELECT * FROM ThucUong";
            DataTable dtg = DataProvider.Instance.ExecuteQuery(query);

            dtgvThucUong.DataSource = dtg;
            dtgvThucUong.AllowUserToAddRows = false;
            DataTable dttemp = (DataTable)dtgvThucUong.DataSource;

            // Thêm cột ảnh
            if (!dttemp.Columns.Contains("HinhAnh1"))
            {
                dttemp.Columns.Add("HinhAnh1", typeof(Image));
            }

            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            foreach (DataRow row in dttemp.Rows)
            {
                if (row["HinhAnh"] != DBNull.Value)
                {
                    string relativePath = row["HinhAnh"].ToString();

                    string fullPath = Path.Combine(basePath, relativePath);

                    if (File.Exists(fullPath))
                    {
                        try
                        {

                            byte[] bytes = File.ReadAllBytes(fullPath);
                            using (MemoryStream ms = new MemoryStream(bytes))
                            {
                                Image img = Image.FromStream(ms);

                                row["HinhAnh1"] = new Bitmap(img, 24, 24);
                            }
                        }
                        catch
                        {
                            row["HinhAnh1"] = DBNull.Value;
                        }
                    }
                    else
                    {
                        row["HinhAnh1"] = DBNull.Value;
                    }
                }
                else
                {
                    row["HinhAnh1"] = DBNull.Value;
                }
            }

            // Set header ảnh
            if (dtgvThucUong.Columns.Contains("HinhAnh1"))
            {
                dtgvThucUong.Columns["HinhAnh1"].HeaderText = "Ảnh";

                var col = (DataGridViewImageColumn)dtgvThucUong.Columns["HinhAnh1"];
                col.ImageLayout = DataGridViewImageCellLayout.Zoom;
            }

            // Ẩn cột path
            if (dtgvThucUong.Columns.Contains("HinhAnh"))
            {
                dtgvThucUong.Columns["HinhAnh"].Visible = false;
            }

            dtgvThucUong.RowTemplate.Height = 50;
            dtgvThucUong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        private int hanhDongMon = 0; // 1: Thêm, 2: Sửa

        private void TrangThaiGiaoDienMon(bool dangThaoTac)
        {
            txtTenMon.ReadOnly = !dangThaoTac;
            cbDanhMuc.Enabled = dangThaoTac;
            ndGiaTien.Enabled = dangThaoTac;

            btnLuuMon.Visible = dangThaoTac;
            btnHuyMon.Visible = dangThaoTac;

            btnThem.Enabled = !dangThaoTac;
            btnSua.Enabled = !dangThaoTac;
            btnXoa.Enabled = !dangThaoTac;
            dtgvThucUong.Enabled = !dangThaoTac;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            hanhDongMon = 1;
            txtMaMon.Clear();
            txtTenMon.Clear();
            ndGiaTien.Value = 0;
            TrangThaiGiaoDienMon(true);
            txtTenMon.Focus();
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            txtMaMon.Visible = true;
            txtTenMon.Visible = true;
            cbDanhMuc.Visible = true;
            ndGiaTien.Visible = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaMon.Text))
            {
                MessageBox.Show("Vui lòng chọn 1 món để sửa!");
                return;
            }
            hanhDongMon = 2;
            TrangThaiGiaoDienMon(true);
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
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa món này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int result = DataProvider.Instance.ExecuteNonQuery(query);

                    if (result > 0)
                    {
                        MessageBox.Show("Xóa món thành công!", "Thông báo");
                        LoadThucUong();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi SQL");
            }
        }
        private void btnHuyMon_Click(object sender, EventArgs e)
        {
            hanhDongMon = 0;
            TrangThaiGiaoDienMon(false);
            LoadThucUong();
        }
        private void btnLuuMon_Click(object sender, EventArgs e)
        {
            string tenMon = txtTenMon.Text.Trim();
            if (string.IsNullOrEmpty(tenMon))
            {
                MessageBox.Show("Tên món không được để trống!"); return;
            }

            string danhMuc = cbDanhMuc.SelectedValue.ToString();
            float giaTien = (float)ndGiaTien.Value;
            string query = "";

            if (hanhDongMon == 1)
            {
                query = $"INSERT INTO ThucUong (TenThucUong, MaDanhMuc, GiaBan) VALUES (N'{tenMon}', {danhMuc}, {giaTien})";
            }
            else if (hanhDongMon == 2)
            {
                string id = txtMaMon.Text;
                query = $"UPDATE ThucUong SET TenThucUong = N'{tenMon}', MaDanhMuc = {danhMuc}, GiaBan = {giaTien} WHERE MaThucUong = {id}";
            }

            if (DataProvider.Instance.ExecuteNonQuery(query) > 0)
            {
                MessageBox.Show("Lưu món thành công!");
                hanhDongMon = 0;
                TrangThaiGiaoDienMon(false);
                LoadThucUong();
            }
        }

        private void dtgvThucUong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Đảm bảo click vào vùng có dữ liệu
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvThucUong.Rows[e.RowIndex];

                // [LỚP GIÁP 1] Chặn ngay nếu lỡ click vào dòng trống mới (dòng có dấu * dưới cùng)
                if (row.IsNewRow) return;

                // [LỚP GIÁP 2] Dùng try-catch để nhốt lỗi DBNull lại, phần mềm vẫn sống nhăn răng
                try
                {
                    txtMaMon.Text = row.Cells["MaThucUong"].Value.ToString();
                    txtTenMon.Text = row.Cells["TenThucUong"].Value.ToString();
                    cbDanhMuc.SelectedValue = row.Cells["MaDanhMuc"].Value;

                    // Xử lý an toàn cho cột Giá Bán
                    if (row.Cells["GiaBan"].Value != DBNull.Value)
                    {
                        ndGiaTien.Value = Convert.ToDecimal(row.Cells["GiaBan"].Value);
                    }
                    else
                    {
                        ndGiaTien.Value = 0; // Nếu giá rỗng thì tự cho về 0
                    }
                }
                catch (Exception ex)
                {
                    // Báo lỗi nhẹ nhàng thay vì văng app
                    // MessageBox.Show("Có ô dữ liệu bị trống: " + ex.Message);
                }
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
            LoadTaiKhoan();
        }

        private void btnXemBan_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Ban";
            dtgvBan.DataSource = DataProvider.Instance.ExecuteQuery(query);
            btnThemBan.Visible = true;
            btnSuaBan.Visible = true;
            btnXoaBan.Visible = true;
            btnNhapBan.Visible = true;
            groupBox3.Visible = true;
        }

        private int hanhDongBan = 0; // 1: Thêm, 2: Sửa

        private void TrangThaiGiaoDienBan(bool dangThaoTac)
        {
            txtTenBan.ReadOnly = !dangThaoTac;
            cbTrangThai.Enabled = dangThaoTac;

            btnLuuBan.Visible = dangThaoTac;
            btnHuyBan.Visible = dangThaoTac;

            btnThemBan.Enabled = !dangThaoTac;
            btnSuaBan.Enabled = !dangThaoTac;
            btnXoaBan.Enabled = !dangThaoTac;
            btnXemBan.Enabled = !dangThaoTac;
            dtgvBan.Enabled = !dangThaoTac;
        }

        private void btnThemBan_Click(object sender, EventArgs e)
        {
            hanhDongBan = 1;
            txtMaBan.Clear();
            txtTenBan.Clear();
            cbTrangThai.Text = "Trống"; // Mặc định thêm mới là Trống
            cbTrangThai.Enabled = false;
            TrangThaiGiaoDienBan(true);
            txtTenBan.Focus();
        }

        private void btnSuaBan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaBan.Text))
            {
                MessageBox.Show("Vui lòng chọn 1 bàn để sửa!");
                return;
            }
            hanhDongBan = 2;
            TrangThaiGiaoDienBan(true);
        }

        private void btnXoaBan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaBan.Text))
            {
                MessageBox.Show("Vui lòng chọn bàn cần xóa!", "Nhắc nhở");
                return;
            }

            string id = txtMaBan.Text;
            string query = $"DELETE FROM Ban WHERE MaBan = {id}";

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa bàn này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    if (DataProvider.Instance.ExecuteNonQuery(query) > 0)
                    {
                        MessageBox.Show("Xóa bàn thành công!", "Thông báo");
                        btnXemBan_Click(sender, e); // Load lại lưới
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa bàn này vì có thể nó đang chứa dữ liệu Hóa Đơn!\nLỗi chi tiết: " + ex.Message, "Lỗi SQL");
                }
            }
        }

        private void btnHuyBan_Click(object sender, EventArgs e)
        {
            hanhDongBan = 0;
            TrangThaiGiaoDienBan(false);
            btnXemBan_Click(sender, e); // Load lại dữ liệu gốc
        }
        private void btnNhapBan_Click(object sender, EventArgs e)
        {
            txtTenBan.ReadOnly = false;
            cbTrangThai.Enabled = true;

            btnThemBan.Enabled = true;
            btnSuaBan.Enabled = true;
            btnXoaBan.Enabled = true;
            btnXemBan.Enabled = true;

            dtgvBan.Enabled = true;

            btnLuuBan.Visible = false;
            btnHuyBan.Visible = false;

        }
        
        private void btnLuuBan_Click(object sender, EventArgs e)
        {
            string tenBan = txtTenBan.Text.Trim();
            if (string.IsNullOrEmpty(tenBan))
            {
                MessageBox.Show("Tên bàn không được để trống!"); return;
            }

            string query = "";
            if (hanhDongBan == 1)
            {
                query = $"INSERT INTO Ban (TenBan, TrangThai) VALUES (N'{tenBan}', N'Trống')";
            }
            else if (hanhDongBan == 2)
            {
                string id = txtMaBan.Text;
                string trangThai = cbTrangThai.Text;
                query = $"UPDATE Ban SET TenBan = N'{tenBan}', TrangThai = N'{trangThai}' WHERE MaBan = {id}";
            }

            if (DataProvider.Instance.ExecuteNonQuery(query) > 0)
            {
                MessageBox.Show("Lưu bàn thành công!");
                hanhDongBan = 0;
                TrangThaiGiaoDienBan(false);
                btnXemBan_Click(sender, e);
            }
        }

        private void dtgvBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvBan.Rows[e.RowIndex];

                txtMaBan.Text = row.Cells["MaBan"].Value.ToString();
                txtTenBan.Text = row.Cells["TenBan"].Value.ToString();
                cbTrangThai.Text = row.Cells["TrangThai"].Value.ToString();
            }
        }

        private int hanhDongDanhMuc = 0; // 1: Thêm, 2: Sửa

        private void TrangThaiGiaoDienDanhMuc(bool dangThaoTac)
        {
            txtTenDanhMuc.ReadOnly = !dangThaoTac;

            btnLuuDanhMuc.Visible = dangThaoTac;
            btnHuyDanhMuc.Visible = dangThaoTac;

            btnThemDanhMuc.Enabled = !dangThaoTac;
            btnSuaDanhMuc.Enabled = !dangThaoTac;
            btnXoaDanhMuc.Enabled = !dangThaoTac;
            btnXemDanhMuc.Enabled = !dangThaoTac;

            dtgvDanhMuc.Enabled = !dangThaoTac;
        }

        private void btnXemDanhMuc_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM DanhMuc";
            dtgvDanhMuc.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        private void btnThemDanhMuc_Click(object sender, EventArgs e)
        {
            hanhDongDanhMuc = 1;
            txtMaDanhMuc.Visible = true;
            txtTenDanhMuc.Visible = true;
            txtMaDanhMuc.Clear();
            txtTenDanhMuc.Clear();

            TrangThaiGiaoDienDanhMuc(true);
            txtTenDanhMuc.Focus();
        }

        private void btnSuaDanhMuc_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaDanhMuc.Text))
            {
                MessageBox.Show("Vui lòng chọn danh mục để sửa!");
                return;
            }

            hanhDongDanhMuc = 2;
            TrangThaiGiaoDienDanhMuc(true);
        }

        private void btnXoaDanhMuc_Click(object sender, EventArgs e)
        {
            string id = txtMaDanhMuc.Text;

            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Vui lòng chọn danh mục cần xóa!", "Nhắc nhở");
                return;
            }

            string query = $"DELETE FROM DanhMuc WHERE MaDanhMuc = {id}";

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa danh mục này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    if (DataProvider.Instance.ExecuteNonQuery(query) > 0)
                    {
                        MessageBox.Show("Xóa danh mục thành công!", "Thông báo");
                        btnXemDanhMuc_Click(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa! Danh mục này đang chứa các món đồ uống. Vui lòng xóa hết các món thuộc danh mục này trước.\nLỗi chi tiết: " + ex.Message, "Lỗi SQL");
                }
            }
        }

        private void btnNhapDanhMuc_Click(object sender, EventArgs e)
        {

            txtTenDanhMuc.ReadOnly = false;

            btnThemDanhMuc.Enabled = true;
            btnSuaDanhMuc.Enabled = true;
            btnXoaDanhMuc.Enabled = true;
            btnXemDanhMuc.Enabled = true;

            dtgvDanhMuc.Enabled = true;

            // Ẩn nút Lưu/Hủy (chưa thao tác gì)
            btnLuuDanhMuc.Visible = false;
            btnHuyDanhMuc.Visible = false;
        }

        private void btnLuuDanhMuc_Click(object sender, EventArgs e)
        {
            string tenDanhMuc = txtTenDanhMuc.Text.Trim();

            if (string.IsNullOrEmpty(tenDanhMuc))
            {
                MessageBox.Show("Tên danh mục không được để trống!");
                return;
            }

            string query = "";

            if (hanhDongDanhMuc == 1)
            {
                // THÊM
                query = $"INSERT INTO DanhMuc (TenDanhMuc) VALUES (N'{tenDanhMuc}')";
            }
            else if (hanhDongDanhMuc == 2)
            {
                // SỬA
                string id = txtMaDanhMuc.Text;
                query = $"UPDATE DanhMuc SET TenDanhMuc = N'{tenDanhMuc}' WHERE MaDanhMuc = {id}";
            }

            if (DataProvider.Instance.ExecuteNonQuery(query) > 0)
            {
                MessageBox.Show("Lưu thành công!");
                hanhDongDanhMuc = 0;
                TrangThaiGiaoDienDanhMuc(false);
                btnXemDanhMuc_Click(sender, e);
            }
        }
        private void btnHuyDanhMuc_Click(object sender, EventArgs e)
        {
            hanhDongDanhMuc = 0;
            TrangThaiGiaoDienDanhMuc(false);
            btnXemDanhMuc_Click(sender, e);
        }

        private void dtgvDanhMuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvDanhMuc.Rows[e.RowIndex];

                txtMaDanhMuc.Text = row.Cells["MaDanhMuc"].Value.ToString();
                txtTenDanhMuc.Text = row.Cells["TenDanhMuc"].Value.ToString();
            }
        }

        private void cbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
