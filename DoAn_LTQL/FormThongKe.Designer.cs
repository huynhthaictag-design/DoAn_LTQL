namespace DoAn_LTQL
{
    partial class FormThongKe
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
            dtpTuNgay = new DateTimePicker();
            dtpDenNgay = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            dtgvDoanhThu = new DataGridView();
            txtTongDoanhThu = new TextBox();
            btnThongKe = new Button();
            pnChart = new Panel();
            ((System.ComponentModel.ISupportInitialize)dtgvDoanhThu).BeginInit();
            SuspendLayout();
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Location = new Point(578, 30);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(210, 27);
            dtpTuNgay.TabIndex = 0;
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Location = new Point(578, 87);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(210, 27);
            dtpDenNgay.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(510, 35);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(510, 92);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 2;
            label2.Text = "label1";
            // 
            // dtgvDoanhThu
            // 
            dtgvDoanhThu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvDoanhThu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvDoanhThu.Location = new Point(12, 12);
            dtgvDoanhThu.Name = "dtgvDoanhThu";
            dtgvDoanhThu.RowHeadersWidth = 51;
            dtgvDoanhThu.Size = new Size(447, 411);
            dtgvDoanhThu.TabIndex = 3;
            // 
            // txtTongDoanhThu
            // 
            txtTongDoanhThu.Location = new Point(540, 155);
            txtTongDoanhThu.Name = "txtTongDoanhThu";
            txtTongDoanhThu.Size = new Size(248, 27);
            txtTongDoanhThu.TabIndex = 4;
            // 
            // btnThongKe
            // 
            btnThongKe.Location = new Point(624, 120);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(94, 29);
            btnThongKe.TabIndex = 5;
            btnThongKe.Text = "Xem Doanh Thu";
            btnThongKe.UseVisualStyleBackColor = true;
            btnThongKe.Click += btnThongKe_Click;
            // 
            // pnChart
            // 
            pnChart.Location = new Point(478, 208);
            pnChart.Name = "pnChart";
            pnChart.Size = new Size(310, 204);
            pnChart.TabIndex = 6;
            // 
            // FormThongKe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnChart);
            Controls.Add(btnThongKe);
            Controls.Add(txtTongDoanhThu);
            Controls.Add(dtgvDoanhThu);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtpDenNgay);
            Controls.Add(dtpTuNgay);
            Name = "FormThongKe";
            Text = "FormThongKe";
            Load += FormThongKe_Load;
            ((System.ComponentModel.ISupportInitialize)dtgvDoanhThu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpTuNgay;
        private DateTimePicker dtpDenNgay;
        private Label label1;
        private Label label2;
        private DataGridView dtgvDoanhThu;
        private TextBox txtTongDoanhThu;
        private Button btnThongKe;
        private Panel pnChart;
    }
}