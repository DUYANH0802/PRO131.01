namespace PRO131_01.Forms
{
    partial class FormQLNV
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
            btnThem = new Button();
            lbMaNV = new Label();
            lbHoten = new Label();
            lbSodienthoai = new Label();
            lbEmail = new Label();
            lbDiachi = new Label();
            txtMaNV = new TextBox();
            lbGioitinh = new Label();
            txtHoten = new TextBox();
            txtSDT = new TextBox();
            txtEmail = new TextBox();
            txtDiachi = new TextBox();
            btnSua = new Button();
            btnLammoi = new Button();
            btnXoa = new Button();
            dgvQLNV = new DataGridView();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            cbGioitinh = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvQLNV).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnThem
            // 
            btnThem.Location = new Point(411, 44);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 1;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // lbMaNV
            // 
            lbMaNV.AutoSize = true;
            lbMaNV.Location = new Point(23, 27);
            lbMaNV.Name = "lbMaNV";
            lbMaNV.Size = new Size(97, 20);
            lbMaNV.TabIndex = 2;
            lbMaNV.Text = "Mã nhân viên";
            // 
            // lbHoten
            // 
            lbHoten.AutoSize = true;
            lbHoten.Location = new Point(23, 82);
            lbHoten.Name = "lbHoten";
            lbHoten.Size = new Size(54, 20);
            lbHoten.TabIndex = 3;
            lbHoten.Text = "Họ tên";
            // 
            // lbSodienthoai
            // 
            lbSodienthoai.AutoSize = true;
            lbSodienthoai.Location = new Point(18, 147);
            lbSodienthoai.Name = "lbSodienthoai";
            lbSodienthoai.Size = new Size(97, 20);
            lbSodienthoai.TabIndex = 4;
            lbSodienthoai.Text = "Số điện thoại";
            // 
            // lbEmail
            // 
            lbEmail.AutoSize = true;
            lbEmail.Location = new Point(18, 199);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(46, 20);
            lbEmail.TabIndex = 5;
            lbEmail.Text = "Email";
            // 
            // lbDiachi
            // 
            lbDiachi.AutoSize = true;
            lbDiachi.Location = new Point(22, 247);
            lbDiachi.Name = "lbDiachi";
            lbDiachi.Size = new Size(55, 20);
            lbDiachi.TabIndex = 6;
            lbDiachi.Text = "Địa chỉ";
            // 
            // txtMaNV
            // 
            txtMaNV.Location = new Point(164, 27);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.Size = new Size(183, 27);
            txtMaNV.TabIndex = 7;
            // 
            // lbGioitinh
            // 
            lbGioitinh.AutoSize = true;
            lbGioitinh.Location = new Point(23, 309);
            lbGioitinh.Name = "lbGioitinh";
            lbGioitinh.Size = new Size(65, 20);
            lbGioitinh.TabIndex = 8;
            lbGioitinh.Text = "Giới tính";
            // 
            // txtHoten
            // 
            txtHoten.Location = new Point(164, 82);
            txtHoten.Name = "txtHoten";
            txtHoten.Size = new Size(183, 27);
            txtHoten.TabIndex = 9;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(164, 140);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(183, 27);
            txtSDT.TabIndex = 10;
            txtSDT.KeyPress += txtSDT_KeyPress;
            txtSDT.Leave += txtSDT_Leave;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(164, 192);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(183, 27);
            txtEmail.TabIndex = 11;
            txtEmail.Leave += txtEmail_Leave;
            // 
            // txtDiachi
            // 
            txtDiachi.Location = new Point(164, 240);
            txtDiachi.Name = "txtDiachi";
            txtDiachi.Size = new Size(183, 27);
            txtDiachi.TabIndex = 12;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(411, 95);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 14;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnLammoi
            // 
            btnLammoi.Location = new Point(411, 192);
            btnLammoi.Name = "btnLammoi";
            btnLammoi.Size = new Size(94, 29);
            btnLammoi.TabIndex = 15;
            btnLammoi.Text = "Làm mới";
            btnLammoi.UseVisualStyleBackColor = true;
            btnLammoi.Click += btnLammoi_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(411, 143);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 16;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // dgvQLNV
            // 
            dgvQLNV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableLayoutPanel1.SetColumnSpan(dgvQLNV, 2);
            dgvQLNV.Dock = DockStyle.Bottom;
            dgvQLNV.Location = new Point(3, 356);
            dgvQLNV.Name = "dgvQLNV";
            dgvQLNV.RowHeadersWidth = 51;
            dgvQLNV.Size = new Size(1132, 226);
            dgvQLNV.TabIndex = 18;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(dgvQLNV, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 60.34188F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 39.65812F));
            tableLayoutPanel1.Size = new Size(1138, 585);
            tableLayoutPanel1.TabIndex = 19;
            // 
            // panel1
            // 
            panel1.Controls.Add(cbGioitinh);
            panel1.Controls.Add(txtMaNV);
            panel1.Controls.Add(btnLammoi);
            panel1.Controls.Add(btnXoa);
            panel1.Controls.Add(lbMaNV);
            panel1.Controls.Add(lbHoten);
            panel1.Controls.Add(btnSua);
            panel1.Controls.Add(lbSodienthoai);
            panel1.Controls.Add(btnThem);
            panel1.Controls.Add(lbEmail);
            panel1.Controls.Add(lbDiachi);
            panel1.Controls.Add(txtDiachi);
            panel1.Controls.Add(lbGioitinh);
            panel1.Controls.Add(txtEmail);
            panel1.Controls.Add(txtHoten);
            panel1.Controls.Add(txtSDT);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(563, 347);
            panel1.TabIndex = 20;
            // 
            // cbGioitinh
            // 
            cbGioitinh.FormattingEnabled = true;
            cbGioitinh.Location = new Point(164, 301);
            cbGioitinh.Name = "cbGioitinh";
            cbGioitinh.Size = new Size(183, 28);
            cbGioitinh.TabIndex = 17;
            // 
            // FormQLNV
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1138, 585);
            Controls.Add(tableLayoutPanel1);
            Name = "FormQLNV";
            Text = "FormQLNV";
            ((System.ComponentModel.ISupportInitialize)dgvQLNV).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnThem;
        private Label lbMaNV;
        private Label lbHoten;
        private Label lbSodienthoai;
        private Label lbEmail;
        private Label lbDiachi;
        private TextBox txtMaNV;
        private Label lbGioitinh;
        private TextBox txtHoten;
        private TextBox txtSDT;
        private TextBox txtEmail;
        private TextBox txtDiachi;
        private Button btnSua;
        private Button btnLammoi;
        private Button btnXoa;
        private DataGridView dgvQLNV;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private ComboBox cbGioitinh;
    }
}