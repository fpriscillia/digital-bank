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
    public partial class FormCairDeposito : Form
    {
        public FormCairDeposito()
        {
            InitializeComponent();
        }

        FormUtama form;

        private void FormCairDeposito_Load(object sender, EventArgs e)
        {
            List<Deposito> listData = Deposito.BacaData("status", "cair"); //parameter menggunakan default value
            dataGridViewPengguna.DataSource = listData;

            if (dataGridViewPengguna.ColumnCount == 10)
            {
                DataGridViewButtonColumn b2 = new DataGridViewButtonColumn();
                b2.HeaderText = "Pencairan"; //judul kolom
                b2.Text = "Cair"; //text pada button
                b2.Name = "btnCair"; //nama button dalam programming
                b2.UseColumnTextForButtonValue = true; //tampilkan text pada button
                dataGridViewPengguna.Columns.Add(b2); //tambahkan button ke gridview
            }
        }

        private void dataGridViewPengguna_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewPengguna.Columns["btnCair"].Index && e.RowIndex >= 0)
            {
                DialogResult h = MessageBox.Show("Cairkan deposito?", "Konfirmasi", MessageBoxButtons.YesNo);
                if (h == DialogResult.Yes)
                {
                    Deposito d = Deposito.BacaData("id_deposito", dataGridViewPengguna.CurrentRow.Cells["Id_deposito"].Value.ToString())[0];
                    try
                    {
                        form = (FormUtama)this.MdiParent;
                        Deposito.Pencairan(d, d.No_rekening, DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")), form.employeeLogin);
                        
                        //tambahkan pesan ke inbox pengguna
                        Tabungan tab = Tabungan.BacaData("no_rekening", dataGridViewPengguna.CurrentRow.Cells["No_rekening"].Value.ToString())[0];
                        string pesan = "Pencairan deposito No. " + d.Id_deposito;
                        Inbox.TambahData(tab.Pemilik, pesan);
                        
                        MessageBox.Show("Pencairan Berhasil");
                        FormCairDeposito_Load(this, e);
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

        private void textBoxKriteria_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
