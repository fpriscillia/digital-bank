
namespace DiBa_Project_UAS
{
    partial class FormMutasi
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
            this.comboBoxJenis = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerMulai = new System.Windows.Forms.DateTimePicker();
            this.buttonCetak = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePickerAkhir = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // comboBoxJenis
            // 
            this.comboBoxJenis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxJenis.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxJenis.FormattingEnabled = true;
            this.comboBoxJenis.Items.AddRange(new object[] {
            "Semua",
            "Debit",
            "Credit"});
            this.comboBoxJenis.Location = new System.Drawing.Point(254, 239);
            this.comboBoxJenis.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxJenis.Name = "comboBoxJenis";
            this.comboBoxJenis.Size = new System.Drawing.Size(268, 35);
            this.comboBoxJenis.TabIndex = 55;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(149, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(322, 43);
            this.label1.TabIndex = 54;
            this.label1.Text = "Mutasi Rekening";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(28, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 29);
            this.label3.TabIndex = 52;
            this.label3.Text = "Jenis ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(28, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 29);
            this.label2.TabIndex = 53;
            this.label2.Text = "Tanggal mulai";
            // 
            // dateTimePickerMulai
            // 
            this.dateTimePickerMulai.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerMulai.CalendarForeColor = System.Drawing.SystemColors.Control;
            this.dateTimePickerMulai.CalendarMonthBackground = System.Drawing.SystemColors.WindowFrame;
            this.dateTimePickerMulai.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerMulai.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerMulai.Location = new System.Drawing.Point(254, 114);
            this.dateTimePickerMulai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePickerMulai.Name = "dateTimePickerMulai";
            this.dateTimePickerMulai.Size = new System.Drawing.Size(268, 34);
            this.dateTimePickerMulai.TabIndex = 51;
            // 
            // buttonCetak
            // 
            this.buttonCetak.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonCetak.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCetak.ForeColor = System.Drawing.Color.White;
            this.buttonCetak.Location = new System.Drawing.Point(33, 321);
            this.buttonCetak.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCetak.Name = "buttonCetak";
            this.buttonCetak.Size = new System.Drawing.Size(164, 52);
            this.buttonCetak.TabIndex = 50;
            this.buttonCetak.Text = "Cetak";
            this.buttonCetak.UseVisualStyleBackColor = false;
            this.buttonCetak.Click += new System.EventHandler(this.buttonCetak_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonExit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.ForeColor = System.Drawing.Color.White;
            this.buttonExit.Location = new System.Drawing.Point(439, 321);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(164, 52);
            this.buttonExit.TabIndex = 49;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(28, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(175, 29);
            this.label4.TabIndex = 57;
            this.label4.Text = "Tanggal akhir";
            // 
            // dateTimePickerAkhir
            // 
            this.dateTimePickerAkhir.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerAkhir.CalendarForeColor = System.Drawing.SystemColors.Control;
            this.dateTimePickerAkhir.CalendarMonthBackground = System.Drawing.SystemColors.WindowFrame;
            this.dateTimePickerAkhir.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerAkhir.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerAkhir.Location = new System.Drawing.Point(254, 176);
            this.dateTimePickerAkhir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePickerAkhir.Name = "dateTimePickerAkhir";
            this.dateTimePickerAkhir.Size = new System.Drawing.Size(268, 34);
            this.dateTimePickerAkhir.TabIndex = 56;
            // 
            // FormMutasi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(632, 412);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePickerAkhir);
            this.Controls.Add(this.comboBoxJenis);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePickerMulai);
            this.Controls.Add(this.buttonCetak);
            this.Controls.Add(this.buttonExit);
            this.Name = "FormMutasi";
            this.Text = "FormMutasi";
            this.Load += new System.EventHandler(this.FormMutasi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxJenis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerMulai;
        private System.Windows.Forms.Button buttonCetak;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePickerAkhir;
    }
}