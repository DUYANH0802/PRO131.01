using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRO131_01.Forms
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            AutoSize=true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        Form? currentForm;

        private void ChangeForm(Form form)
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }

            currentForm = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Show();
            panel1.Controls.Add(form);
            form.BringToFront();
        }


        private void menu1_SelectChanged(object sender, AntdUI.MenuSelectEventArgs e)
        {
            switch (e.Value.ID)
            {
                default:
                    break;
                case "qlsp":
                    {
                        ChangeForm(new Form1());
                        break;
                    }
                case "qlkh":
                    {
                        ChangeForm(new FormQLKH());
                        break;
                    }
                case "qlnv":
                    {
                        ChangeForm(new FormQLNV());
                        break;
                    }
            }
        }
    }
}
