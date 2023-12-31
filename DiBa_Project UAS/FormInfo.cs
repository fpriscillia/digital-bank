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
    public partial class FormInfo : Form
    {
        public FormInfo()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormInfo_Load(object sender, EventArgs e)
        {
            FormUtama frm = (FormUtama)this.MdiParent;

            textBoxNoRek.Text = frm.tabunganLogin.NoRekening;
            textBoxSaldo.Text = frm.tabunganLogin.Saldo.ToString();
            textBoxReward.Text = frm.userLogin.Reward.ToString();
            textBoxStatus.Text = frm.tabunganLogin.Status;
        }
    }
}
