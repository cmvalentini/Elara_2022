namespace Diploma_2022.Permisos
{
    partial class AsignarFamilia
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
            this.dgvPerfiles = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_salir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerfiles)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPerfiles
            // 
            this.dgvPerfiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPerfiles.Location = new System.Drawing.Point(22, 41);
            this.dgvPerfiles.Name = "dgvPerfiles";
            this.dgvPerfiles.Size = new System.Drawing.Size(450, 181);
            this.dgvPerfiles.TabIndex = 13;
            this.dgvPerfiles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPerfiles_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 24);
            this.label1.TabIndex = 12;
            this.label1.Text = "Familias";
            // 
            // btn_salir
            // 
            this.btn_salir.Location = new System.Drawing.Point(379, 240);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(93, 36);
            this.btn_salir.TabIndex = 11;
            this.btn_salir.Text = "Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // AsignarFamilia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 288);
            this.Controls.Add(this.dgvPerfiles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_salir);
            this.Name = "AsignarFamilia";
            this.Text = "AsignarFamilia";
            this.Load += new System.EventHandler(this.AsignarFamilia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerfiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPerfiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_salir;
    }
}