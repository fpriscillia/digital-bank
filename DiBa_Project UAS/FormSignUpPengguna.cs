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
    public partial class FormSignUpPengguna : Form
    {
        public FormSignUpPengguna()
        {
            InitializeComponent();
        }

        private void buttonSignup_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.Text.Equals(textBoxKonfirmPassword.Text) && textBoxNIK.Text != "" && (textBoxEmail.Text != "" || textBoxNoTelp.Text != ""))
            {
                Pengguna user = new Pengguna();

                user.Nik = textBoxNIK.Text;
                user.NamaDepan = textBoxNamaDepan.Text;
                user.NamaKeluarga = textBoxNamaBelakang.Text;
                user.Alamat = textBoxAlamat.Text;
                user.Email = textBoxEmail.Text;
                user.NoTelepon = textBoxNoTelp.Text;
                user.Password = textBoxPassword.Text;
                user.TglBuat = DateTime.Now;
                user.TglPerubahan = DateTime.Now;

                Tabungan tabungan = new Tabungan();
                tabungan.NoRekening = Tabungan.GenerateNoRek();
                tabungan.Pemilik = user;
                tabungan.TglBuat = DateTime.Now;
                tabungan.TglPerubahan = DateTime.Now;
                
                try
                {
                    Pengguna.TambahData(user);
                    Tabungan.TambahData(tabungan);
                    string pesan = "Hai " + user.NamaDepan + "! Selamat datang di DiBa.";
                    Inbox.TambahData(user, pesan);
                    MessageBox.Show("Registrasi Telah Berhasil! Harap lakukan login dengan akun anda.", "Info");

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error.\nPesan Kesalahan: " + ex.Message);
                }
            }
            else if (textBoxNIK.Text == "")
            {
                MessageBox.Show("Harap isi NIK anda untuk membuat akun");
                textBoxNIK.Focus();
            }
            else if (textBoxEmail.Text == "")
            {
                MessageBox.Show("Harap isi email anda untuk membuat akun");
                textBoxEmail.Focus();
            }
            else
            {
                MessageBox.Show("Konfirmasi password tidak sama");
                textBoxKonfirmPassword.Text = "";
                textBoxPassword.Text = "";
                textBoxPassword.Focus();
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
