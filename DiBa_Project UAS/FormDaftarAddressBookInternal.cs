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
    public partial class FormDaftarAddressBookInternal : Form
    {
        public FormDaftarAddressBookInternal()
        {
            InitializeComponent();
        }

        public string norek = "";
        public Pengguna p;

        private void FormDaftarAddressBook_Load(object sender, EventArgs e)
        {
            FormatDataGrid();
            p.ListAddressBookInternal.Clear();
            Pengguna.BacaDataAddressBookInternal(p);
            foreach (AddressBookInternal abi in p.ListAddressBookInternal)
            {
                string norek = abi.NoRek.NoRekening;
                string nama = abi.NoRek.Pemilik.NamaDepan + " " + abi.NoRek.Pemilik.NamaKeluarga;
                string ket = abi.Keterangan;
                dataGridViewHasil.Rows.Add(norek, nama, ket);
            }
            
            if (dataGridViewHasil.ColumnCount == 3)
            {
                DataGridViewButtonColumn b = new DataGridViewButtonColumn();
                b.HeaderText = "Transfer";
                b.Text = "pilih";
                b.Name = "btnPilih";
                b.UseColumnTextForButtonValue = true;
                dataGridViewHasil.Columns.Add(b);
            }
        }

        private void dataGridViewHasil_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewHasil.Columns["btnPilih"].Index && e.RowIndex >= 0)
            {
                norek = dataGridViewHasil.CurrentRow.Cells["NoRek"].Value.ToString();
                this.Close();
            }
        }

        private void FormatDataGrid()
        {
            dataGridViewHasil.Columns.Clear();

            dataGridViewHasil.Columns.Add("NoRek", "No Rekening");
            dataGridViewHasil.Columns.Add("NamaPemilik", "Nama");
            dataGridViewHasil.Columns.Add("Keterangan", "Keterangan");

            dataGridViewHasil.AllowUserToAddRows = false;
            dataGridViewHasil.ReadOnly = true;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }   
}
