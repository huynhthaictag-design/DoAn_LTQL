namespace DoAn_LTQL
{
    partial class FormAdmin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabPage4 = new TabPage();
            btnNhap = new Button();
            groupBox1 = new GroupBox();
            ndGiaTien = new NumericUpDown();
            cbDanhMuc = new ComboBox();
            txtTenMon = new TextBox();
            txtMaMon = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            dtgvThucUong = new DataGridView();
            panel1 = new Panel();
            btnXem = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            tabPage3 = new TabPage();
            groupBox3 = new GroupBox();
            cbTrangThai = new ComboBox();
            txtTenBan = new TextBox();
            txtMaBan = new TextBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            dtgvBan = new DataGridView();
            panel2 = new Panel();
            btnXemBan = new Button();
            btnXoaBan = new Button();
            btnSuaBan = new Button();
            btnThemBan = new Button();
            tabPage2 = new TabPage();
            tabPage1 = new TabPage();
            groupBox2 = new GroupBox();
            txtTimTK = new TextBox();
            btnHuyTK = new Button();
            btnTimTK = new Button();
            rdAccTK = new RadioButton();
            rdNameTK = new RadioButton();
            label5 = new Label();
            btnSuaTK = new Button();
            btnXoaTK = new Button();
            btnThemTK = new Button();
            dtgTaiKhoan = new DataGridView();
            tabControl1 = new TabControl();
            tabPage4.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ndGiaTien).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgvThucUong).BeginInit();
            panel1.SuspendLayout();
            tabPage3.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvBan).BeginInit();
            panel2.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtgTaiKhoan).BeginInit();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(btnNhap);
            tabPage4.Controls.Add(groupBox1);
            tabPage4.Controls.Add(dtgvThucUong);
            tabPage4.Controls.Add(panel1);
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(777, 397);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Thức Uống";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnNhap
            // 
            btnNhap.Location = new Point(530, 302);
            btnNhap.Name = "btnNhap";
            btnNhap.Size = new Size(94, 29);
            btnNhap.TabIndex = 4;
            btnNhap.Text = "Nhập";
            btnNhap.UseVisualStyleBackColor = true;
            btnNhap.Click += btnNhap_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ndGiaTien);
            groupBox1.Controls.Add(cbDanhMuc);
            groupBox1.Controls.Add(txtTenMon);
            groupBox1.Controls.Add(txtMaMon);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(523, 98);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(250, 187);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thêm thông tin";
            // 
            // ndGiaTien
            // 
            ndGiaTien.Location = new Point(78, 156);
            ndGiaTien.Maximum = new decimal(new int[] { -559939584, 902409669, 54, 0 });
            ndGiaTien.Name = "ndGiaTien";
            ndGiaTien.Size = new Size(163, 27);
            ndGiaTien.TabIndex = 5;
            ndGiaTien.Visible = false;
            // 
            // cbDanhMuc
            // 
            cbDanhMuc.FormattingEnabled = true;
            cbDanhMuc.Items.AddRange(new object[] { "Trà", "Sinh Tố", "Bánh" });
            cbDanhMuc.Location = new Point(78, 113);
            cbDanhMuc.Name = "cbDanhMuc";
            cbDanhMuc.Size = new Size(163, 28);
            cbDanhMuc.TabIndex = 4;
            cbDanhMuc.Visible = false;
            // 
            // txtTenMon
            // 
            txtTenMon.Location = new Point(78, 71);
            txtTenMon.Name = "txtTenMon";
            txtTenMon.Size = new Size(166, 27);
            txtTenMon.TabIndex = 3;
            txtTenMon.Visible = false;
            // 
            // txtMaMon
            // 
            txtMaMon.Location = new Point(78, 31);
            txtMaMon.Name = "txtMaMon";
            txtMaMon.Size = new Size(166, 27);
            txtMaMon.TabIndex = 3;
            txtMaMon.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 163);
            label3.Name = "label3";
            label3.Size = new Size(60, 20);
            label3.TabIndex = 1;
            label3.Text = "Giá tiền";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(2, 121);
            label4.Name = "label4";
            label4.Size = new Size(76, 20);
            label4.TabIndex = 2;
            label4.Text = "Danh mục";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(0, 78);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 0;
            label2.Text = "Tên món";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(2, 38);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã món";
            // 
            // dtgvThucUong
            // 
            dtgvThucUong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvThucUong.Location = new Point(-4, 0);
            dtgvThucUong.Name = "dtgvThucUong";
            dtgvThucUong.RowHeadersWidth = 51;
            dtgvThucUong.Size = new Size(528, 391);
            dtgvThucUong.TabIndex = 2;
            dtgvThucUong.CellClick += dtgvThucUong_CellClick;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnXem);
            panel1.Controls.Add(btnXoa);
            panel1.Controls.Add(btnSua);
            panel1.Controls.Add(btnThem);
            panel1.Location = new Point(523, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(248, 92);
            panel1.TabIndex = 1;
            // 
            // btnXem
            // 
            btnXem.Location = new Point(162, 53);
            btnXem.Name = "btnXem";
            btnXem.Size = new Size(94, 29);
            btnXem.TabIndex = 1;
            btnXem.Text = "Xem";
            btnXem.UseVisualStyleBackColor = true;
            btnXem.Click += btnXem_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(158, 3);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 1;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(0, 53);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 1;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(0, 0);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 32);
            btnThem.TabIndex = 0;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Visible = false;
            btnThem.Click += btnThem_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(groupBox3);
            tabPage3.Controls.Add(dtgvBan);
            tabPage3.Controls.Add(panel2);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(777, 397);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Bàn";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(cbTrangThai);
            groupBox3.Controls.Add(txtTenBan);
            groupBox3.Controls.Add(txtMaBan);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(label9);
            groupBox3.Location = new Point(527, 101);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(250, 290);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "Thêm thông tin";
            groupBox3.Visible = false;
            // 
            // cbTrangThai
            // 
            cbTrangThai.FormattingEnabled = true;
            cbTrangThai.Items.AddRange(new object[] { "Trống", "Có người" });
            cbTrangThai.Location = new Point(78, 113);
            cbTrangThai.Name = "cbTrangThai";
            cbTrangThai.Size = new Size(163, 28);
            cbTrangThai.TabIndex = 4;
            // 
            // txtTenBan
            // 
            txtTenBan.Location = new Point(78, 71);
            txtTenBan.Name = "txtTenBan";
            txtTenBan.Size = new Size(166, 27);
            txtTenBan.TabIndex = 3;
            // 
            // txtMaBan
            // 
            txtMaBan.Location = new Point(78, 31);
            txtMaBan.Name = "txtMaBan";
            txtMaBan.ReadOnly = true;
            txtMaBan.Size = new Size(166, 27);
            txtMaBan.TabIndex = 3;
            txtMaBan.Visible = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(2, 121);
            label7.Name = "label7";
            label7.Size = new Size(78, 20);
            label7.TabIndex = 2;
            label7.Text = "Trạng Thái";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(0, 78);
            label8.Name = "label8";
            label8.Size = new Size(61, 20);
            label8.TabIndex = 0;
            label8.Text = "Tên Bàn";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(2, 38);
            label9.Name = "label9";
            label9.Size = new Size(59, 20);
            label9.TabIndex = 0;
            label9.Text = "Mã Bàn";
            // 
            // dtgvBan
            // 
            dtgvBan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvBan.Location = new Point(0, 3);
            dtgvBan.Name = "dtgvBan";
            dtgvBan.RowHeadersWidth = 51;
            dtgvBan.Size = new Size(528, 391);
            dtgvBan.TabIndex = 5;
            dtgvBan.CellClick += dtgvBan_CellClick;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnXemBan);
            panel2.Controls.Add(btnXoaBan);
            panel2.Controls.Add(btnSuaBan);
            panel2.Controls.Add(btnThemBan);
            panel2.Location = new Point(527, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(248, 92);
            panel2.TabIndex = 4;
            // 
            // btnXemBan
            // 
            btnXemBan.Location = new Point(162, 53);
            btnXemBan.Name = "btnXemBan";
            btnXemBan.Size = new Size(94, 29);
            btnXemBan.TabIndex = 1;
            btnXemBan.Text = "Xem";
            btnXemBan.UseVisualStyleBackColor = true;
            btnXemBan.Click += btnXemBan_Click;
            // 
            // btnXoaBan
            // 
            btnXoaBan.Location = new Point(158, 3);
            btnXoaBan.Name = "btnXoaBan";
            btnXoaBan.Size = new Size(94, 29);
            btnXoaBan.TabIndex = 1;
            btnXoaBan.Text = "Xóa";
            btnXoaBan.UseVisualStyleBackColor = true;
            btnXoaBan.Visible = false;
            btnXoaBan.Click += btnXoaBan_Click;
            // 
            // btnSuaBan
            // 
            btnSuaBan.Location = new Point(0, 53);
            btnSuaBan.Name = "btnSuaBan";
            btnSuaBan.Size = new Size(94, 29);
            btnSuaBan.TabIndex = 1;
            btnSuaBan.Text = "Sửa";
            btnSuaBan.UseVisualStyleBackColor = true;
            btnSuaBan.Visible = false;
            btnSuaBan.Click += btnSuaBan_Click;
            // 
            // btnThemBan
            // 
            btnThemBan.Location = new Point(0, 0);
            btnThemBan.Name = "btnThemBan";
            btnThemBan.Size = new Size(94, 32);
            btnThemBan.TabIndex = 0;
            btnThemBan.Text = "Thêm";
            btnThemBan.UseVisualStyleBackColor = true;
            btnThemBan.Visible = false;
            btnThemBan.Click += btnThemBan_Click;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(777, 397);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Danh mục";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(groupBox2);
            tabPage1.Controls.Add(btnSuaTK);
            tabPage1.Controls.Add(btnXoaTK);
            tabPage1.Controls.Add(btnThemTK);
            tabPage1.Controls.Add(dtgTaiKhoan);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(777, 397);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Tài Khoản";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += tabPage1_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtTimTK);
            groupBox2.Controls.Add(btnHuyTK);
            groupBox2.Controls.Add(btnTimTK);
            groupBox2.Controls.Add(rdAccTK);
            groupBox2.Controls.Add(rdNameTK);
            groupBox2.Controls.Add(label5);
            groupBox2.Location = new Point(560, 172);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(211, 219);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Tìm kiếm";
            // 
            // txtTimTK
            // 
            txtTimTK.Location = new Point(21, 122);
            txtTimTK.Name = "txtTimTK";
            txtTimTK.Size = new Size(172, 27);
            txtTimTK.TabIndex = 2;
            // 
            // btnHuyTK
            // 
            btnHuyTK.Location = new Point(115, 164);
            btnHuyTK.Name = "btnHuyTK";
            btnHuyTK.Size = new Size(78, 38);
            btnHuyTK.TabIndex = 1;
            btnHuyTK.Text = "Huỷ";
            btnHuyTK.UseVisualStyleBackColor = true;
            btnHuyTK.Click += btnHuyTK_Click;
            // 
            // btnTimTK
            // 
            btnTimTK.Location = new Point(18, 164);
            btnTimTK.Name = "btnTimTK";
            btnTimTK.Size = new Size(78, 38);
            btnTimTK.TabIndex = 1;
            btnTimTK.Text = "Tìm";
            btnTimTK.UseVisualStyleBackColor = true;
            btnTimTK.Click += btnTimTK_Click;
            // 
            // rdAccTK
            // 
            rdAccTK.AutoSize = true;
            rdAccTK.Location = new Point(44, 86);
            rdAccTK.Name = "rdAccTK";
            rdAccTK.Size = new Size(128, 24);
            rdAccTK.TabIndex = 1;
            rdAccTK.TabStop = true;
            rdAccTK.Text = "Tên đăng nhập";
            rdAccTK.UseVisualStyleBackColor = true;
            // 
            // rdNameTK
            // 
            rdNameTK.AutoSize = true;
            rdNameTK.Location = new Point(44, 56);
            rdNameTK.Name = "rdNameTK";
            rdNameTK.Size = new Size(106, 24);
            rdNameTK.TabIndex = 1;
            rdNameTK.TabStop = true;
            rdNameTK.Text = "Tên hiển thị";
            rdNameTK.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(44, 33);
            label5.Name = "label5";
            label5.Size = new Size(68, 20);
            label5.TabIndex = 0;
            label5.Text = "Tìm theo";
            // 
            // btnSuaTK
            // 
            btnSuaTK.Location = new Point(618, 128);
            btnSuaTK.Name = "btnSuaTK";
            btnSuaTK.Size = new Size(94, 38);
            btnSuaTK.TabIndex = 1;
            btnSuaTK.Text = "Sửa";
            btnSuaTK.UseVisualStyleBackColor = true;
            btnSuaTK.Click += btnSuaTK_Click;
            // 
            // btnXoaTK
            // 
            btnXoaTK.Location = new Point(618, 73);
            btnXoaTK.Name = "btnXoaTK";
            btnXoaTK.Size = new Size(94, 38);
            btnXoaTK.TabIndex = 1;
            btnXoaTK.Text = "Xoá";
            btnXoaTK.UseVisualStyleBackColor = true;
            btnXoaTK.UseWaitCursor = true;
            btnXoaTK.Click += btnXoaTK_Click;
            // 
            // btnThemTK
            // 
            btnThemTK.Location = new Point(618, 17);
            btnThemTK.Name = "btnThemTK";
            btnThemTK.Size = new Size(94, 38);
            btnThemTK.TabIndex = 1;
            btnThemTK.Text = "Thêm";
            btnThemTK.UseVisualStyleBackColor = true;
            btnThemTK.Click += btnThemTK_Click;
            // 
            // dtgTaiKhoan
            // 
            dtgTaiKhoan.AllowUserToAddRows = false;
            dtgTaiKhoan.AllowUserToDeleteRows = false;
            dtgTaiKhoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgTaiKhoan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgTaiKhoan.Location = new Point(0, 0);
            dtgTaiKhoan.MultiSelect = false;
            dtgTaiKhoan.Name = "dtgTaiKhoan";
            dtgTaiKhoan.RowHeadersWidth = 51;
            dtgTaiKhoan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgTaiKhoan.Size = new Size(554, 397);
            dtgTaiKhoan.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new Point(3, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(785, 430);
            tabControl1.TabIndex = 1;
            // 
            // FormAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(801, 454);
            Controls.Add(tabControl1);
            Name = "FormAdmin";
            Text = "Form1";
            Load += Form1_Load;
            tabPage4.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ndGiaTien).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgvThucUong).EndInit();
            panel1.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgvBan).EndInit();
            panel2.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtgTaiKhoan).EndInit();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabPage tabPage4;
        private GroupBox groupBox1;
        private NumericUpDown ndGiaTien;
        private ComboBox cbDanhMuc;
        private TextBox txtTenMon;
        private TextBox txtMaMon;
        private Label label3;
        private Label label4;
        private Label label2;
        private Label label1;
        private DataGridView dtgvThucUong;
        private Panel panel1;
        private Button btnXem;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private TabPage tabPage3;
        private TabPage tabPage2;
        private TabPage tabPage1;
        private TabControl tabControl1;
        private Button btnNhap;
        private DataGridView dtgTaiKhoan;
        private GroupBox groupBox2;
        private TextBox txtTimTK;
        private Button btnTimTK;
        private RadioButton rdAccTK;
        private RadioButton rdNameTK;
        private Label label5;
        private Button btnSuaTK;
        private Button btnXoaTK;
        private Button btnThemTK;
        private Button btnHuyTK;
        private GroupBox groupBox3;
        private ComboBox cbTrangThai;
        private TextBox txtTenBan;
        private TextBox txtMaBan;
        private Label label7;
        private Label label8;
        private Label label9;
        private DataGridView dtgvBan;
        private Panel panel2;
        private Button btnXemBan;
        private Button btnXoaBan;
        private Button btnSuaBan;
        private Button btnThemBan;
    }
}
