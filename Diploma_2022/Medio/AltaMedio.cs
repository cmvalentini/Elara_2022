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
    public partial class AltaMedio : Form
    {
        public AltaMedio()
        {
            InitializeComponent();
        }

        BE.Medio.Medio Medio = new BE.Medio.Medio();

        private void AltaMedio_Load(object sender, EventArgs e)
        {

        }

        private void BtnAltaMedio_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMedio.Text == "" || txtMedio.Text == " ")
                {
                    MessageBox.Show("Por favor asigne un nombre al medio", "Nombre de Medio sin Asignar", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
                else if (cmbIva.Text == "" || cmbIva.Text == " ")
                {
                    MessageBox.Show("Por favor asigne un valor al Iva", "Iva sin Asignar", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                else
                {
                  
                             
                    Medio.MedioNombre = txtMedio.Text;
                    Medio.Descripcion = txtdesc.Text;
                    MessageBox.Show(cmbIva.Text +"   "+ Convert.ToDecimal(cmbIva.Text)+"   "+ Math.Round(Convert.ToDecimal(cmbIva.Text), 2));
                    Medio.Iva = Math.Round(Convert.ToDecimal(cmbIva.Text),2);
                    

                    BLL.Medio.MedioBLL MedioBLL = new BLL.Medio.MedioBLL();
                    MedioBLL.DarAlta(Medio);

                    MessageBox.Show("Se dió de alta el medio satisfactoriamente", "Alta de Medio", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtdesc.Text = "";
                    txtMedio.Text = "";


                }


            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Hubo un error", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
