namespace PRO131_01
{
    partial class Form1
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
            dataGridView1 = new DataGridView();
            label1 = new Label();
            textBoxMa = new TextBox();
            textBoxTen = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            RichTextBoxMoTa = new RichTextBox();
            numericUpDownSoLuong = new NumericUpDown();
            comboBoxLoaiSp = new ComboBox();
            buttonThem = new Button();
            buttonSua = new Button();
            buttonLamMoi = new Button();
            buttonXoa = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSoLuong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.Location = new Point(0, 516);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1170, 228);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 18);
            label1.Name = "label1";
            label1.Size = new Size(103, 20);
            label1.TabIndex = 1;
            label1.Text = "Mã Sản Phẩm ";
            label1.Click += label1_Click;
            // 
            // textBoxMa
            // 
            textBoxMa.Location = new Point(133, 15);
            textBoxMa.Name = "textBoxMa";
            textBoxMa.Size = new Size(174, 27);
            textBoxMa.TabIndex = 2;
            textBoxMa.TextChanged += textBox1_TextChanged;
            // 
            // textBoxTen
            // 
            textBoxTen.Location = new Point(481, 18);
            textBoxTen.Name = "textBoxTen";
            textBoxTen.Size = new Size(167, 27);
            textBoxTen.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(372, 21);
            label2.Name = "label2";
            label2.Size = new Size(100, 20);
            label2.TabIndex = 3;
            label2.Text = "Tên sản phẩm";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(699, 24);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 5;
            label3.Text = "Số lượng";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(508, 136);
            label4.Name = "label4";
            label4.Size = new Size(105, 20);
            label4.TabIndex = 7;
            label4.Text = "Loại sản phẩm";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(24, 175);
            label5.Name = "label5";
            label5.Size = new Size(48, 20);
            label5.TabIndex = 9;
            label5.Text = "Mô tả";
            // 
            // RichTextBoxMoTa
            // 
            RichTextBoxMoTa.Location = new Point(102, 130);
            RichTextBoxMoTa.Name = "RichTextBoxMoTa";
            RichTextBoxMoTa.Size = new Size(314, 120);
            RichTextBoxMoTa.TabIndex = 10;
            RichTextBoxMoTa.Text = "";
            // 
            // numericUpDownSoLuong
            // 
            numericUpDownSoLuong.Location = new Point(774, 24);
            numericUpDownSoLuong.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numericUpDownSoLuong.Name = "numericUpDownSoLuong";
            numericUpDownSoLuong.Size = new Size(202, 27);
            numericUpDownSoLuong.TabIndex = 11;
            numericUpDownSoLuong.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // comboBoxLoaiSp
            // 
            comboBoxLoaiSp.FormattingEnabled = true;
            comboBoxLoaiSp.Location = new Point(619, 133);
            comboBoxLoaiSp.Name = "comboBoxLoaiSp";
            comboBoxLoaiSp.Size = new Size(245, 28);
            comboBoxLoaiSp.TabIndex = 12;
            // 
            // buttonThem
            // 
            buttonThem.Location = new Point(173, 304);
            buttonThem.Name = "buttonThem";
            buttonThem.Size = new Size(94, 29);
            buttonThem.TabIndex = 13;
            buttonThem.Text = "Thêm ";
            buttonThem.UseVisualStyleBackColor = true;
            buttonThem.Click += buttonThem_Click;
            // 
            // buttonSua
            // 
            buttonSua.Location = new Point(322, 304);
            buttonSua.Name = "buttonSua";
            buttonSua.Size = new Size(94, 29);
            buttonSua.TabIndex = 14;
            buttonSua.Text = "Sửa ";
            buttonSua.UseVisualStyleBackColor = true;
            buttonSua.Click += buttonSua_Click;
            // 
            // buttonLamMoi
            // 
            buttonLamMoi.Location = new Point(632, 304);
            buttonLamMoi.Name = "buttonLamMoi";
            buttonLamMoi.Size = new Size(94, 29);
            buttonLamMoi.TabIndex = 15;
            buttonLamMoi.Text = "Làm mới";
            buttonLamMoi.UseVisualStyleBackColor = true;
            buttonLamMoi.Click += buttonLamMoi_Click;
            // 
            // buttonXoa
            // 
            buttonXoa.Location = new Point(481, 304);
            buttonXoa.Name = "buttonXoa";
            buttonXoa.Size = new Size(94, 29);
            buttonXoa.TabIndex = 16;
            buttonXoa.Text = "Xóa";
            buttonXoa.UseVisualStyleBackColor = true;
            buttonXoa.Click += buttonXoa_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(880, 163);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(278, 203);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 17;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1170, 744);
            Controls.Add(pictureBox1);
            Controls.Add(buttonXoa);
            Controls.Add(buttonLamMoi);
            Controls.Add(buttonSua);
            Controls.Add(buttonThem);
            Controls.Add(comboBoxLoaiSp);
            Controls.Add(numericUpDownSoLuong);
            Controls.Add(RichTextBoxMoTa);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBoxTen);
            Controls.Add(label2);
            Controls.Add(textBoxMa);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSoLuong).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private TextBox textBoxMa;
        private TextBox textBoxTen;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private RichTextBox RichTextBoxMoTa;
        private NumericUpDown numericUpDownSoLuong;
        private ComboBox comboBoxLoaiSp;
        private Button buttonThem;
        private Button buttonSua;
        private Button buttonLamMoi;
        private Button buttonXoa;
        private PictureBox pictureBox1;
    }
}
