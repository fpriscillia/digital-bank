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
    public partial class FormTambahAddressBookEksternal : Form
    {
        public FormTambahAddressBookEksternal()
        {
            InitializeComponent();
        }

        FormUtama frm;
        private void FormTambahAddressBookEksternal_Load(object sender, EventArgs e)
        {
            frm = (FormUtama)this.MdiParent;
        }

        private void textBoxRekTujuan_TextChanged(object sender, EventArgs e)
        {
            TabunganEksternal rek = TabunganEksternal.BacaData(textBoxRekTujuan.Text);
            if (rek != null)
            {
                textBoxBank.Text = rek.IdBank.Nama;
                textBoxPemilik.Text = rek.Nama;
            }
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            AddressBookEksternal abe = new AddressBookEksternal();
            abe.IdPengguna = frm.userLogin;
            abe.NoRek = TabunganEksternal.BacaData(textBoxRekTujuan.Text);
            abe.IdBank = abe.NoRek.IdBank;
            abe.Keterangan = textBoxKet.Text;

            try
            {
                AddressBookEksternal.TambahData(abe);
                MessageBox.Show("Penyimpanan Address Book Berhasil");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
