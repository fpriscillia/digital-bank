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
    public partial class FormDaftarAddressBookEksternal : Form
    {
        public FormDaftarAddressBookEksternal()
        {
            InitializeComponent();
        }

        public string norek = "";
        public Pengguna p;

        private void FormDaftarAddressBookEksternal_Load(object sender, EventArgs e)
        {
            FormatDataGrid();
            p.ListAddressBookEksternal.Clear();
            Pengguna.BacaDataAddressBookEksternal(p);
            foreach (AddressBookEksternal abe in p.ListAddressBookEksternal)
            {
                string norek = abe.NoRek.NoRekening;
                string nama = abe.NoRek.Nama;
                string bank = abe.IdBank.Nama;
                string ket = abe.Keterangan;
                dataGridViewHasil.Rows.Add(norek, nama, bank, ket);
            }

            if (dataGridViewHasil.ColumnCount == 4)
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
            dataGridViewHasil.Columns.Add("Bank", "Bank");
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
