using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diploma_2022.Medio
{
    public partial class ModificarMedio : Form
    {

        BLL.Medio.MedioBLL medioBLL = new BLL.Medio.MedioBLL();
        BE.Medio.Medio medio = new BE.Medio.Medio();
        private int MedioID;

        public ModificarMedio(int medioid)
        {
            InitializeComponent();
            MedioID = medioid;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ModificarMedio_Load(object sender, EventArgs e)
        {
            medio.Medioid = MedioID;
            medio = medioBLL.seleccionarMedio(medio);

            txtdesc.Text = medio.Descripcion;
            txtMedio.Text = medio.MedioNombre;
            cmbIva.Text = medio.Iva.ToString();

            this.Show();
        }

        private void BtnAltaMedio_Click(object sender, EventArgs e)
        {
            try
            {
                medio.Descripcion = txtdesc.Text;
                medio.Result = txtMedio.Text;
                medio.Iva = Convert.ToDecimal(cmbIva.Text);
                medio.Medioid = medio.Medioid;

                medioBLL.modificarmedio(medio);

                MessageBox.Show("Se modificó con exito", "Modificación OK", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ocurrió un problema", MessageBoxButtons.OK,
                  MessageBoxIcon.Error);


            }
        }
    }
}
