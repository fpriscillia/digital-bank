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
    public partial class FormTransaksiEksternal : Form
    {
        public FormTransaksiEksternal()
        {
            InitializeComponent();
        }

        FormUtama frm;

        private void FormTransaksiEksternal_Load(object sender, EventArgs e)
        {
            frm = (FormUtama)this.MdiParent;
            textBoxRekInter.Text = frm.tabunganLogin.NoRekening;
        }

        private void buttonTransfer_Click(object sender, EventArgs e)
        {
            FormInputPin input = new FormInputPin();
            input.Owner = (FormUtama)this.MdiParent;
            input.ShowDialog();

            TransaksiEksternal te = new TransaksiEksternal();
            if (input.konfirmasi == true)
            {
                te.RekInternal = frm.tabunganLogin;
                te.Id = TransaksiEksternal.GenerateIdTransaksi(frm.tabunganLogin);
                te.Jenis = Jenis_Transaksi.BacaData("kode", "DBT")[0];
                
                te.RekEksternal = TabunganEksternal.BacaData(textBoxRekEksternal.Text);
                te.IdBank = te.RekEksternal.IdBank;
                te.Nominal = double.Parse(textBoxNominalEks.Text);
                te.Keterangan = textBoxKeteranganEks.Text;
                try
                {

                    TransaksiEksternal.TambahData(te);
                    Tabungan.UbahSaldo(te.RekInternal.NoRekening, -1 * te.Nominal); //mengurangi saldo rek sumber
                    Pengguna.UbahReward(frm.userLogin); //menambah reward pengguna
                    string pesan = "Transaksi " + te.Jenis + " dengan rekening eksternal " + te.RekEksternal.Nama + "-" +
                        te.RekEksternal.NoRekening + "\nNominal : Rp " + te.Nominal;
                    Inbox.TambahData(frm.userLogin, pesan); //menambah pesan ke inbox
                    MessageBox.Show("Transaksi telah berhasil.", "Info");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error.\nPesan Kesalahan: " + ex.Message);
                }
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxRekEksternal_TextChanged(object sender, EventArgs e)
        {
            TabunganEksternal rek = TabunganEksternal.BacaData(textBoxRekEksternal.Text);
            if (rek != null)
            {
                textBoxBank.Text = rek.IdBank.Nama;
                textBoxPemilikEksternal.Text = rek.Nama;
            }
        }

        private void buttonAddressBook_Click(object sender, EventArgs e)
        {
            FormDaftarAddressBookEksternal form = new FormDaftarAddressBookEksternal();
            form.Owner = this;
            form.p = frm.userLogin;
            form.ShowDialog();
            if (form.norek != "")
            {
                textBoxRekEksternal.Text = form.norek;
            }
        }
    }
}
