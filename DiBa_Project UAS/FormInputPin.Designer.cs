
namespace DiBa_Project_UAS
{
    partial class FormInputPin
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
            this.buttonOke = new System.Windows.Forms.Button();
            this.textBoxPin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOke
            // 
            this.buttonOke.BackColor = System.Drawing.Color.MidnightBlue;
            this.buttonOke.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOke.ForeColor = System.Drawing.Color.White;
            this.buttonOke.Location = new System.Drawing.Point(78, 150);
            this.buttonOke.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonOke.Name = "buttonOke";
            this.buttonOke.Size = new System.Drawing.Size(213, 52);
            this.buttonOke.TabIndex = 50;
            this.buttonOke.Text = "OKE";
            this.buttonOke.UseVisualStyleBackColor = false;
            this.buttonOke.Click += new System.EventHandler(this.buttonOke_Click);
            // 
            // textBoxPin
            // 
            this.textBoxPin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPin.Location = new System.Drawing.Point(48, 88);
            this.textBoxPin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPin.Name = "textBoxPin";
            this.textBoxPin.PasswordChar = '*';
            this.textBoxPin.Size = new System.Drawing.Size(276, 30);
            this.textBoxPin.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(90, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 24);
            this.label1.TabIndex = 47;
            this.label1.Text = "INPUT YOUR PIN!!";
            // 
            // FormInputPin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 239);
            this.ControlBox = false;
            this.Controls.Add(this.buttonOke);
            this.Controls.Add(this.textBoxPin);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormInputPin";
            this.Text = "FormInputPin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOke;
        private System.Windows.Forms.TextBox textBoxPin;
        private System.Windows.Forms.Label label1;
    }
}