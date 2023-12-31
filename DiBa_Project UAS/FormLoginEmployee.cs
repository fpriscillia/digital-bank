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
    public partial class FormLoginEmployee : Form
    {
        public FormLoginEmployee()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {

            string emailNoHp = textBoxEmailTelp.Text;
            string pwd = textBoxPassword.Text;
            Employee emp = Employee.CekLogin(emailNoHp, pwd);

            if (emp is null)
            {
                MessageBox.Show("Login gagal, akun tak ditemukan", "Informasi");
            }
            else
            {

                FormUtama form;
                form = (FormUtama)this.Owner;

                //ISI PUBLIC PARAM DI FRMUTAMA DG HASIL CEKLOGIN
                form.employeeLogin = emp;

                MessageBox.Show("Login berhasil, Welcome " + emp.NamaDepan + " " + emp.NamaKeluarga, "Informasi");
                form.Visible = true;
                form.labelNama.Text = "Hi, " + form.employeeLogin.NamaDepan + " " + form.employeeLogin.NamaKeluarga + " - " + form.employeeLogin.Posisi.Nama;
                this.Close(); //TUTUP FRMLOGIN
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["FormDepan"];
            if (f == null)
            {   //jika form yg dituju belum ada, ciptakan yg baru
                FormDepan frm = new FormDepan();
                frm.Owner = (FormUtama)this.Owner;
                frm.ShowDialog();
            }
            else
            {   //jika form yang dituju sdh ada, panggil yg lama
                f.Visible = true;
            }

            this.Close();
        }
    }
}
