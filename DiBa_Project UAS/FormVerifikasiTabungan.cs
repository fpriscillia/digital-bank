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
    public partial class FormVerifikasiTabungan : Form
    {
        public FormVerifikasiTabungan()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormVerifikasiTabungan_Load(object sender, EventArgs e)
        {
            if (radioButtonUnverified.Checked)
                radioButtonUnverified_CheckedChanged(this, e);
            else if (radioButtonSuspend.Checked)
                radioButtonSuspend_CheckedChanged(this, e);

            if (dataGridViewHasil.ColumnCount == 8)
            {
                DataGridViewButtonColumn b = new DataGridViewButtonColumn();
                b.HeaderText = "aksi";
                b.Text = "verifikasi/aktifkan";
                b.Name = "btnVerif";
                b.UseColumnTextForButtonValue = true;
                dataGridViewHasil.Columns.Add(b);
            }
        }

        private void dataGridViewHasil_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewHasil.Columns["btnVerif"].Index && e.RowIndex >= 0)
            {
                if (radioButtonUnverified.Checked)
                {
                    DialogResult dialog = MessageBox.Show("Yakin ingin verifikasi?", "Konfirmasi", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        FormUtama frm = (FormUtama)this.MdiParent;
                        Employee verifikator = frm.employeeLogin;
                        string norek = dataGridViewHasil.CurrentRow.Cells["norekening"].Value.ToString();
                        try
                        {
                            Tabungan.UbahStatus(verifikator, norek);
                            //menambah pesan ke inbox nasabah
                            Tabungan t = Tabungan.BacaData("no_rekening", norek)[0];
                            string pesan = "Tabungan Anda telah diaktifkan";
                            Inbox.TambahData(t.Pemilik, pesan);
                        }
                        catch(Exception x)
                        {
                            MessageBox.Show("Error: " + x.Message);
                        }
                    }
                }
                else if (radioButtonSuspend.Checked)
                {
                    DialogResult dialog = MessageBox.Show("Yakin ingin aktifkan akun?", "Konfirmasi", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        string norek = dataGridViewHasil.CurrentRow.Cells["norekening"].Value.ToString();
                        try
                        {
                            Tabungan.StatusSuspend("aktif", norek);
                            //menambah pesan ke inbox nasabah
                            Tabungan t = Tabungan.BacaData("no_rekening", norek)[0];
                            string pesan = "Tabungan Anda telah diaktifkan kembali";
                            Inbox.TambahData(t.Pemilik, pesan);
                        }
                        catch (Exception x)
                        {
                            MessageBox.Show("Error: " + x.Message);
                        }
                    }
                }
            }
            FormVerifikasiTabungan_Load(this, e);
        }

        private void radioButtonUnverified_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonUnverified.Checked == true)
            {
                List<Tabungan> listData = Tabungan.BacaData("status", "unverified");
                dataGridViewHasil.DataSource = listData;
            }
        }

        private void radioButtonSuspend_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSuspend.Checked == true)
            {
                List<Tabungan> listData = Tabungan.BacaData("status", "suspend");
                dataGridViewHasil.DataSource = listData;
            }
        }
    }
}
