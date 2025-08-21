namespace PRO131_01.Forms
{
    partial class FormBH
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
            lblTitle = new Label();
            dgvSanPham = new DataGridView();
            dgvGioHang = new DataGridView();
            lblSoLuong = new Label();
            txtSoLuong = new TextBox();
            btnThemGio = new Button();
            btnXoaGio = new Button();
            lblTongTien = new Label();
            btnThanhToan = new Button();
            btnThoat = new Button();
            label1 = new Label();
            txtTenKH = new TextBox();
            lblTenKH = new Label();
            txtSDT = new TextBox();
            lblSDT = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvGioHang).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(597, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(146, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Bán Hàng";
            // 
            // dgvSanPham
            // 
            dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSanPham.Dock = DockStyle.Bottom;
            dgvSanPham.Location = new Point(0, 480);
            dgvSanPham.Name = "dgvSanPham";
            dgvSanPham.RowHeadersWidth = 51;
            dgvSanPham.Size = new Size(1557, 288);
            dgvSanPham.TabIndex = 1;
            // 
            // dgvGioHang
            // 
            dgvGioHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGioHang.Location = new Point(810, 9);
            dgvGioHang.Name = "dgvGioHang";
            dgvGioHang.RowHeadersWidth = 51;
            dgvGioHang.Size = new Size(749, 381);
            dgvGioHang.TabIndex = 0;
            // 
            // lblSoLuong
            // 
            lblSoLuong.AutoSize = true;
            lblSoLuong.Location = new Point(63, 85);
            lblSoLuong.Name = "lblSoLuong";
            lblSoLuong.Size = new Size(69, 20);
            lblSoLuong.TabIndex = 2;
            lblSoLuong.Text = "Số lượng";
            // 
            // txtSoLuong
            // 
            txtSoLuong.Location = new Point(138, 85);
            txtSoLuong.Name = "txtSoLuong";
            txtSoLuong.Size = new Size(240, 27);
            txtSoLuong.TabIndex = 3;
            // 
            // btnThemGio
            // 
            btnThemGio.Location = new Point(92, 265);
            btnThemGio.Name = "btnThemGio";
            btnThemGio.Size = new Size(127, 29);
            btnThemGio.TabIndex = 4;
            btnThemGio.Text = "Thêm vào giỏ";
            btnThemGio.UseVisualStyleBackColor = true;
            btnThemGio.Click += btnThemGio_Click;
            // 
            // btnXoaGio
            // 
            btnXoaGio.Location = new Point(251, 265);
            btnXoaGio.Name = "btnXoaGio";
            btnXoaGio.Size = new Size(127, 29);
            btnXoaGio.TabIndex = 5;
            btnXoaGio.Text = "Xóa khỏi giỏ";
            btnXoaGio.UseVisualStyleBackColor = true;
            btnXoaGio.Click += btnXoaGio_Click;
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Location = new Point(320, 390);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(122, 20);
            lblTongTien.TabIndex = 6;
            lblTongTien.Text = "Tổng tiền: 0 VNĐ";
            // 
            // btnThanhToan
            // 
            btnThanhToan.Location = new Point(104, 381);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new Size(94, 29);
            btnThanhToan.TabIndex = 7;
            btnThanhToan.Text = "Thanh toán";
            btnThanhToan.UseVisualStyleBackColor = true;
            btnThanhToan.Click += btnThanhToan_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(609, 381);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 29);
            btnThoat.TabIndex = 8;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(586, 187);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 9;
            // 
            // txtTenKH
            // 
            txtTenKH.Location = new Point(554, 85);
            txtTenKH.Name = "txtTenKH";
            txtTenKH.Size = new Size(240, 27);
            txtTenKH.TabIndex = 11;
            // 
            // lblTenKH
            // 
            lblTenKH.AutoSize = true;
            lblTenKH.Location = new Point(479, 85);
            lblTenKH.Name = "lblTenKH";
            lblTenKH.Size = new Size(56, 20);
            lblTenKH.TabIndex = 10;
            lblTenKH.Text = "Tên KH";
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(554, 157);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(250, 27);
            txtSDT.TabIndex = 13;
            // 
            // lblSDT
            // 
            lblSDT.AutoSize = true;
            lblSDT.Location = new Point(489, 157);
            lblSDT.Name = "lblSDT";
            lblSDT.Size = new Size(36, 20);
            lblSDT.TabIndex = 12;
            lblSDT.Text = "SĐT";
            // 
            // FormBH
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1557, 768);
            Controls.Add(txtSDT);
            Controls.Add(lblSDT);
            Controls.Add(txtTenKH);
            Controls.Add(lblTenKH);
            Controls.Add(label1);
            Controls.Add(btnThoat);
            Controls.Add(btnThanhToan);
            Controls.Add(lblTongTien);
            Controls.Add(btnXoaGio);
            Controls.Add(btnThemGio);
            Controls.Add(txtSoLuong);
            Controls.Add(lblSoLuong);
            Controls.Add(dgvGioHang);
            Controls.Add(dgvSanPham);
            Controls.Add(lblTitle);
            Name = "FormBH";
            Text = "FormBH";
            Load += FormBH_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvGioHang).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private DataGridView dgvSanPham;
        private DataGridView dgvGioHang;
        private Label lblSoLuong;
        private TextBox txtSoLuong;
        private Button btnThemGio;
        private Button btnXoaGio;
        private Label lblTongTien;
        private Button btnThanhToan;
        private Button btnThoat;
        private Label label1;
        private TextBox txtTenKH;
        private Label lblTenKH;
        private TextBox txtSDT;
        private Label lblSDT;
    }
}