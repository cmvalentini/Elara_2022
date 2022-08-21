namespace Diploma_2022.Permisos
{
    partial class AsignarOperacionesAPerfil
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnDesagregar = new System.Windows.Forms.Button();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.LstPerfilOperaciones = new System.Windows.Forms.ListBox();
            this.LstOperaciones = new System.Windows.Forms.ListBox();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(311, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Operaciones Asignadas a Perfil";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Operaciones del Sistema";
            // 
            // BtnDesagregar
            // 
            this.BtnDesagregar.Font = new System.Drawing.Font("Pericles", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDesagregar.Location = new System.Drawing.Point(255, 207);
            this.BtnDesagregar.Name = "BtnDesagregar";
            this.BtnDesagregar.Size = new System.Drawing.Size(42, 32);
            this.BtnDesagregar.TabIndex = 16;
            this.BtnDesagregar.Text = "<-";
            this.BtnDesagregar.UseVisualStyleBackColor = true;
            this.BtnDesagregar.Click += new System.EventHandler(this.BtnDesagregar_Click);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Font = new System.Drawing.Font("Pericles", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregar.Location = new System.Drawing.Point(255, 134);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(42, 32);
            this.BtnAgregar.TabIndex = 15;
            this.BtnAgregar.Text = "->";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(419, 339);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(102, 37);
            this.BtnCancelar.TabIndex = 14;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(280, 339);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(102, 37);
            this.BtnGuardar.TabIndex = 13;
            this.BtnGuardar.Text = "Guardar Configuración";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // LstPerfilOperaciones
            // 
            this.LstPerfilOperaciones.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstPerfilOperaciones.FormattingEnabled = true;
            this.LstPerfilOperaciones.ItemHeight = 15;
            this.LstPerfilOperaciones.Location = new System.Drawing.Point(314, 72);
            this.LstPerfilOperaciones.Name = "LstPerfilOperaciones";
            this.LstPerfilOperaciones.Size = new System.Drawing.Size(217, 244);
            this.LstPerfilOperaciones.TabIndex = 12;
            // 
            // LstOperaciones
            // 
            this.LstOperaciones.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstOperaciones.FormattingEnabled = true;
            this.LstOperaciones.ItemHeight = 15;
            this.LstOperaciones.Location = new System.Drawing.Point(15, 72);
            this.LstOperaciones.Name = "LstOperaciones";
            this.LstOperaciones.Size = new System.Drawing.Size(222, 244);
            this.LstOperaciones.TabIndex = 11;
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreUsuario.Location = new System.Drawing.Point(10, 11);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(156, 25);
            this.lblNombreUsuario.TabIndex = 10;
            this.lblNombreUsuario.Text = "Nombre de Perfil";
            // 
            // AsignarOperacionesAPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 392);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnDesagregar);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.LstPerfilOperaciones);
            this.Controls.Add(this.LstOperaciones);
            this.Controls.Add(this.lblNombreUsuario);
            this.Name = "AsignarOperacionesAPerfil";
            this.Text = "AsignarOperacionesAPerfil";
            this.Load += new System.EventHandler(this.AsignarOperacionesAPerfil_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnDesagregar;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.ListBox LstPerfilOperaciones;
        private System.Windows.Forms.ListBox LstOperaciones;
        private System.Windows.Forms.Label lblNombreUsuario;
    }
}