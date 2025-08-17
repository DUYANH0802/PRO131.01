namespace PRO131_01.Forms
{
    partial class FormQLKH
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
            cbGioiTinh = new ComboBox();
            txtMaKH = new TextBox();
            btnLammoi = new Button();
            btnXoa = new Button();
            lbMaNV = new Label();
            lbHoten = new Label();
            btnSua = new Button();
            lbSodienthoai = new Label();
            btnThem = new Button();
            lbEmail = new Label();
            lbDiachi = new Label();
            txtDiaChi = new TextBox();
            lbGioitinh = new Label();
            txtEmail = new TextBox();
            txtTenKH = new TextBox();
            txtSDT = new TextBox();
            dgvQLKH = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvQLKH).BeginInit();
            SuspendLayout();
            // 
            // cbGioiTinh
            // 
            cbGioiTinh.FormattingEnabled = true;
            cbGioiTinh.Location = new Point(152, 282);
            cbGioiTinh.Name = "cbGioiTinh";
            cbGioiTinh.Size = new Size(183, 28);
            cbGioiTinh.TabIndex = 33;
            // 
            // txtMaKH
            // 
            txtMaKH.Location = new Point(152, 8);
            txtMaKH.Name = "txtMaKH";
            txtMaKH.Size = new Size(183, 27);
            txtMaKH.TabIndex = 24;
            // 
            // btnLammoi
            // 
            btnLammoi.Location = new Point(399, 173);
            btnLammoi.Name = "btnLammoi";
            btnLammoi.Size = new Size(94, 29);
            btnLammoi.TabIndex = 31;
            btnLammoi.Text = "Làm mới";
            btnLammoi.UseVisualStyleBackColor = true;
            btnLammoi.Click += btnLammoi_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(399, 124);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 32;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // lbMaNV
            // 
            lbMaNV.AutoSize = true;
            lbMaNV.Location = new Point(11, 8);
            lbMaNV.Name = "lbMaNV";
            lbMaNV.Size = new Size(109, 40);
            lbMaNV.TabIndex = 19;
            lbMaNV.Text = "Mã khách hàng\r\n\r\n";
            // 
            // lbHoten
            // 
            lbHoten.AutoSize = true;
            lbHoten.Location = new Point(11, 63);
            lbHoten.Name = "lbHoten";
            lbHoten.Size = new Size(54, 20);
            lbHoten.TabIndex = 20;
            lbHoten.Text = "Họ tên";
            // 
            // btnSua
            // 
            btnSua.Location = new Point(399, 76);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 30;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // lbSodienthoai
            // 
            lbSodienthoai.AutoSize = true;
            lbSodienthoai.Location = new Point(6, 128);
            lbSodienthoai.Name = "lbSodienthoai";
            lbSodienthoai.Size = new Size(97, 20);
            lbSodienthoai.TabIndex = 21;
            lbSodienthoai.Text = "Số điện thoại";
            // 
            // btnThem
            // 
            btnThem.Location = new Point(399, 25);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 18;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // lbEmail
            // 
            lbEmail.AutoSize = true;
            lbEmail.Location = new Point(6, 180);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(46, 20);
            lbEmail.TabIndex = 22;
            lbEmail.Text = "Email";
            // 
            // lbDiachi
            // 
            lbDiachi.AutoSize = true;
            lbDiachi.Location = new Point(10, 228);
            lbDiachi.Name = "lbDiachi";
            lbDiachi.Size = new Size(55, 20);
            lbDiachi.TabIndex = 23;
            lbDiachi.Text = "Địa chỉ";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Location = new Point(152, 221);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Size = new Size(183, 27);
            txtDiaChi.TabIndex = 29;
            // 
            // lbGioitinh
            // 
            lbGioitinh.AutoSize = true;
            lbGioitinh.Location = new Point(11, 290);
            lbGioitinh.Name = "lbGioitinh";
            lbGioitinh.Size = new Size(65, 20);
            lbGioitinh.TabIndex = 25;
            lbGioitinh.Text = "Giới tính";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(152, 173);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(183, 27);
            txtEmail.TabIndex = 28;
            // 
            // txtTenKH
            // 
            txtTenKH.Location = new Point(152, 63);
            txtTenKH.Name = "txtTenKH";
            txtTenKH.Size = new Size(183, 27);
            txtTenKH.TabIndex = 26;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(152, 121);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(183, 27);
            txtSDT.TabIndex = 27;
            // 
            // dgvQLKH
            // 
            dgvQLKH.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvQLKH.Location = new Point(6, 419);
            dgvQLKH.Name = "dgvQLKH";
            dgvQLKH.RowHeadersWidth = 51;
            dgvQLKH.Size = new Size(1062, 222);
            dgvQLKH.TabIndex = 34;
            // 
            // FormQLKH
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1070, 645);
            Controls.Add(dgvQLKH);
            Controls.Add(cbGioiTinh);
            Controls.Add(txtMaKH);
            Controls.Add(btnLammoi);
            Controls.Add(btnXoa);
            Controls.Add(lbMaNV);
            Controls.Add(lbHoten);
            Controls.Add(btnSua);
            Controls.Add(lbSodienthoai);
            Controls.Add(btnThem);
            Controls.Add(lbEmail);
            Controls.Add(lbDiachi);
            Controls.Add(txtDiaChi);
            Controls.Add(lbGioitinh);
            Controls.Add(txtEmail);
            Controls.Add(txtTenKH);
            Controls.Add(txtSDT);
            Name = "FormQLKH";
            Text = "FormQLKH";
            Load += FormQLKH_Load;
            ((System.ComponentModel.ISupportInitialize)dgvQLKH).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbGioiTinh;
        private TextBox txtMaKH;
        private Button btnLammoi;
        private Button btnXoa;
        private Label lbMaNV;
        private Label lbHoten;
        private Button btnSua;
        private Label lbSodienthoai;
        private Button btnThem;
        private Label lbEmail;
        private Label lbDiachi;
        private TextBox txtDiaChi;
        private Label lbGioitinh;
        private TextBox txtEmail;
        private TextBox txtTenKH;
        private TextBox txtSDT;
        private DataGridView dgvQLKH;
    }
}