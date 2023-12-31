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
    public partial class FormTambahEmployee : Form
    {
        public FormTambahEmployee()
        {
            InitializeComponent();
        }

        private void buttonSignup_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.Text.Equals(textBoxKonfirmPassword.Text) && textBoxNIK.Text != "" && textBoxEmail.Text != "")
            {
                Employee user = new Employee();

                user.Nik = textBoxNIK.Text;
                user.NamaDepan = textBoxNamaDepan.Text;
                user.NamaKeluarga = textBoxNamaBelakang.Text;
                user.Posisi = (Position)comboBoxPosition.SelectedItem;
                user.Email = textBoxEmail.Text;
                user.Password = textBoxPassword.Text;
                user.TglBuat = DateTime.Now;
                user.TglPerubahan = DateTime.Now;

                try
                {
                    Employee.TambahData(user);
                    MessageBox.Show("Employee baru berhasil ditambahkan.", "Info");

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error.\nPesan Kesalahan: " + ex.Message);
                }
            }
            else if (textBoxNIK.Text == "")
            {
                MessageBox.Show("Harap isi NIK anda untuk membuat akun");
                textBoxNIK.Focus();
            }
            else if (textBoxEmail.Text == "")
            {
                MessageBox.Show("Harap isi email anda untuk membuat akun");
                textBoxEmail.Focus();
            }
            else
            {
                MessageBox.Show("Konfirmasi password tidak sama");
                textBoxKonfirmPassword.Text = "";
                textBoxPassword.Text = "";
                textBoxPassword.Focus();
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormSignUpEmployee_Load(object sender, EventArgs e)
        {
            List<Position> listData = Position.BacaData();
            comboBoxPosition.DataSource = listData;
            comboBoxPosition.DisplayMember = "Nama";
        }
    }
}
