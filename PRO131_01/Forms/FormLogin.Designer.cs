namespace PRO131_01.Forms
{
    partial class FormLogin
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
            txtUsername = new TextBox();
            label2 = new Label();
            txtPassword = new TextBox();
            chkShowPass = new CheckBox();
            btnLogin = new Button();
            lnkRegister = new LinkLabel();
            lblTitle = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(76, 125);
            label1.Name = "label1";
            label1.Size = new Size(111, 20);
            label1.TabIndex = 0;
            label1.Text = "Tên đăng nhập ";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(209, 125);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(211, 27);
            txtUsername.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(76, 188);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 2;
            label2.Text = "Mật khẩu ";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(209, 188);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(211, 27);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // chkShowPass
            // 
            chkShowPass.AutoSize = true;
            chkShowPass.Location = new Point(86, 242);
            chkShowPass.Name = "chkShowPass";
            chkShowPass.Size = new Size(127, 24);
            chkShowPass.TabIndex = 4;
            chkShowPass.Text = "Hiện mật khẩu";
            chkShowPass.UseVisualStyleBackColor = true;
            chkShowPass.CheckedChanged += chkShowPass_CheckedChanged;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(307, 242);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(94, 29);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Đăng nhập";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // lnkRegister
            // 
            lnkRegister.AutoSize = true;
            lnkRegister.Location = new Point(86, 295);
            lnkRegister.Name = "lnkRegister";
            lnkRegister.Size = new Size(63, 20);
            lnkRegister.TabIndex = 6;
            lnkRegister.TabStop = true;
            lnkRegister.Text = "Đăng ký";
            lnkRegister.LinkClicked += lnkRegister_LinkClicked;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = SystemColors.ActiveCaptionText;
            lblTitle.Location = new Point(396, 27);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(184, 46);
            lblTitle.TabIndex = 9;
            lblTitle.Text = "Đăng nhập";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormLogin
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1019, 524);
            Controls.Add(lblTitle);
            Controls.Add(lnkRegister);
            Controls.Add(btnLogin);
            Controls.Add(chkShowPass);
            Controls.Add(txtPassword);
            Controls.Add(label2);
            Controls.Add(txtUsername);
            Controls.Add(label1);
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormLogin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtUsername;
        private Label label2;
        private TextBox txtPassword;
        private CheckBox chkShowPass;
        private Button btnLogin;
        private LinkLabel lnkRegister;
        private Label lblTitle;
    }
}