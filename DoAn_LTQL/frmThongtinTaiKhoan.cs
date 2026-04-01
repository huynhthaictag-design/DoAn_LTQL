using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DoAn_LTQL
{
    public partial class frmThongtinTaiKhoan : Form
    {
        private bool isEditMode = false;

        public frmThongtinTaiKhoan()
        {
            InitializeComponent();
        }

        public frmThongtinTaiKhoan(
            string tenHienThi,
            string tenDangNhap,
            string matKhau,
            int phanQuyen,
            bool isEdit
        )
        {
            InitializeComponent();

            // Gán dữ liệu vào control
            txtTenHienThi.Text = tenHienThi;
            txtTaiKhoan.Text = tenDangNhap;
            txtMatKhau.Text = matKhau;
            if (phanQuyen == 1)
            {
                rdQuanTri.Checked = true;
            }
            else rdNhanVien.Checked = true;
            // Set mode
            isEditMode = isEdit;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string userName = txtTaiKhoan.Text.Trim();
            string displayName = txtTenHienThi.Text.Trim();
            string passWord = txtMatKhau.Text.Trim();
            int type = rdQuanTri.Checked ? 1 : 0;

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(displayName))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (isEditMode)
            {
                // Thực hiện lệnh UPDATE
                string query = $@"
                                UPDATE TAIKHOAN 
                                SET TenHienThi = N'{displayName}', 
                                    MatKhau = '{passWord}', 
                                    PhanQuyen = {type} 
                                WHERE TenDangNhap = '{userName}'
                                ";
                if (DataProvider.Instance.ExecuteNonQuery(query) > 0)
                {
                    MessageBox.Show("Cập nhật tài khoản thành công!");
                    this.Close();
                }
            }
            else
            {
                // Thực hiện lệnh INSERT
                string query = $@"
                                INSERT INTO TAIKHOAN (TenDangNhap, TenHienThi, MatKhau, PhanQuyen) 
                                VALUES ('{userName}', N'{displayName}', '{passWord}', {type})
                                ";
                if (DataProvider.Instance.ExecuteNonQuery(query) > 0)
                {
                    MessageBox.Show("Thêm tài khoản mới thành công!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại hoặc có lỗi xảy ra!");
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThongtinTaiKhoan_Load(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                this.Text = "Cập nhật thông tin tài khoản";
                txtTaiKhoan.Enabled = false; 
            }
            else
            {
                this.Text = "Thêm tài khoản mới";
                txtTaiKhoan.Enabled = true;
            }
        }
    }
}
