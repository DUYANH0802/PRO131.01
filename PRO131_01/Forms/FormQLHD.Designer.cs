namespace PRO131_01.Forms
{
    partial class FormQLHD
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
            dgvHoaDon = new DataGridView();
            btnLamMoi = new Button();
            dgvChiTietHD = new DataGridView();
            btnXoa = new Button();
            dtpFrom = new DateTimePicker();
            dtpTo = new DateTimePicker();
            btnFilter = new Button();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietHD).BeginInit();
            SuspendLayout();
            // 
            // dgvHoaDon
            // 
            dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDon.Location = new Point(-1, 441);
            dgvHoaDon.Name = "dgvHoaDon";
            dgvHoaDon.RowHeadersWidth = 51;
            dgvHoaDon.Size = new Size(1381, 330);
            dgvHoaDon.TabIndex = 0;
            dgvHoaDon.CellClick += dgvHoaDon_CellContentClick;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(808, 349);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(94, 29);
            btnLamMoi.TabIndex = 1;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // dgvChiTietHD
            // 
            dgvChiTietHD.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTietHD.Location = new Point(0, 0);
            dgvChiTietHD.Name = "dgvChiTietHD";
            dgvChiTietHD.RowHeadersWidth = 51;
            dgvChiTietHD.Size = new Size(760, 378);
            dgvChiTietHD.TabIndex = 2;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(808, 286);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 3;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // dtpFrom
            // 
            dtpFrom.Location = new Point(1032, 178);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(250, 27);
            dtpFrom.TabIndex = 4;
            // 
            // dtpTo
            // 
            dtpTo.Location = new Point(1032, 226);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(250, 27);
            dtpTo.TabIndex = 5;
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(1122, 286);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(94, 29);
            btnFilter.TabIndex = 6;
            btnFilter.Text = "Lọc";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(969, 233);
            label2.Name = "label2";
            label2.Size = new Size(36, 20);
            label2.TabIndex = 8;
            label2.Text = "Đến";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(969, 184);
            label1.Name = "label1";
            label1.Size = new Size(26, 20);
            label1.TabIndex = 9;
            label1.Text = "Từ";
            // 
            // FormQLHD
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1378, 773);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(btnFilter);
            Controls.Add(dtpTo);
            Controls.Add(dtpFrom);
            Controls.Add(btnXoa);
            Controls.Add(dgvChiTietHD);
            Controls.Add(btnLamMoi);
            Controls.Add(dgvHoaDon);
            Name = "FormQLHD";
            Text = "FormQLHD";
            Load += FormQLHD_Load;
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietHD).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvHoaDon;
        private Button btnLamMoi;
        private DataGridView dgvChiTietHD;
        private Button btnXoa;
        private DateTimePicker dtpFrom;
        private DateTimePicker dtpTo;
        private Button btnFilter;
        private Label label2;
        private Label label1;
    }
}