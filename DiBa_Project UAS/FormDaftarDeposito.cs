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
    public partial class FormDaftarDeposito : Form
    {
        public FormDaftarDeposito()
        {
            InitializeComponent();
        }
        FormUtama form;
        private void FormDaftarDeposito_Load(object sender, EventArgs e)
        {
            form = (FormUtama)this.MdiParent;
            FormatDatagrid();
            List<Deposito> listData = Deposito.BacaData("no_rekening",form.tabunganLogin.NoRekening);
            //dataGridViewPengguna.DataSource = listData;
            foreach(Deposito d in listData)
            {
                dataGridViewPengguna.Rows.Add(d.Id_deposito, d.No_rekening, d.Jatuh_tempo, d.Nominal, d.Bunga, d.Status, d.Tgl_buat, d.Tgl_perubahan);
            }

            if (dataGridViewPengguna.ColumnCount == 8)
            {
                DataGridViewButtonColumn b = new DataGridViewButtonColumn();
                b.HeaderText = "cair";
                b.Text = "cairkan";
                b.Name = "btnCair";
                b.UseColumnTextForButtonValue = true;
                dataGridViewPengguna.Columns.Add(b);
            }
        }

        private void FormatDatagrid()
        {
            dataGridViewPengguna.Columns.Clear();

            dataGridViewPengguna.Columns.Add("Id_deposito", "ID Deposito");
            dataGridViewPengguna.Columns.Add("no_rekening", "No Rekening");
            dataGridViewPengguna.Columns.Add("jatuh_tempo", "Jatuh Tempo");
            dataGridViewPengguna.Columns.Add("nominal", "Nominal");
            dataGridViewPengguna.Columns.Add("bunga", "Bunga");
            dataGridViewPengguna.Columns.Add("status", "Status");
            dataGridViewPengguna.Columns.Add("tgl_buat", "Tgl Buat");
            dataGridViewPengguna.Columns.Add("tgl_perubahan", "Tgl Ubah");

            dataGridViewPengguna.AllowUserToAddRows = false;
            dataGridViewPengguna.ReadOnly = true;
        }

        private void dataGridViewPengguna_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewPengguna.Columns["btnCair"].Index && e.RowIndex >= 0)
            {
                Deposito d = Deposito.BacaData("id_deposito",dataGridViewPengguna.CurrentRow.Cells["Id_deposito"].Value.ToString())[0];
                if (d.Status == "aktif")
                {
                    bool cektanggal = Deposito.CekPencairan(d, DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")));
                    DialogResult h;
                    if (cektanggal)
                    {
                        double bunga = d.Nominal * (d.Bunga / 100);
                        h = MessageBox.Show("Deposito Telah jatuh tempo,\nBunga yang anda dapatkan Rp." + bunga.ToString("N2") + " \nyakin mencairkan?", "Konfirmasi Cair", MessageBoxButtons.YesNo);
                    }
                    else
                    {
                        double pinalti = d.Nominal * 0.05;
                        h = MessageBox.Show("Deposito belum jatuh tempo, pencairan akan dikenakan Penalty sebesar Rp." + pinalti.ToString("N2") + "\nApakah yakin ingin mencairkan?", "Konfirmasi Cair", MessageBoxButtons.YesNo);
                    }
                    if (h == DialogResult.Yes)
                    {
                        try
                        {
                            Deposito.RequestCair(d.Id_deposito);
                            MessageBox.Show("Permohonan pencairan akan diproses");
                            FormDaftarDeposito_Load(this, e);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Deposito tidak dapat dicairkan", "Info");
                }
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
