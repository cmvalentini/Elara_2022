using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diploma_2022.Digitos_Verificadores
{
    public partial class DigitosVerificadores : Form
    {
        ServiceLayer.Sesion s = ServiceLayer.Sesion.GetInstance();
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        BLL.Seguridad.DigitosVerificadores digitos = new BLL.Seguridad.DigitosVerificadores();
        BE.Seguridad.DigitosVerificadores DV = new BE.Seguridad.DigitosVerificadores();
        BE.Seguridad.BitacoraBE log = new BE.Seguridad.BitacoraBE();
        BLL.Seguridad.BitacoraBLL LogBLL = new BLL.Seguridad.BitacoraBLL();

        public DigitosVerificadores()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnverificar_Click(object sender, EventArgs e)
        {
            try
            {
                DV = digitos.CalcularDigitosVerificadores();


                if (DV.result.Substring(0, 1) == "La")
                {
                    MessageBox.Show("Digitos verificadores: " + DV.result.ToString(), "Digitos Verificadores", MessageBoxButtons.OK,
                                      MessageBoxIcon.Warning);

                    log.Descripcion =  cryp.Encriptar("Error con Dígitos Verificadores : " + DV.result + "  ");
                    log.NombreOperacion = cryp.Encriptar("Digios verificadores");
                    log.Criticidad = 1;

                    LogBLL.IngresarDatoBitacora(log.NombreOperacion, log.Descripcion, 1, s.UsuarioID);
                     
                }
                else
                {
                    MessageBox.Show("Digitos verificadores: " + DV.result.ToString(), "Digitos Verificadores", MessageBoxButtons.OK,
                                       MessageBoxIcon.Information);

                    log.Descripcion = cryp.Encriptar("Dígitos Verificadores controlados y sin inconvenientes : " + DV.result + "  ");
                    log.NombreOperacion = cryp.Encriptar("Digios verificadores");
                    log.Criticidad = 1;

                    LogBLL.IngresarDatoBitacora(log.NombreOperacion, log.Descripcion, 1, s.UsuarioID);

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al calcular los DV" + ex.Message, "Digitos Verificadores", MessageBoxButtons.OK,
                                     MessageBoxIcon.Error);


            }
        }

        private void DigitosVerificadores_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DV = digitos.RecalcularDVH();
                MessageBox.Show("Digitos verificadores: " + DV.result.ToString(), "Digitos Verificadores", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           


        }
    }
}
