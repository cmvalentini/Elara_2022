namespace Diploma_2022.Digitos_Verificadores
{
    partial class DigitosVerificadores
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
            this.btnverificar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnverificar
            // 
            this.btnverificar.Location = new System.Drawing.Point(11, 103);
            this.btnverificar.Name = "btnverificar";
            this.btnverificar.Size = new System.Drawing.Size(168, 53);
            this.btnverificar.TabIndex = 7;
            this.btnverificar.Text = "Consultar Digitos Verificadores";
            this.btnverificar.UseVisualStyleBackColor = true;
            this.btnverificar.Click += new System.EventHandler(this.btnverificar_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 181);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(167, 54);
            this.button2.TabIndex = 6;
            this.button2.Text = "Volver";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 53);
            this.button1.TabIndex = 5;
            this.button1.Text = "ReCalcular Digitos Verificadores";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DigitosVerificadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(198, 257);
            this.Controls.Add(this.btnverificar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "DigitosVerificadores";
            this.Text = "DigitosVerificadores";
            this.Load += new System.EventHandler(this.DigitosVerificadores_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnverificar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}