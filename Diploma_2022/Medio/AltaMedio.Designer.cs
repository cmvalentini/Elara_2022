﻿namespace Diploma_2022.Medio
{
    partial class AltaMedio
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtdesc = new System.Windows.Forms.TextBox();
            this.cmbIva = new System.Windows.Forms.ComboBox();
            this.txtMedio = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.BtnAltaMedio = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(93, 284);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 284);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "IVA:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Descripción";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Nombre del Medio:";
            // 
            // txtdesc
            // 
            this.txtdesc.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdesc.Location = new System.Drawing.Point(12, 88);
            this.txtdesc.Multiline = true;
            this.txtdesc.Name = "txtdesc";
            this.txtdesc.Size = new System.Drawing.Size(292, 164);
            this.txtdesc.TabIndex = 13;
            // 
            // cmbIva
            // 
            this.cmbIva.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIva.FormattingEnabled = true;
            this.cmbIva.Items.AddRange(new object[] {
            "21,00",
            "10,50",
            "2,70"});
            this.cmbIva.Location = new System.Drawing.Point(42, 281);
            this.cmbIva.Name = "cmbIva";
            this.cmbIva.Size = new System.Drawing.Size(45, 23);
            this.cmbIva.TabIndex = 12;
            // 
            // txtMedio
            // 
            this.txtMedio.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMedio.Location = new System.Drawing.Point(12, 34);
            this.txtMedio.Name = "txtMedio";
            this.txtMedio.Size = new System.Drawing.Size(292, 21);
            this.txtMedio.TabIndex = 11;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(177, 321);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(96, 40);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // BtnAltaMedio
            // 
            this.BtnAltaMedio.Location = new System.Drawing.Point(58, 321);
            this.BtnAltaMedio.Name = "BtnAltaMedio";
            this.BtnAltaMedio.Size = new System.Drawing.Size(91, 40);
            this.BtnAltaMedio.TabIndex = 9;
            this.BtnAltaMedio.Text = "Alta Medio";
            this.BtnAltaMedio.UseVisualStyleBackColor = true;
            this.BtnAltaMedio.Click += new System.EventHandler(this.BtnAltaMedio_Click);
            // 
            // AltaMedio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 379);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtdesc);
            this.Controls.Add(this.cmbIva);
            this.Controls.Add(this.txtMedio);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.BtnAltaMedio);
            this.Name = "AltaMedio";
            this.Text = "AltaMedio";
            this.Load += new System.EventHandler(this.AltaMedio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtdesc;
        private System.Windows.Forms.ComboBox cmbIva;
        private System.Windows.Forms.TextBox txtMedio;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button BtnAltaMedio;
    }
}