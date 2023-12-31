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
    public partial class FormInbox : Form
    {
        public FormInbox()
        {
            InitializeComponent();
        }

        FormUtama frm;

        private void FormInbox_Load(object sender, EventArgs e)
        {
            frm = (FormUtama)this.MdiParent;

            //tampilkan list inbox yang dimiliki oleh userlogin
            List<Inbox> listData = Inbox.BacaData(frm.userLogin.Nik);
            dataGridViewInbox.DataSource = listData;

            if (dataGridViewInbox.ColumnCount == 6)
            {   //membuat button dalam datagrid
                DataGridViewButtonColumn b = new DataGridViewButtonColumn();
                b.HeaderText = "aksi";
                b.Text = "lihat";
                b.Name = "btnLihat";
                b.UseColumnTextForButtonValue = true;
                dataGridViewInbox.Columns.Add(b);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewInbox_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewInbox.Columns["btnLihat"].Index && e.RowIndex >= 0)
            {
                //mengambil objek pengguna dari kolom user
                Pengguna user = (Pengguna)dataGridViewInbox.CurrentRow.Cells["User"].Value;
                //mengambil id dari kolom id
                int id = int.Parse(dataGridViewInbox.CurrentRow.Cells["Id"].Value.ToString());
                //mengubah status inbox
                Inbox.UbahStatus(user, id, "dibaca");
                //menampilkan messagebox berisi pesan dari kolom pesan
                MessageBox.Show(dataGridViewInbox.CurrentRow.Cells["Pesan"].Value.ToString(), "Pesan :");
            }
            FormInbox_Load(this, e);
        }

        private void dateTimePickerTgl_ValueChanged(object sender, EventArgs e)
        {
            string pengguna = frm.userLogin.Nik;
            string tgl = dateTimePickerTgl.Value.ToString("yyyy-MM-dd");

            //menampilkan inbox milik userlogin pada tanggal yg dipilih
            List<Inbox> listData = Inbox.BacaData(pengguna, tgl);
            dataGridViewInbox.DataSource = listData;
        }

        private void buttonShowAll_Click(object sender, EventArgs e)
        {   //menampilkan semua inbox milik useerlogin
            List<Inbox> listData = Inbox.BacaData(frm.userLogin.Nik);
            dataGridViewInbox.DataSource = listData;
        }
    }
}
