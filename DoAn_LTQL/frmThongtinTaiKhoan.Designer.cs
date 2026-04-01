namespace DoAn_LTQL
{
    partial class frmThongtinTaiKhoan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtTaiKhoan = new TextBox();
            rdQuanTri = new RadioButton();
            rdNhanVien = new RadioButton();
            btnXacNhan = new Button();
            btnHuy = new Button();
            txtMatKhau = new TextBox();
            label4 = new Label();
            txtTenHienThi = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 112);
            label1.Name = "label1";
            label1.Size = new Size(71, 20);
            label1.TabIndex = 0;
            label1.Text = "Tài khoản";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 193);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 1;
            label2.Text = "Quyền hạn";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(239, 112);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 1;
            label3.Text = "Mật khẩu";
            // 
            // txtTaiKhoan
            // 
            txtTaiKhoan.Location = new Point(20, 148);
            txtTaiKhoan.Name = "txtTaiKhoan";
            txtTaiKhoan.Size = new Size(160, 27);
            txtTaiKhoan.TabIndex = 2;
            // 
            // rdQuanTri
            // 
            rdQuanTri.AutoSize = true;
            rdQuanTri.Location = new Point(20, 224);
            rdQuanTri.Name = "rdQuanTri";
            rdQuanTri.Size = new Size(114, 24);
            rdQuanTri.TabIndex = 3;
            rdQuanTri.TabStop = true;
            rdQuanTri.Text = "Quản trị viên";
            rdQuanTri.UseVisualStyleBackColor = true;
            // 
            // rdNhanVien
            // 
            rdNhanVien.AutoSize = true;
            rdNhanVien.Location = new Point(239, 224);
            rdNhanVien.Name = "rdNhanVien";
            rdNhanVien.Size = new Size(96, 24);
            rdNhanVien.TabIndex = 3;
            rdNhanVien.TabStop = true;
            rdNhanVien.Text = "Nhân viên";
            rdNhanVien.UseVisualStyleBackColor = true;
            // 
            // btnXacNhan
            // 
            btnXacNhan.Location = new Point(74, 280);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.Size = new Size(115, 41);
            btnXacNhan.TabIndex = 4;
            btnXacNhan.Text = "Xác nhận";
            btnXacNhan.UseVisualStyleBackColor = true;
            btnXacNhan.Click += btnXacNhan_Click;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(230, 280);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(114, 41);
            btnHuy.TabIndex = 5;
            btnHuy.Text = "Huỷ";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(239, 148);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(165, 27);
            txtMatKhau.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 25);
            label4.Name = "label4";
            label4.Size = new Size(85, 20);
            label4.TabIndex = 0;
            label4.Text = "Tên hiển thị";
            // 
            // txtTenHienThi
            // 
            txtTenHienThi.Location = new Point(20, 61);
            txtTenHienThi.Name = "txtTenHienThi";
            txtTenHienThi.Size = new Size(384, 27);
            txtTenHienThi.TabIndex = 2;
            // 
            // frmThongtinTaiKhoan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(419, 353);
            Controls.Add(btnHuy);
            Controls.Add(btnXacNhan);
            Controls.Add(rdNhanVien);
            Controls.Add(rdQuanTri);
            Controls.Add(txtMatKhau);
            Controls.Add(txtTenHienThi);
            Controls.Add(txtTaiKhoan);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(label1);
            Name = "frmThongtinTaiKhoan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thông tin tài khoản";
            Load += frmThongtinTaiKhoan_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtTaiKhoan;
        private RadioButton rdQuanTri;
        private RadioButton rdNhanVien;
        private Button btnXacNhan;
        private Button btnHuy;
        private TextBox txtMatKhau;
        private Label label4;
        private TextBox txtTenHienThi;
    }
}