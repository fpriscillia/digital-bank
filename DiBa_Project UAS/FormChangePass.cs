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
    public partial class FormChangePass : Form
    {

        public Pengguna userPwd;

        public FormChangePass()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            FormUtama frm = (FormUtama)this.MdiParent;
            string oldPassword = textBoxCurrentPass.Text;
            string newPassword = textBoxNewPassword.Text;
            string reenterPassword = textBoxConfirmPass.Text;
            string email = frm.userLogin.Email;
            Pengguna p = frm.userLogin;
            Pengguna cekPass = Pengguna.CekLogin(email, oldPassword);
            if (cekPass is null)
            {
                MessageBox.Show("Password salah, Harap masukan password dengan tepat");
            }
            else
            {
                if (newPassword == reenterPassword)
                {
                    Pengguna ubah = new Pengguna(p.Nik, p.NamaDepan, p.NamaKeluarga, p.Alamat, p.Email,
                        p.NoTelepon, newPassword, p.Pin, p.TglBuat, DateTime.Now, p.JenisPngguna, p.Reward);
                    Pengguna.UbahPassword(ubah);
                    MessageBox.Show("Berhasil");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Konfirmasi password yang dimasukan berbeda");
                }
            }
        }
    }
}
