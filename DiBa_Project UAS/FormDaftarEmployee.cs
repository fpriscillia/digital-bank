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
    public partial class FormDaftarEmployee : Form
    {
        public FormDaftarEmployee()
        {
            InitializeComponent();
        }

        private void FormDaftarEmployee_Load(object sender, EventArgs e)
        {            
            //tampilkan list employee di datagrid
            List<Employee> listData = Employee.BacaData();
            dataGridViewPengguna.DataSource = listData;

            if (dataGridViewPengguna.ColumnCount == 9)
            {   // membuat button dalam datagridview
                DataGridViewButtonColumn b1 = new DataGridViewButtonColumn();
                b1.HeaderText = "aksi"; //judul kolom
                b1.Text = "ubah"; //text pada button
                b1.Name = "btnUbah"; //nama button dalam programming
                b1.UseColumnTextForButtonValue = true; //tampilkan text pada button
                dataGridViewPengguna.Columns.Add(b1); //tambahkan button ke gridview
            }
        }

        private void dataGridViewPengguna_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewPengguna.Columns["btnUbah"].Index && e.RowIndex >= 0)
            {   //buat formubahpegawai dulu (kopi dari tambahpegawai)
                FormUbahEmployee frm = new FormUbahEmployee();
                frm.Owner = this;
                string id = dataGridViewPengguna.CurrentRow.Cells["Id"].Value.ToString();
                List<Employee> listData = Employee.BacaData("e.id", id); //menghasilkan 1data saja
                frm.objYangDiUbah = listData[0]; //ambil data pertama dari list
                frm.ShowDialog();
            }
            FormDaftarEmployee_Load(this, e); 
        }


        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonTambah_Click(object sender, EventArgs e)
        {
            FormTambahEmployee frm = new FormTambahEmployee();
            frm.Owner = this;
            frm.ShowDialog();
            FormDaftarEmployee_Load(this, e);
        }

        private void buttonCari_Click(object sender, EventArgs e)
        {
            string kolom = "";
            string nilai = textBoxKriteria.Text;

            if (comboBoxKriteria.SelectedIndex == 0)
                kolom = "e.id";
            else if (comboBoxKriteria.SelectedIndex == 1)
                kolom = "e.nama_depan";
            else if (comboBoxKriteria.SelectedIndex == 2)
                kolom = "e.nama_keluarga";
            else if (comboBoxKriteria.SelectedIndex == 3)
                kolom = "p.nama";
            else if (comboBoxKriteria.SelectedIndex == 4)
                kolom = "e.nik";
            else if (comboBoxKriteria.SelectedIndex == 5)
                kolom = "e.email";

            //tampilkan list employee hasil filter
            List<Employee> listData = Employee.BacaData(kolom, nilai);
            dataGridViewPengguna.DataSource = listData;
        }

        private void buttonSemua_Click(object sender, EventArgs e)
        {
            List<Employee> listData = Employee.BacaData();
            dataGridViewPengguna.DataSource = listData;
        }
    }
}
