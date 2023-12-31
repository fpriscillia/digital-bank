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
    public partial class FormTambahAddressBookInternal : Form
    {
        public FormTambahAddressBookInternal()
        {
            InitializeComponent();
        }

        FormUtama frm;

        private void FormTambahAddressBookInternal_Load(object sender, EventArgs e)
        {
            frm = (FormUtama)this.MdiParent;
        }

        private void textBoxRekTujuan_TextChanged(object sender, EventArgs e)
        {
            Tabungan rek = Tabungan.BacaRekening(textBoxRekTujuan.Text);
            if (rek != null)
            {
                textBoxPemilikTujuan.Text = rek.Pemilik.NamaDepan + " " + rek.Pemilik.NamaKeluarga;
            }
        }

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
            AddressBookInternal abi = new AddressBookInternal();
            abi.IdPengguna = frm.userLogin;
            abi.NoRek = Tabungan.BacaData("no_rekening", textBoxRekTujuan.Text)[0];
            abi.Keterangan = textBoxKet.Text;

            try
            {
                AddressBookInternal.TambahData(abi);
                MessageBox.Show("Penyimpanan Address Book Berhasil");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
