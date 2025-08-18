namespace PRO131_01.Forms
{
    partial class FormRegister
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
            lblNewUser = new Label();
            txtNewUser = new TextBox();
            txtNewPass = new TextBox();
            lblNewPass = new Label();
            lblRole = new Label();
            cboRole = new ComboBox();
            btnRegister = new Button();
            chkShowPassReg = new CheckBox();
            lblTitle = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblNewUser
            // 
            lblNewUser.AutoSize = true;
            lblNewUser.Location = new Point(118, 116);
            lblNewUser.Name = "lblNewUser";
            lblNewUser.Size = new Size(111, 20);
            lblNewUser.TabIndex = 0;
            lblNewUser.Text = "Tên đăng nhập ";
            // 
            // txtNewUser
            // 
            txtNewUser.Location = new Point(235, 113);
            txtNewUser.MaxLength = 50;
            txtNewUser.Name = "txtNewUser";
            txtNewUser.Size = new Size(260, 27);
            txtNewUser.TabIndex = 1;
            // 
            // txtNewPass
            // 
            txtNewPass.Location = new Point(235, 191);
            txtNewPass.MaxLength = 50;
            txtNewPass.Name = "txtNewPass";
            txtNewPass.Size = new Size(260, 27);
            txtNewPass.TabIndex = 3;
            txtNewPass.UseSystemPasswordChar = true;
            // 
            // lblNewPass
            // 
            lblNewPass.AutoSize = true;
            lblNewPass.Location = new Point(118, 194);
            lblNewPass.Name = "lblNewPass";
            lblNewPass.Size = new Size(74, 20);
            lblNewPass.TabIndex = 2;
            lblNewPass.Text = "Mật khẩu ";
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Location = new Point(118, 258);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(51, 20);
            lblRole.TabIndex = 4;
            lblRole.Text = "Quyền";
            // 
            // cboRole
            // 
            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRole.FormattingEnabled = true;
            cboRole.Location = new Point(209, 255);
            cboRole.Name = "cboRole";
            cboRole.Size = new Size(286, 28);
            cboRole.TabIndex = 5;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(135, 349);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(94, 29);
            btnRegister.TabIndex = 6;
            btnRegister.Text = "Đăng ký";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // chkShowPassReg
            // 
            chkShowPassReg.AutoSize = true;
            chkShowPassReg.Location = new Point(288, 352);
            chkShowPassReg.Name = "chkShowPassReg";
            chkShowPassReg.Size = new Size(127, 24);
            chkShowPassReg.TabIndex = 7;
            chkShowPassReg.Text = "Hiện mật khẩu";
            chkShowPassReg.UseVisualStyleBackColor = true;
            chkShowPassReg.CheckedChanged += chkShowPassReg_CheckedChanged;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = SystemColors.ActiveCaptionText;
            lblTitle.Location = new Point(372, 26);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(0, 46);
            lblTitle.TabIndex = 8;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(361, 9);
            label1.Name = "label1";
            label1.Size = new Size(144, 46);
            label1.TabIndex = 9;
            label1.Text = "Đăng Ký";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormRegister
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(943, 549);
            Controls.Add(label1);
            Controls.Add(lblTitle);
            Controls.Add(chkShowPassReg);
            Controls.Add(btnRegister);
            Controls.Add(cboRole);
            Controls.Add(lblRole);
            Controls.Add(txtNewPass);
            Controls.Add(lblNewPass);
            Controls.Add(txtNewUser);
            Controls.Add(lblNewUser);
            Name = "FormRegister";
            Text = "FormRegister";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNewUser;
        private TextBox txtNewUser;
        private TextBox txtNewPass;
        private Label lblNewPass;
        private Label lblRole;
        private ComboBox cboRole;
        private Button btnRegister;
        private CheckBox chkShowPassReg;
        private Label lblTitle;
        private Label label1;
    }
}