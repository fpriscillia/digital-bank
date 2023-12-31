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
    public partial class FormDaftarTabungan : Form
    {
        public FormDaftarTabungan()
        {
            InitializeComponent();
        }

        private void FormDaftarTabungan_Load(object sender, EventArgs e)
        {
            List<Tabungan> listData = Tabungan.BacaData();
            dataGridViewHasil.DataSource = listData;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSemua_Click(object sender, EventArgs e)
        {
            List<Tabungan> listData = Tabungan.BacaData();
            dataGridViewHasil.DataSource = listData;
        }

        private void buttonCari_Click(object sender, EventArgs e)
        {
            string kolom = "";
            string nilai = textBoxKriteria.Text;

            if (comboBoxKriteria.SelectedIndex == 0)
                kolom = "no_rekening";
            else if (comboBoxKriteria.SelectedIndex == 1)
                kolom = "id_pengguna";

            //tampilkan list employee hasil filter
            List<Tabungan> listData = Tabungan.BacaData(kolom, nilai);
            dataGridViewHasil.DataSource = listData;
        }
    }
}
