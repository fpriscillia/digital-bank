
namespace DiBa_Project_UAS
{
    partial class FormTambahAddressBookEksternal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxKet = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonSimpan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPemilik = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxRekTujuan = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxBank = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxKet
            // 
            this.textBoxKet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxKet.Location = new System.Drawing.Point(310, 282);
            this.textBoxKet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxKet.Name = "textBoxKet";
            this.textBoxKet.Size = new System.Drawing.Size(314, 30);
            this.textBoxKet.TabIndex = 124;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(40, 282);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 27);
            this.label3.TabIndex = 123;
            this.label3.Text = "Keterangan";
            // 
            // buttonSimpan
            // 
            this.buttonSimpan.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonSimpan.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSimpan.ForeColor = System.Drawing.Color.White;
            this.buttonSimpan.Location = new System.Drawing.Point(508, 341);
            this.buttonSimpan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSimpan.Name = "buttonSimpan";
            this.buttonSimpan.Size = new System.Drawing.Size(164, 52);
            this.buttonSimpan.TabIndex = 122;
            this.buttonSimpan.Text = "Simpan";
            this.buttonSimpan.UseVisualStyleBackColor = false;
            this.buttonSimpan.Click += new System.EventHandler(this.buttonSimpan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(21, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(669, 48);
            this.label1.TabIndex = 121;
            this.label1.Text = "Tambah Address Book Eksternal";
            // 
            // textBoxPemilik
            // 
            this.textBoxPemilik.Enabled = false;
            this.textBoxPemilik.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPemilik.Location = new System.Drawing.Point(310, 163);
            this.textBoxPemilik.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPemilik.Name = "textBoxPemilik";
            this.textBoxPemilik.Size = new System.Drawing.Size(314, 30);
            this.textBoxPemilik.TabIndex = 120;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(40, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 27);
            this.label2.TabIndex = 119;
            this.label2.Text = "Nama Pemilik";
            // 
            // textBoxRekTujuan
            // 
            this.textBoxRekTujuan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxRekTujuan.Location = new System.Drawing.Point(310, 106);
            this.textBoxRekTujuan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxRekTujuan.Name = "textBoxRekTujuan";
            this.textBoxRekTujuan.Size = new System.Drawing.Size(314, 30);
            this.textBoxRekTujuan.TabIndex = 118;
            this.textBoxRekTujuan.TextChanged += new System.EventHandler(this.textBoxRekTujuan_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Navy;
            this.label10.Location = new System.Drawing.Point(40, 106);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(198, 27);
            this.label10.TabIndex = 117;
            this.label10.Text = "Nomor Rekening";
            // 
            // textBoxBank
            // 
            this.textBoxBank.Enabled = false;
            this.textBoxBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBank.Location = new System.Drawing.Point(310, 221);
            this.textBoxBank.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxBank.Name = "textBoxBank";
            this.textBoxBank.Size = new System.Drawing.Size(314, 30);
            this.textBoxBank.TabIndex = 126;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(40, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 27);
            this.label4.TabIndex = 125;
            this.label4.Text = "Bank";
            // 
            // FormTambahAddressBookEksternal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(713, 430);
            this.Controls.Add(this.textBoxBank);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxKet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonSimpan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPemilik);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxRekTujuan);
            this.Controls.Add(this.label10);
            this.Name = "FormTambahAddressBookEksternal";
            this.Text = "FormTambahAddressBookEksternal";
            this.Load += new System.EventHandler(this.FormTambahAddressBookEksternal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxKet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonSimpan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPemilik;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxRekTujuan;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxBank;
        private System.Windows.Forms.Label label4;
    }
}