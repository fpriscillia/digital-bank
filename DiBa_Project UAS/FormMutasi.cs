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
    public partial class FormMutasi : Form
    {
        public FormMutasi()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCetak_Click(object sender, EventArgs e)
        {
            FormUtama frm = (FormUtama)this.MdiParent;
            string jenis = "";
            if (comboBoxJenis.Text == "Debit")
                jenis = "1";
            else if (comboBoxJenis.Text == "Credit")
                jenis = "2";
            string tglMulai = dateTimePickerMulai.Value.ToString("yyyy-MM-dd");
            string tglAkhir = dateTimePickerAkhir.Value.ToString("yyyy-MM-dd");

            Transaksi.CetakTransaksi(frm.tabunganLogin, jenis, tglMulai, tglAkhir);
        }

        private void FormMutasi_Load(object sender, EventArgs e)
        {
            comboBoxJenis.SelectedIndex = 0;
        }
    }
}
