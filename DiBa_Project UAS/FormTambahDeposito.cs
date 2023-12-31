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
    public partial class FormTambahDeposito : Form
    {
        public FormTambahDeposito()
        {
            InitializeComponent();
        }

        FormUtama form;

        private void FormTambahDeposito_Load(object sender, EventArgs e)
        {
            comboBoxKriteria.SelectedIndex = 0;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            FormInputPin input = new FormInputPin();
            input.Owner = (FormUtama)this.MdiParent;
            input.ShowDialog();

            if (input.konfirmasi == true)
            {
                form = (FormUtama)this.MdiParent;
                double nominal = double.Parse(textBoxNominal.Text);
                string durasi = comboBoxKriteria.Text;
                Deposito d = new Deposito();
                if (durasi == "1 bulan")
                {
                    d.Bunga = 3;
                }
                else if (durasi == "3 bulan")
                {
                    d.Bunga = 5;
                }
                else if (durasi == "6 bulan")
                {
                    d.Bunga = 6;
                }
                else
                {
                    d.Bunga = 8;
                }

                d.Nominal = nominal;
                d.Jatuh_tempo = durasi;
                d.Id_deposito = Deposito.GenerateNoDeposit(form.tabunganLogin);
                d.No_rekening = form.tabunganLogin;
                try
                {
                    //STEP2 PANGGIL METHOD TAMBAH DATA
                    Deposito.TambahData(d, form.tabunganLogin);
                    string pesan = "Anda mengajukan pembukaan deposito jangka waktu " + d.Jatuh_tempo + " dengan nominal Rp " + d.Nominal;
                    Inbox.TambahData(form.userLogin, pesan);
                    MessageBox.Show("Pengajuan buka deposito akan diproses");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
