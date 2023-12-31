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
    public partial class FormTopUp : Form
    {
        public FormTopUp()
        {
            InitializeComponent();
        }

        FormUtama frm;

        private void FormTopUp_Load(object sender, EventArgs e)
        {
            frm = (FormUtama)this.MdiParent;
            textBoxNoRek.Text = frm.tabunganLogin.NoRekening;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            FormInputPin input = new FormInputPin();
            input.Owner = (FormUtama)this.MdiParent;
            input.ShowDialog();

            if (input.konfirmasi == true)
            {
                string norek = textBoxNoRek.Text;
                double nominal = double.Parse(textBoxNominal.Text);
                try
                {
                    if (frm.tabunganLogin.Status == "aktif")
                    {
                        Tabungan.UbahSaldo(norek, nominal);
                        string pesan = "Top Up saldo rekening " + norek + " sebesar Rp " + nominal;
                        Inbox.TambahData(frm.userLogin, pesan);
                        MessageBox.Show("Top Up telah berhasil");
                    }
                    else
                    {
                        MessageBox.Show("Akun Anda belum aktif atau terblokir, Anda tidak dapat melakukan transaksi. Harap hubungi pegawai DiBa.", "Info");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
