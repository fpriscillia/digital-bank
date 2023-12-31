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
    public partial class FormUtama : Form
    {
        public Pengguna userLogin;
        public Employee employeeLogin;
        public Tabungan tabunganLogin;

        //buat list untuk menampung form child agar bisa ditutup serentak saat logout
        public List<Form> listForm = new List<Form>();

        public FormUtama()
        {
            InitializeComponent();
        }

        private void FormUtama_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Visible = false;

            try
            {
                //Ambil nilai di db setting
                Koneksi k = new Koneksi();
                MessageBox.Show("Koneksi Berhasil");

                FormDepan frm = new FormDepan();
                frm.Owner = this;
                frm.ShowDialog();

                AturMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Koneksi Gagal.\nPesan Kesalahan : " + ex.Message);
                Application.Exit();
            }
        }

        private void AturMenu()
        {
            if (userLogin != null)
            {
                accountToolStripMenuItem.Visible = true;
                infoToolStripMenuItem.Visible = true;
                mutasiToolStripMenuItem.Visible = true;
                topUpSaldoToolStripMenuItem.Visible = true;
                daftarTabunganToolStripMenuItem.Visible = false;
                verifikasiToolStripMenuItem.Visible = false;
                tambahToolStripMenuItem.Visible = true;
                daftarDepositoToolStripMenuItem.Visible = true;
                verifikasiDepositoToolStripMenuItem.Visible = false;
                pencairanDepositoToolStripMenuItem.Visible = false;
                transaksiToolStripMenuItem.Visible = true;
                inboxToolStripMenuItem.Visible = true;
                employeeToolStripMenuItem.Visible = false;

            }
            else if (employeeLogin != null)
            {
                accountToolStripMenuItem.Visible = false;
                infoToolStripMenuItem.Visible = false;
                mutasiToolStripMenuItem.Visible = false;
                topUpSaldoToolStripMenuItem.Visible = false;
                daftarTabunganToolStripMenuItem.Visible = true;
                verifikasiToolStripMenuItem.Visible = true;
                tambahToolStripMenuItem.Visible = false;
                daftarDepositoToolStripMenuItem.Visible = false;
                verifikasiDepositoToolStripMenuItem.Visible = true;
                pencairanDepositoToolStripMenuItem.Visible = true;
                transaksiToolStripMenuItem.Visible = false;
                inboxToolStripMenuItem.Visible = false;
                if (employeeLogin.Posisi.Id == 1)
                {
                    employeeToolStripMenuItem.Visible = true;
                }
                else
                {
                    employeeToolStripMenuItem.Visible = false;
                }
            }
        }

        private void changeProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //cek di memory, form yg dituju sdh ada/tidak
            Form f = Application.OpenForms["FormChangeProfile"];
            if (f == null)
            {   //jika form yg dituju belum ada, ciptakan yg baru
                FormChangeProfile frm = new FormChangeProfile();
                frm.MdiParent = this;
                listForm.Add(frm);
                frm.objYangDiUbah = userLogin;
                frm.Show();
            }
            else
            {   //jika form yang dituju sdh ada, panggil yg lama
                f.BringToFront();
                f.Show();
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //cek di memory, form yg dituju sdh ada/tidak
            Form f = Application.OpenForms["FormChangePass"];
            if (f == null)
            {   //jika form yg dituju belum ada, ciptakan yg baru
                FormChangePass frm = new FormChangePass();
                frm.MdiParent = this;
                listForm.Add(frm);
                frm.Show();
            }
            else
            {   //jika form yang dituju sdh ada, panggil yg lama
                f.BringToFront();
                f.Show();
            }
        }

        private void daftarTransaksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form f = Application.OpenForms["FormDaftarJenisTransaksi"];
            //if (f == null)
            //{   //jika form yg dituju belum ada, ciptakan yg baru
            //    FormDaftarJenisTransaksi frm = new FormDaftarJenisTransaksi();
            //    frm.MdiParent = this;
            //    listForm.Add(frm);
            //    frm.Show();
            //}
            //else
            //{   //jika form yang dituju sdh ada, panggil yg lama
            //    f.BringToFront();
            //    f.Show();
            //}
        }

        private void closeSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userLogin = null;
            employeeLogin = null;
            foreach (Form frm in listForm)
            {
                frm.Close();
            }
            
            FormUtama_Load(this, e);
        }

        private void inboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["FormInbox"];
            if (f == null)
            {   //jika form yg dituju belum ada, ciptakan yg baru
                FormInbox frm = new FormInbox();
                frm.MdiParent = this;
                listForm.Add(frm);
                frm.Show();
            }
            else
            {   //jika form yang dituju sdh ada, panggil yg lama
                f.BringToFront();
                f.Show();
            }
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["FormDaftarEmployee"];
            if (f == null)
            {   //jika form yg dituju belum ada, ciptakan yg baru
                FormDaftarEmployee frm = new FormDaftarEmployee();
                frm.MdiParent = this;
                listForm.Add(frm);
                frm.Show();
            }
            else
            {   //jika form yang dituju sdh ada, panggil yg lama
                f.BringToFront();
                f.Show();
            }
        }

        private void verifikasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["FormVerifikasiTabungan"];
            if (f == null)
            {   //jika form yg dituju belum ada, ciptakan yg baru
                FormVerifikasiTabungan frm = new FormVerifikasiTabungan();
                frm.MdiParent = this;
                listForm.Add(frm);
                frm.Show();
            }
            else
            {   //jika form yang dituju sdh ada, panggil yg lama
                f.BringToFront();
                f.Show();
            }
        }

        

        private void daftarDepositoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabunganLogin.Status != "unverified")
            {
                Form f = Application.OpenForms["FormDaftarDeposito"];
                if (f == null)
                {   //jika form yg dituju belum ada, ciptakan yg baru
                    FormDaftarDeposito frm = new FormDaftarDeposito();
                    frm.MdiParent = this;
                    listForm.Add(frm);
                    frm.Show();
                }
                else
                {   //jika form yang dituju sdh ada, panggil yg lama
                    f.BringToFront();
                    f.Show();
                }
            }
        }

        private void tambahToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabunganLogin.Status != "unverified")
            {
                Form f = Application.OpenForms["FormTambahDeposito"];
                if (f == null)
                {   //jika form yg dituju belum ada, ciptakan yg baru
                    FormTambahDeposito frm = new FormTambahDeposito();
                    frm.MdiParent = this;
                    listForm.Add(frm);
                    frm.Show();
                }
                else
                {   //jika form yang dituju sdh ada, panggil yg lama
                    f.BringToFront();
                    f.Show();
                }
            }
        }

        private void transferInternalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabunganLogin.Status != "unverified")
            {
                Form f = Application.OpenForms["FormTransaksiInternal"];
                if (f == null)
                {   //jika form yg dituju belum ada, ciptakan yg baru
                    FormTransaksiInternal frm = new FormTransaksiInternal();
                    frm.MdiParent = this;
                    listForm.Add(frm);
                    frm.Show();
                }
                else
                {   //jika form yang dituju sdh ada, panggil yg lama
                    f.BringToFront();
                    f.Show();
                }
            }
        }

        private void transferEksternalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabunganLogin.Status != "unverified")
            {
                Form f = Application.OpenForms["FormTransaksiEksternal"];
                if (f == null)
                {   //jika form yg dituju belum ada, ciptakan yg baru
                    FormTransaksiEksternal frm = new FormTransaksiEksternal();
                    frm.MdiParent = this;
                    listForm.Add(frm);
                    frm.Show();
                }
                else
                {   //jika form yang dituju sdh ada, panggil yg lama
                    f.BringToFront();
                    f.Show();
                }
            }
        }

        private void verifikasiDepositoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["FormVerifikasiDeposito"];
            if (f == null)
            {   //jika form yg dituju belum ada, ciptakan yg baru
                FormVerifikasiDeposito frm = new FormVerifikasiDeposito();
                frm.MdiParent = this;
                listForm.Add(frm);
                frm.Show();
            }
            else
            {   //jika form yang dituju sdh ada, panggil yg lama
                f.BringToFront();
                f.Show();
            }
        }

        private void topUpSaldoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabunganLogin.Status != "unverified")
            {
                Form f = Application.OpenForms["FormTopUp"];
                if (f == null)
                {   //jika form yg dituju belum ada, ciptakan yg baru
                    FormTopUp frm = new FormTopUp();
                    frm.MdiParent = this;
                    listForm.Add(frm);
                    frm.Show();
                }
                else
                {   //jika form yang dituju sdh ada, panggil yg lama
                    f.BringToFront();
                    f.Show();
                }
            }
        }

        private void pencairanDepositoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["FormCairDeposito"];
            if (f == null)
            {   //jika form yg dituju belum ada, ciptakan yg baru
                FormCairDeposito frm = new FormCairDeposito();
                frm.MdiParent = this;
                listForm.Add(frm);
                frm.Show();
            }
            else
            {   //jika form yang dituju sdh ada, panggil yg lama
                f.BringToFront();
                f.Show();
            }
        }

        private void internalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["FormTambahAddressBookInternal"];
            if (f == null)
            {   //jika form yg dituju belum ada, ciptakan yg baru
                FormTambahAddressBookInternal frm = new FormTambahAddressBookInternal();
                frm.MdiParent = this;
                listForm.Add(frm);
                frm.Show();
            }
            else
            {   //jika form yang dituju sdh ada, panggil yg lama
                f.BringToFront();
                f.Show();
            }
        }

        private void eksternalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["FormTambahAddressBookEksternal"];
            if (f == null)
            {   //jika form yg dituju belum ada, ciptakan yg baru
                FormTambahAddressBookEksternal frm = new FormTambahAddressBookEksternal();
                frm.MdiParent = this;
                listForm.Add(frm);
                frm.Show();
            }
            else
            {   //jika form yang dituju sdh ada, panggil yg lama
                f.BringToFront();
                f.Show();
            }
        }

        private void mutasiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabunganLogin.Status != "unverified")
            {
                Form f = Application.OpenForms["FormMutasi"];
                if (f == null)
                {   //jika form yg dituju belum ada, ciptakan yg baru
                    FormMutasi frm = new FormMutasi();
                    frm.MdiParent = this;
                    listForm.Add(frm);
                    frm.Show();
                }
                else
                {   //jika form yang dituju sdh ada, panggil yg lama
                    f.BringToFront();
                    f.Show();
                }
            }
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["FormInfo"];
            if (f == null)
            {   //jika form yg dituju belum ada, ciptakan yg baru
                FormInfo frm = new FormInfo();
                frm.MdiParent = this;
                listForm.Add(frm);
                frm.Show();
            }
            else
            {   //jika form yang dituju sdh ada, panggil yg lama
                f.BringToFront();
                f.Show();
            }
        }

        private void daftarTabunganToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = Application.OpenForms["FormDaftarTabungan"];
            if (f == null)
            {   //jika form yg dituju belum ada, ciptakan yg baru
                FormDaftarTabungan frm = new FormDaftarTabungan();
                frm.MdiParent = this;
                listForm.Add(frm);
                frm.Show();
            }
            else
            {   //jika form yang dituju sdh ada, panggil yg lama
                f.BringToFront();
                f.Show();
            }
        }

        private void closeAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("Rekening anda akan dinonaktifkan.\nYakin ingin menutup akun?", "Komfirmasi", MessageBoxButtons.YesNo);
            if (msg == DialogResult.Yes)
            {
                FormInputPin input = new FormInputPin();
                input.Owner = this;
                input.ShowDialog();
                if (input.konfirmasi == true)
                {
                    Tabungan.StatusSuspend("nonaktif", tabunganLogin.NoRekening);
                    logoutToolStripMenuItem_Click(this, e);
                }
            }
        }
    }
}
