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
    public partial class FormInputPin : Form
    {
        public FormInputPin()
        {
            InitializeComponent();
        }
        
        public bool konfirmasi;
        int cekPin = 0;

        private void buttonOke_Click(object sender, EventArgs e)
        {
            FormUtama frm = (FormUtama)this.Owner;
            string pin = textBoxPin.Text;
            try
            {
                if (Pengguna.CekPin(frm.userLogin, pin))
                {
                    konfirmasi = true;
                    this.Close();
                }
                else
                {
                    cekPin++;
                    konfirmasi = false;

                    if (cekPin < 3)
                    {
                        MessageBox.Show("Pin salah, harap isi pin Anda dengan benar");
                    }
                    else
                    {
                        Tabungan.StatusSuspend("suspend", frm.tabunganLogin.NoRekening);
                        MessageBox.Show("Pin salah, akun anda diblokir, harap hubungi Employee kami.");
                    }
                    textBoxPin.Text = "";
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Error: " + x.Message);
            }
        }
    }
}
