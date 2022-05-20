namespace Diploma_2022
{
    partial class Login
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
            this.btn_ingresar = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtclave = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CheckCambiarClave = new System.Windows.Forms.CheckBox();
            this.LblClaveNueva = new System.Windows.Forms.Label();
            this.LblClaveAnterior = new System.Windows.Forms.Label();
            this.txtClaveNew = new System.Windows.Forms.TextBox();
            this.txtClaveAtn = new System.Windows.Forms.TextBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_ingresar
            // 
            this.btn_ingresar.Location = new System.Drawing.Point(115, 169);
            this.btn_ingresar.Name = "btn_ingresar";
            this.btn_ingresar.Size = new System.Drawing.Size(98, 36);
            this.btn_ingresar.TabIndex = 0;
            this.btn_ingresar.Text = "Ingresar";
            this.btn_ingresar.UseVisualStyleBackColor = true;
            this.btn_ingresar.Click += new System.EventHandler(this.btn_ingresar_Click);
            // 
            // btn_salir
            // 
            this.btn_salir.Location = new System.Drawing.Point(277, 169);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(98, 36);
            this.btn_salir.TabIndex = 1;
            this.btn_salir.Text = "Salir";
            this.btn_salir.UseVisualStyleBackColor = true;
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(115, 51);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(271, 20);
            this.txtUsuario.TabIndex = 2;
            // 
            // txtclave
            // 
            this.txtclave.Location = new System.Drawing.Point(115, 105);
            this.txtclave.Name = "txtclave";
            this.txtclave.Size = new System.Drawing.Size(271, 20);
            this.txtclave.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Usuario :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Clave :";
            // 
            // CheckCambiarClave
            // 
            this.CheckCambiarClave.AutoSize = true;
            this.CheckCambiarClave.Location = new System.Drawing.Point(115, 230);
            this.CheckCambiarClave.Name = "CheckCambiarClave";
            this.CheckCambiarClave.Size = new System.Drawing.Size(94, 17);
            this.CheckCambiarClave.TabIndex = 6;
            this.CheckCambiarClave.Text = "Cambiar Clave";
            this.CheckCambiarClave.UseVisualStyleBackColor = true;
            this.CheckCambiarClave.CheckedChanged += new System.EventHandler(this.CheckCambiarClave_CheckedChanged);
            // 
            // LblClaveNueva
            // 
            this.LblClaveNueva.AutoSize = true;
            this.LblClaveNueva.Location = new System.Drawing.Point(55, 323);
            this.LblClaveNueva.Name = "LblClaveNueva";
            this.LblClaveNueva.Size = new System.Drawing.Size(72, 13);
            this.LblClaveNueva.TabIndex = 14;
            this.LblClaveNueva.Text = "Clave Nueva:";
            // 
            // LblClaveAnterior
            // 
            this.LblClaveAnterior.AutoSize = true;
            this.LblClaveAnterior.Location = new System.Drawing.Point(55, 284);
            this.LblClaveAnterior.Name = "LblClaveAnterior";
            this.LblClaveAnterior.Size = new System.Drawing.Size(76, 13);
            this.LblClaveAnterior.TabIndex = 13;
            this.LblClaveAnterior.Text = "Clave Anterior:";
            // 
            // txtClaveNew
            // 
            this.txtClaveNew.Location = new System.Drawing.Point(137, 320);
            this.txtClaveNew.Name = "txtClaveNew";
            this.txtClaveNew.PasswordChar = '*';
            this.txtClaveNew.Size = new System.Drawing.Size(198, 20);
            this.txtClaveNew.TabIndex = 12;
            this.txtClaveNew.UseSystemPasswordChar = true;
            // 
            // txtClaveAtn
            // 
            this.txtClaveAtn.Location = new System.Drawing.Point(137, 281);
            this.txtClaveAtn.Name = "txtClaveAtn";
            this.txtClaveAtn.PasswordChar = '*';
            this.txtClaveAtn.Size = new System.Drawing.Size(198, 20);
            this.txtClaveAtn.TabIndex = 11;
            this.txtClaveAtn.UseSystemPasswordChar = true;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(197, 357);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(86, 31);
            this.btnConfirmar.TabIndex = 15;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 257);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.LblClaveNueva);
            this.Controls.Add(this.LblClaveAnterior);
            this.Controls.Add(this.txtClaveNew);
            this.Controls.Add(this.txtClaveAtn);
            this.Controls.Add(this.CheckCambiarClave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtclave);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.btn_ingresar);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ingresar;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtclave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox CheckCambiarClave;
        private System.Windows.Forms.Label LblClaveNueva;
        private System.Windows.Forms.Label LblClaveAnterior;
        private System.Windows.Forms.TextBox txtClaveNew;
        private System.Windows.Forms.TextBox txtClaveAtn;
        private System.Windows.Forms.Button btnConfirmar;
    }
}