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
    public partial class FormChangeProfile : Form
    {

        public Pengguna objYangDiUbah;

        public FormChangeProfile()
        {
            InitializeComponent();
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            objYangDiUbah.Nik = textBoxNIK.Text;
            objYangDiUbah.NamaDepan = textBoxNamaDepan.Text;
            objYangDiUbah.NamaKeluarga = textBoxNamaBelakang.Text;
            objYangDiUbah.Email = textBoxEmail.Text;
            objYangDiUbah.Alamat = textBoxAlamat.Text;
            objYangDiUbah.NoTelepon = textBoxNoTelp.Text;
            objYangDiUbah.TglPerubahan = DateTime.Now;

            try
            {
                //PANGGIL METHOD UBAH DATA
                Pengguna.UbahData(objYangDiUbah);
                FormUtama f = new FormUtama();
                f = (FormUtama)this.MdiParent;
                f.labelNama.Text = "Hi, " + objYangDiUbah.NamaDepan + " " + objYangDiUbah.NamaKeluarga + ", " + objYangDiUbah.JenisPngguna;
                MessageBox.Show("Pengubahan data berhasil");
                this.Close();
                FormChangeProfile_Load(this, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void FormChangeProfile_Load(object sender, EventArgs e)
        {
           
            FormUtama frm = new FormUtama();
            frm = (FormUtama)this.MdiParent;
            labelNama.Text = objYangDiUbah.NamaDepan + " " + objYangDiUbah.NamaKeluarga;
            labelJenis.Text = objYangDiUbah.JenisPngguna.Nama;
            textBoxNIK.Text = objYangDiUbah.Nik;
            textBoxNamaDepan.Text = objYangDiUbah.NamaDepan;
            textBoxNamaBelakang.Text = objYangDiUbah.NamaKeluarga;
            textBoxAlamat.Text = objYangDiUbah.Alamat;
            textBoxNoTelp.Text = objYangDiUbah.NoTelepon;
            textBoxEmail.Text = objYangDiUbah.Email;
        }
    }
}
