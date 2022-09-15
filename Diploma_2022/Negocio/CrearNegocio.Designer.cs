namespace Diploma_2022.Negocio
{
    partial class CrearNegocio
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
            this.mcpublicacion = new System.Windows.Forms.MonthCalendar();
            this.tabnegocio = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmbagencia = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbmedio = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbubicacion = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtprecio = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btncalcularprecio = new System.Windows.Forms.Button();
            this.txtprints = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.btn_grabar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNumeropedido = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtdescripcion = new System.Windows.Forms.TextBox();
            this.tabnegocio.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mcpublicacion
            // 
            this.mcpublicacion.Location = new System.Drawing.Point(397, 129);
            this.mcpublicacion.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.mcpublicacion.Name = "mcpublicacion";
            this.mcpublicacion.TabIndex = 29;
            // 
            // tabnegocio
            // 
            this.tabnegocio.Controls.Add(this.tabPage1);
            this.tabnegocio.Controls.Add(this.tabPage2);
            this.tabnegocio.Location = new System.Drawing.Point(9, 107);
            this.tabnegocio.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabnegocio.Name = "tabnegocio";
            this.tabnegocio.SelectedIndex = 0;
            this.tabnegocio.Size = new System.Drawing.Size(383, 188);
            this.tabnegocio.TabIndex = 30;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cmbagencia);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.cmbmedio);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.cmbubicacion);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage1.Size = new System.Drawing.Size(375, 162);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Página1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmbagencia
            // 
            this.cmbagencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbagencia.FormattingEnabled = true;
            this.cmbagencia.Location = new System.Drawing.Point(8, 94);
            this.cmbagencia.Name = "cmbagencia";
            this.cmbagencia.Size = new System.Drawing.Size(342, 21);
            this.cmbagencia.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Agencia: ";
            // 
            // cmbmedio
            // 
            this.cmbmedio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbmedio.FormattingEnabled = true;
            this.cmbmedio.Items.AddRange(new object[] {
            "--Sin Asignar--"});
            this.cmbmedio.Location = new System.Drawing.Point(8, 26);
            this.cmbmedio.Name = "cmbmedio";
            this.cmbmedio.Size = new System.Drawing.Size(159, 21);
            this.cmbmedio.TabIndex = 8;
            this.cmbmedio.TextChanged += new System.EventHandler(this.cmbmedio_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Medio:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(173, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ubicación:";
            // 
            // cmbubicacion
            // 
            this.cmbubicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbubicacion.FormattingEnabled = true;
            this.cmbubicacion.Location = new System.Drawing.Point(176, 26);
            this.cmbubicacion.Name = "cmbubicacion";
            this.cmbubicacion.Size = new System.Drawing.Size(174, 21);
            this.cmbubicacion.TabIndex = 9;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtprecio);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.btncalcularprecio);
            this.tabPage2.Controls.Add(this.txtprints);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage2.Size = new System.Drawing.Size(375, 162);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Página 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtprecio
            // 
            this.txtprecio.Location = new System.Drawing.Point(226, 70);
            this.txtprecio.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtprecio.Name = "txtprecio";
            this.txtprecio.Size = new System.Drawing.Size(108, 20);
            this.txtprecio.TabIndex = 13;
            this.txtprecio.Text = "0.00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Pericles", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(210, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(190, 21);
            this.label7.TabIndex = 14;
            this.label7.Text = "Precio Publicación ";
            // 
            // btncalcularprecio
            // 
            this.btncalcularprecio.Location = new System.Drawing.Point(29, 81);
            this.btncalcularprecio.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btncalcularprecio.Name = "btncalcularprecio";
            this.btncalcularprecio.Size = new System.Drawing.Size(103, 41);
            this.btncalcularprecio.TabIndex = 15;
            this.btncalcularprecio.Text = "Calcular Precio";
            this.btncalcularprecio.UseVisualStyleBackColor = true;
            this.btncalcularprecio.Click += new System.EventHandler(this.btncalcularprecio_Click);
            // 
            // txtprints
            // 
            this.txtprints.Location = new System.Drawing.Point(15, 39);
            this.txtprints.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtprints.Name = "txtprints";
            this.txtprints.Size = new System.Drawing.Size(129, 20);
            this.txtprints.TabIndex = 16;
            this.txtprints.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtprints_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Impresiones: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(397, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Fecha Publicación : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Alta de Negocio";
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Location = new System.Drawing.Point(488, 417);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(105, 35);
            this.btn_Cancelar.TabIndex = 27;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // btn_grabar
            // 
            this.btn_grabar.Location = new System.Drawing.Point(301, 417);
            this.btn_grabar.Name = "btn_grabar";
            this.btn_grabar.Size = new System.Drawing.Size(105, 35);
            this.btn_grabar.TabIndex = 26;
            this.btn_grabar.Text = "Grabar Negocio";
            this.btn_grabar.UseVisualStyleBackColor = true;
            this.btn_grabar.Click += new System.EventHandler(this.btn_grabar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Pericles", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 21);
            this.label3.TabIndex = 25;
            this.label3.Text = "Orden de Pedido:";
            // 
            // lblNumeropedido
            // 
            this.lblNumeropedido.AutoSize = true;
            this.lblNumeropedido.Font = new System.Drawing.Font("Pericles", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeropedido.Location = new System.Drawing.Point(201, 38);
            this.lblNumeropedido.Name = "lblNumeropedido";
            this.lblNumeropedido.Size = new System.Drawing.Size(100, 23);
            this.lblNumeropedido.TabIndex = 24;
            this.lblNumeropedido.Text = "numero";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Descripción del anuncio:";
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.Location = new System.Drawing.Point(12, 314);
            this.txtdescripcion.Multiline = true;
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(532, 77);
            this.txtdescripcion.TabIndex = 22;
            // 
            // CrearNegocio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 476);
            this.Controls.Add(this.mcpublicacion);
            this.Controls.Add(this.tabnegocio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_grabar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblNumeropedido);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtdescripcion);
            this.Name = "CrearNegocio";
            this.Text = "CrearNegocio";
            this.Load += new System.EventHandler(this.CrearNegocio_Load);
            this.tabnegocio.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar mcpublicacion;
        private System.Windows.Forms.TabControl tabnegocio;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cmbagencia;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbmedio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbubicacion;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtprecio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btncalcularprecio;
        private System.Windows.Forms.TextBox txtprints;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Button btn_grabar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNumeropedido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtdescripcion;
    }
}