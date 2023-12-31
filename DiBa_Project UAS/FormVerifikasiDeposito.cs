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
    public partial class FormVerifikasiDeposito : Form
    {
        public FormVerifikasiDeposito()
        {
            InitializeComponent();
        }
        FormUtama form;
        private void FormVerifikasiDeposito_Load(object sender, EventArgs e)
        {        
            List<Deposito> listData = Deposito.BacaData("status", "unverified"); //parameter menggunakan default value
            dataGridViewPengguna.DataSource = listData;

            if (dataGridViewPengguna.ColumnCount == 10)
            {   // membuat button dalam datagridview
                DataGridViewButtonColumn b1 = new DataGridViewButtonColumn();
                b1.HeaderText = "Verifikasi"; //judul kolom
                b1.Text = "Verif"; //text pada button
                b1.Name = "btnVerif"; //nama button dalam programming
                b1.UseColumnTextForButtonValue = true; //tampilkan text pada button
                dataGridViewPengguna.Columns.Add(b1); //tambahkan button ke gridview
            }
        }

        private void dataGridViewPengguna_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewPengguna.Columns["btnVerif"].Index && e.RowIndex >= 0)
            {
                DialogResult h = MessageBox.Show("Verifikasi deposito?", "Konfirmasi", MessageBoxButtons.YesNo);
                if (h == DialogResult.Yes)
                {
                    string id = dataGridViewPengguna.CurrentRow.Cells["Id_deposito"].Value.ToString();
                    Tabungan t = Tabungan.BacaData("no_rekening", dataGridViewPengguna.CurrentRow.Cells["No_rekening"].Value.ToString())[0];
                    try
                    {
                        form = (FormUtama)this.MdiParent;
                        Deposito.Verif(id, form.employeeLogin);
                        string pesan = "Pembukaan deposito telah diverifikasi";
                        Inbox.TambahData(t.Pemilik, pesan);
                        MessageBox.Show("Verifikasi Berhasil");
                        FormVerifikasiDeposito_Load(this, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBoxKriteria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
