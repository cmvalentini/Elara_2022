namespace Diploma_2022.Permisos
{
    partial class AUsuarioFamilia
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
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNombrePerfil = new System.Windows.Forms.Label();
            this.BtnAsignarPerfil = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbPerfiles = new System.Windows.Forms.ComboBox();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.brn_cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 18);
            this.label6.TabIndex = 61;
            this.label6.Text = "Perfil :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 18);
            this.label5.TabIndex = 60;
            this.label5.Text = "Usuario:";
            // 
            // lblNombrePerfil
            // 
            this.lblNombrePerfil.AutoSize = true;
            this.lblNombrePerfil.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombrePerfil.Location = new System.Drawing.Point(90, 53);
            this.lblNombrePerfil.Name = "lblNombrePerfil";
            this.lblNombrePerfil.Size = new System.Drawing.Size(47, 18);
            this.lblNombrePerfil.TabIndex = 59;
            this.lblNombrePerfil.Text = "Perfil";
            // 
            // BtnAsignarPerfil
            // 
            this.BtnAsignarPerfil.Location = new System.Drawing.Point(15, 165);
            this.BtnAsignarPerfil.Name = "BtnAsignarPerfil";
            this.BtnAsignarPerfil.Size = new System.Drawing.Size(79, 41);
            this.BtnAsignarPerfil.TabIndex = 58;
            this.BtnAsignarPerfil.Text = "Asignar Perfil";
            this.BtnAsignarPerfil.UseVisualStyleBackColor = true;
            this.BtnAsignarPerfil.Click += new System.EventHandler(this.BtnAsignarPerfil_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 18);
            this.label3.TabIndex = 57;
            this.label3.Text = "Perfiles de Usuario : ";
            // 
            // cmbPerfiles
            // 
            this.cmbPerfiles.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPerfiles.FormattingEnabled = true;
            this.cmbPerfiles.Location = new System.Drawing.Point(12, 121);
            this.cmbPerfiles.Name = "cmbPerfiles";
            this.cmbPerfiles.Size = new System.Drawing.Size(237, 23);
            this.cmbPerfiles.TabIndex = 56;
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreUsuario.Location = new System.Drawing.Point(90, 20);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(67, 18);
            this.lblNombreUsuario.TabIndex = 55;
            this.lblNombreUsuario.Text = "Usuario";
            // 
            // brn_cancelar
            // 
            this.brn_cancelar.Location = new System.Drawing.Point(170, 165);
            this.brn_cancelar.Name = "brn_cancelar";
            this.brn_cancelar.Size = new System.Drawing.Size(79, 41);
            this.brn_cancelar.TabIndex = 62;
            this.brn_cancelar.Text = "Cancelar";
            this.brn_cancelar.UseVisualStyleBackColor = true;
            this.brn_cancelar.Click += new System.EventHandler(this.brn_cancelar_Click);
            // 
            // AUsuarioFamilia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 239);
            this.Controls.Add(this.brn_cancelar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblNombrePerfil);
            this.Controls.Add(this.BtnAsignarPerfil);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbPerfiles);
            this.Controls.Add(this.lblNombreUsuario);
            this.Name = "AUsuarioFamilia";
            this.Text = "AUsuarioFamilia";
            this.Load += new System.EventHandler(this.AUsuarioFamilia_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblNombrePerfil;
        private System.Windows.Forms.Button BtnAsignarPerfil;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbPerfiles;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.Button brn_cancelar;
    }
}