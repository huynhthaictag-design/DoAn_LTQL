namespace DoAn_LTQL
{
    partial class FormBanHang
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
            flpBan = new FlowLayoutPanel();
            cbDanhMuc = new ComboBox();
            cbThucUong = new ComboBox();
            nmSoLuong = new NumericUpDown();
            btnThemMon = new Button();
            lsvBill = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            nmGiamGia = new NumericUpDown();
            txtTongTien = new TextBox();
            btnThanhToan = new Button();
            ((System.ComponentModel.ISupportInitialize)nmSoLuong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmGiamGia).BeginInit();
            SuspendLayout();
            // 
            // flpBan
            // 
            flpBan.AutoScroll = true;
            flpBan.Location = new Point(12, 12);
            flpBan.Name = "flpBan";
            flpBan.Size = new Size(433, 440);
            flpBan.TabIndex = 0;
            // 
            // cbDanhMuc
            // 
            cbDanhMuc.FormattingEnabled = true;
            cbDanhMuc.Location = new Point(451, 12);
            cbDanhMuc.Name = "cbDanhMuc";
            cbDanhMuc.Size = new Size(132, 28);
            cbDanhMuc.TabIndex = 1;
            cbDanhMuc.SelectedIndexChanged += cbDanhMuc_SelectedIndexChanged;
            // 
            // cbThucUong
            // 
            cbThucUong.FormattingEnabled = true;
            cbThucUong.Location = new Point(659, 12);
            cbThucUong.Name = "cbThucUong";
            cbThucUong.Size = new Size(129, 28);
            cbThucUong.TabIndex = 1;
            // 
            // nmSoLuong
            // 
            nmSoLuong.Location = new Point(451, 55);
            nmSoLuong.Name = "nmSoLuong";
            nmSoLuong.Size = new Size(132, 27);
            nmSoLuong.TabIndex = 2;
            // 
            // btnThemMon
            // 
            btnThemMon.Location = new Point(659, 55);
            btnThemMon.Name = "btnThemMon";
            btnThemMon.Size = new Size(129, 29);
            btnThemMon.TabIndex = 3;
            btnThemMon.Text = "Thêm Món";
            btnThemMon.UseVisualStyleBackColor = true;
            btnThemMon.Click += btnThemMon_Click;
            // 
            // lsvBill
            // 
            lsvBill.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            lsvBill.GridLines = true;
            lsvBill.Location = new Point(451, 108);
            lsvBill.Name = "lsvBill";
            lsvBill.Size = new Size(337, 164);
            lsvBill.TabIndex = 4;
            lsvBill.UseCompatibleStateImageBehavior = false;
            lsvBill.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Tên món";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Số lượng";
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Đơn giá";
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Thành tiền";
            // 
            // nmGiamGia
            // 
            nmGiamGia.Location = new Point(535, 293);
            nmGiamGia.Name = "nmGiamGia";
            nmGiamGia.Size = new Size(150, 27);
            nmGiamGia.TabIndex = 5;
            // 
            // txtTongTien
            // 
            txtTongTien.Location = new Point(488, 326);
            txtTongTien.Name = "txtTongTien";
            txtTongTien.ReadOnly = true;
            txtTongTien.Size = new Size(249, 27);
            txtTongTien.TabIndex = 6;
            // 
            // btnThanhToan
            // 
            btnThanhToan.Location = new Point(568, 373);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(94, 29);
            btnThanhToan.TabIndex = 7;
            btnThanhToan.Text = "Thanh Toán";
            btnThanhToan.UseVisualStyleBackColor = true;
            btnThanhToan.Click += btnThanhToan_Click;
            // 
            // FormBanHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnThanhToan);
            Controls.Add(txtTongTien);
            Controls.Add(nmGiamGia);
            Controls.Add(lsvBill);
            Controls.Add(btnThemMon);
            Controls.Add(nmSoLuong);
            Controls.Add(cbThucUong);
            Controls.Add(cbDanhMuc);
            Controls.Add(flpBan);
            Name = "FormBanHang";
            Text = "FormBanHang";
            Load += FormBanHang_Load;
            ((System.ComponentModel.ISupportInitialize)nmSoLuong).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmGiamGia).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flpBan;
        private ComboBox cbDanhMuc;
        private ComboBox cbThucUong;
        private NumericUpDown nmSoLuong;
        private Button btnThemMon;
        private ListView lsvBill;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private NumericUpDown nmGiamGia;
        private TextBox txtTongTien;
        private Button btnThanhToan;
    }
}