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
    public partial class FormLoginPengguna : Form
    {
        public FormLoginPengguna()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string emailNoHp = textBoxEmailTelp.Text;
            string pwd = textBoxPassword.Text;
            Pengguna u = Pengguna.CekLogin(emailNoHp, pwd);

            if (u is null)
            {
                MessageBox.Show("Login gagal, akun tak ditemukan", "Informasi");
            }
            else
            {
                FormUtama form;
                form = (FormUtama)this.Owner;

                //ISI PUBLIC PARAM DI FRMUTAMA DG HASIL CEKLOGIN
                form.userLogin = u;
                Tabungan t = Tabungan.CekLogin(u);
                form.tabunganLogin = t;

                if (t.Status != "nonaktif")
                {
                    MessageBox.Show("Login berhasil, Welcome " + u.NamaDepan + " " + u.NamaKeluarga, "Informasi");
                    if (t.Status == "aktif" && u.Pin == "0")
                    {
                        FormCreatePin frm = new FormCreatePin();
                        frm.Owner = (FormUtama)this.Owner;
                        frm.ShowDialog();
                    }
                    form.Visible = true;
                    form.labelNama.Text = "Hi, " + u.NamaDepan + " " + u.NamaKeluarga + " - " + u.JenisPngguna + " - " + form.tabunganLogin.NoRekening;
                    this.Close(); //TUTUP FRMLOGIN
                }
                else
                {
                    MessageBox.Show("Login gagal, tabungan telah dinonaktifkan", "Informasi");
                }
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
