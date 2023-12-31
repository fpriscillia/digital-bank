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
    public partial class FormUbahEmployee : Form
    {
        public FormUbahEmployee()
        {
            InitializeComponent();
        }

        public Employee objYangDiUbah; 

        private void buttonSimpan_Click(object sender, EventArgs e)
        {
           
            objYangDiUbah.NamaDepan = textBoxNamaDepan.Text;
            objYangDiUbah.NamaKeluarga = textBoxNamaBelakang.Text;
            objYangDiUbah.Email = textBoxEmail.Text;
            objYangDiUbah.TglPerubahan = DateTime.Now;
            objYangDiUbah.Posisi = (Position)comboBoxJabatan.SelectedItem;

            try
            {
                Employee.UbahData(objYangDiUbah);
                MessageBox.Show("Pengubahan data berhasil");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void FormUbahEmployee_Load(object sender, EventArgs e)
        {
            //isi combobox sesuai isi database tabel posisi
            List<Position> listData = Position.BacaData();
            comboBoxJabatan.DataSource = listData;
            comboBoxJabatan.DisplayMember = "Nama";

            //isi textbox sesuai dengan isian objek yang akan diubah
            textBoxNamaDepan.Text = objYangDiUbah.NamaDepan;
            textBoxNamaBelakang.Text = objYangDiUbah.NamaKeluarga;
            textBoxNIK.Text = objYangDiUbah.Nik;
            textBoxEmail.Text = objYangDiUbah.Email;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
