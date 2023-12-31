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
    public partial class FormTransaksiInternal : Form
    {
        public FormTransaksiInternal()
        {
            InitializeComponent();
        }

        FormUtama frm;

        private void FormTransaksiInternal_Load(object sender, EventArgs e)
        {
            frm = (FormUtama)this.MdiParent;
            textBoxRekInter.Text = frm.tabunganLogin.NoRekening;
        }
        
        private void buttonTransaksi_Click(object sender, EventArgs e)
        {
            
            FormInputPin input = new FormInputPin();
            input.Owner = (FormUtama)this.MdiParent;
            input.ShowDialog();

            Transaksi transaksi = new Transaksi();
            if (input.konfirmasi == true)
            {
                transaksi.RekSumber = frm.tabunganLogin;
                transaksi.Id = Transaksi.GenerateIdTransaksi(frm.tabunganLogin);
                transaksi.Jenis = Jenis_Transaksi.BacaData("kode", "DBT")[0];
                transaksi.TglTransaksi = DateTime.Now;
                transaksi.RekTujuan = Tabungan.BacaData("no_rekening",textBoxRekTujuan.Text)[0];
                transaksi.Nominal = int.Parse(textBoxNominalInter.Text);
                transaksi.Keterangan = textBoxKeteranganInter.Text;
                try
                {

                    Transaksi.TambahData(transaksi);
                    Tabungan.UbahSaldo(transaksi.RekSumber.NoRekening, -1 * transaksi.Nominal); //mengurangi saldo rek sumber
                    Tabungan.UbahSaldo(transaksi.RekTujuan.NoRekening, transaksi.Nominal); //menambah saldo rek tujuan
                    Pengguna.UbahReward(frm.userLogin); //menambah reward pengguna
                    string pesan = "Transfer internal ke rekening " + transaksi.RekTujuan.Pemilik.NamaDepan
                        + transaksi.RekTujuan.Pemilik.NamaKeluarga + "-" + transaksi.RekTujuan.NoRekening +
                        "\nNominal: Rp " + transaksi.Nominal;
                    Inbox.TambahData(frm.userLogin, pesan); //menambah pesan transaksi ke inbox
                    MessageBox.Show("Transaksi telah berhasil.", "Info");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error.\nPesan Kesalahan: " + ex.Message);
                }
            }
        }

        private void textBoxRekTujuan_TextChanged(object sender, EventArgs e)
        {
            Tabungan rek = Tabungan.BacaRekening(textBoxRekTujuan.Text);
            if (rek != null)
            {
                textBoxPemilikTujuan.Text = rek.Pemilik.NamaDepan + " " + rek.Pemilik.NamaKeluarga;
            }
        }

        private void buttonAddressBook_Click(object sender, EventArgs e)
        {
            FormDaftarAddressBookInternal form = new FormDaftarAddressBookInternal();
            form.Owner = this;
            form.p = frm.userLogin;
            form.ShowDialog();
            if (form.norek != "")
            {
                textBoxRekTujuan.Text = form.norek;
            }
        }
    }
}
