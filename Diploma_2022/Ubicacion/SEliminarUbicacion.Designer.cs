namespace Diploma_2022.Ubicacion
{
    partial class SEliminarUbicacion
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
            this.button1 = new System.Windows.Forms.Button();
            this.dgvubicaciones = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvubicaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(427, 233);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 42);
            this.button1.TabIndex = 9;
            this.button1.Text = "Salir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvubicaciones
            // 
            this.dgvubicaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvubicaciones.Location = new System.Drawing.Point(12, 36);
            this.dgvubicaciones.Name = "dgvubicaciones";
            this.dgvubicaciones.Size = new System.Drawing.Size(544, 181);
            this.dgvubicaciones.TabIndex = 8;
            this.dgvubicaciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvubicaciones_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ubicaciones";
            // 
            // SEliminarUbicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 283);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvubicaciones);
            this.Controls.Add(this.label1);
            this.Name = "SEliminarUbicacion";
            this.Text = "Eliminar Ubicacion";
            this.Load += new System.EventHandler(this.SEliminarUbicacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvubicaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvubicaciones;
        private System.Windows.Forms.Label label1;
    }
}