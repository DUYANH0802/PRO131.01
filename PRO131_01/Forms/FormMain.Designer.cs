namespace PRO131_01.Forms
{
    partial class FormMain
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
            AntdUI.MenuItem menuItem1 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem2 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem3 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem4 = new AntdUI.MenuItem();
            AntdUI.MenuItem menuItem5 = new AntdUI.MenuItem();
            menu1 = new AntdUI.Menu();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // menu1
            // 
            menu1.BackColor = SystemColors.ControlDark;
            menuItem1.ID = "bh";
            menuItem1.Text = "Bán Hàng";
            menuItem2.ID = "ql";
            menuItem3.ID = "qlsp";
            menuItem3.Text = "Quản lý sản phẩm";
            menuItem4.ID = "qlnv";
            menuItem4.Text = "Quản lý nhân viên";
            menuItem5.ID = "qlkh";
            menuItem5.Text = "Quản lý khách hàng ";
            menuItem2.Sub.Add(menuItem3);
            menuItem2.Sub.Add(menuItem4);
            menuItem2.Sub.Add(menuItem5);
            menuItem2.Text = "Quản lý";
            menu1.Items.Add(menuItem1);
            menu1.Items.Add(menuItem2);
            menu1.Location = new Point(12, 76);
            menu1.Name = "menu1";
            menu1.Size = new Size(200, 524);
            menu1.TabIndex = 0;
            menu1.Text = "menu1";
            menu1.SelectChanged += menu1_SelectChanged;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Location = new Point(218, 76);
            panel1.Name = "panel1";
            panel1.Size = new Size(1050, 595);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1266, 670);
            Controls.Add(panel1);
            Controls.Add(menu1);
            Name = "FormMain";
            Text = "FormMain";
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Menu menu1;
        private Panel panel1;
    }
}