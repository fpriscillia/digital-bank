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
    public partial class FormCreatePin : Form
    {
        public FormCreatePin()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (textBoxPin.Text == textBoxConfirmPin.Text)
            {
                string pin = textBoxPin.Text;
                FormUtama frm = (FormUtama)this.Owner;
                Pengguna user = frm.userLogin;
                user.Pin = pin;
                try
                {
                    Pengguna.UbahPin(user);
                    //tambahkan pesan informasi ke inbox pengguna
                    string pesan = "Pin tabungan Anda telah dibuat,\nsekarang Anda dapat melakukan berbagai transaksi DiBa.";
                    Inbox.TambahData(user, pesan);
                    MessageBox.Show("Pin berhasil dibuat");
                    this.Close();
                }
                catch (Exception x)
                {
                    MessageBox.Show("Error: " + x.Message);
                }
            }
            else
            {
                textBoxPin.Text = "";
                textBoxConfirmPin.Text = "";
                MessageBox.Show("Pin dan konfirmasi pin tidak sama");
            }
        }
    }
}
