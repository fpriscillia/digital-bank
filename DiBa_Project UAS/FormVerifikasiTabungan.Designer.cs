namespace DiBa_Project_UAS
{
    partial class FormVerifikasiTabungan
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButtonSuspend = new System.Windows.Forms.RadioButton();
            this.radioButtonUnverified = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewHasil = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonExit = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHasil)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(294, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(475, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "DAFTAR STATUS TABUNGAN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightCyan;
            this.panel2.Controls.Add(this.radioButtonSuspend);
            this.panel2.Controls.Add(this.radioButtonUnverified);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(12, 90);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1053, 60);
            this.panel2.TabIndex = 5;
            // 
            // radioButtonSuspend
            // 
            this.radioButtonSuspend.AutoSize = true;
            this.radioButtonSuspend.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonSuspend.ForeColor = System.Drawing.Color.Navy;
            this.radioButtonSuspend.Location = new System.Drawing.Point(585, 15);
            this.radioButtonSuspend.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButtonSuspend.Name = "radioButtonSuspend";
            this.radioButtonSuspend.Size = new System.Drawing.Size(131, 31);
            this.radioButtonSuspend.TabIndex = 4;
            this.radioButtonSuspend.Text = "Suspend";
            this.radioButtonSuspend.UseVisualStyleBackColor = true;
            this.radioButtonSuspend.CheckedChanged += new System.EventHandler(this.radioButtonSuspend_CheckedChanged);
            // 
            // radioButtonUnverified
            // 
            this.radioButtonUnverified.AutoSize = true;
            this.radioButtonUnverified.Checked = true;
            this.radioButtonUnverified.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonUnverified.ForeColor = System.Drawing.Color.Navy;
            this.radioButtonUnverified.Location = new System.Drawing.Point(336, 15);
            this.radioButtonUnverified.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButtonUnverified.Name = "radioButtonUnverified";
            this.radioButtonUnverified.Size = new System.Drawing.Size(152, 31);
            this.radioButtonUnverified.TabIndex = 3;
            this.radioButtonUnverified.TabStop = true;
            this.radioButtonUnverified.Text = "Unverified";
            this.radioButtonUnverified.UseVisualStyleBackColor = true;
            this.radioButtonUnverified.CheckedChanged += new System.EventHandler(this.radioButtonUnverified_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(19, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "Cari Berdasarkan";
            // 
            // dataGridViewHasil
            // 
            this.dataGridViewHasil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHasil.Location = new System.Drawing.Point(12, 168);
            this.dataGridViewHasil.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewHasil.Name = "dataGridViewHasil";
            this.dataGridViewHasil.RowHeadersWidth = 62;
            this.dataGridViewHasil.RowTemplate.Height = 28;
            this.dataGridViewHasil.Size = new System.Drawing.Size(1053, 442);
            this.dataGridViewHasil.TabIndex = 4;
            this.dataGridViewHasil.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewHasil_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCyan;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1053, 60);
            this.panel1.TabIndex = 3;
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonExit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.ForeColor = System.Drawing.Color.White;
            this.buttonExit.Location = new System.Drawing.Point(857, 626);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(208, 52);
            this.buttonExit.TabIndex = 42;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // FormVerifikasiTabungan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 689);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridViewHasil);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormVerifikasiTabungan";
            this.Text = "Verifikasi Tabungan";
            this.Load += new System.EventHandler(this.FormVerifikasiTabungan_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHasil)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewHasil;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.RadioButton radioButtonSuspend;
        private System.Windows.Forms.RadioButton radioButtonUnverified;
    }
}