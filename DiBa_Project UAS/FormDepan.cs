using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using diBa_LIB;

namespace DiBa_Project_UAS
{
    public partial class FormDepan : Form
    {
        public FormDepan()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            if (comboBoxRole.SelectedIndex == 0)
            {
                Form f = Application.OpenForms["FormLoginPengguna"];
                if (f == null)
                {   //jika form yg dituju belum ada, ciptakan yg baru
                    FormLoginPengguna frm = new FormLoginPengguna();
                    frm.Owner = (FormUtama)this.Owner;
                    frm.ShowDialog();
                }
                else
                {   //jika form yang dituju sdh ada, panggil yg lama
                    f.BringToFront();
                    f.ShowDialog();
                }
            }
            else
            {
                Form f = Application.OpenForms["FormLoginEmployee"];
                if (f == null)
                {   //jika form yg dituju belum ada, ciptakan yg baru
                    FormLoginEmployee frm = new FormLoginEmployee();
                    frm.Owner = (FormUtama)this.Owner;
                    frm.ShowDialog();
                }
                else
                {   //jika form yang dituju sdh ada, panggil yg lama
                    f.BringToFront();
                    f.ShowDialog();
                }
            }
        }

        private void buttonSignup_Click(object sender, EventArgs e)
        {
            if (comboBoxRole.SelectedIndex == 0)
            {
                this.Visible = false;

                Form f = Application.OpenForms["FormSignUpPengguna"];
                if (f == null)
                {   //jika form yg dituju belum ada, ciptakan yg baru
                    FormSignUpPengguna frm = new FormSignUpPengguna();
                    frm.Owner = (FormUtama)this.Owner;
                    frm.ShowDialog();
                }
                else
                {   //jika form yang dituju sdh ada, panggil yg lama
                    f.BringToFront();
                    f.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Anda tidak dapat SignUp sebagai Employee");
            }
            this.Visible = true;
        }

        private void FormDepan_Load(object sender, EventArgs e)
        {
            comboBoxRole.SelectedIndex = 0;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            FormUtama frm = (FormUtama)this.Owner;
            this.Hide();
            frm.Close();
            //Application.Exit();
        }
    }
}
