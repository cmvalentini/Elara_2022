using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diploma_2022.Ubicacion
{
    public partial class Alta_Ubicacion : Form
    {

        BLL.Medio.UbicacionBLL ubiBLL = new BLL.Medio.UbicacionBLL();
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        BLL.Seguridad.BitacoraBLL log = new BLL.Seguridad.BitacoraBLL();
        ServiceLayer.Sesion s = ServiceLayer.Sesion.GetInstance();
        BE.Seguridad.BitacoraBE LogBE = new BE.Seguridad.BitacoraBE();
        

        public Alta_Ubicacion()
        {
            InitializeComponent();
        }

        private void Alta_Ubicacion_Load(object sender, EventArgs e)
        {
            List<BE.Medio.Medio> listamedios = new List<BE.Medio.Medio>();
            listamedios = ubiBLL.TraerMedios();

            foreach (BE.Medio.Medio row in listamedios)
            {
                cmbmedio.Items.Add(row.MedioNombre.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //no entra
                if ((txtnombreubicacion.Text == "") || (txtformato.Text == "") || (cmbmedio.Text == ""))//no entra

                {
                    MessageBox.Show("Verifique los datos", "Campos de Texto sin asignar", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else //entra
                {
                    BE.Medio.Ubicacion ubiBE = new BE.Medio.Ubicacion();
                    BE.Medio.Medio mediobe = new BE.Medio.Medio();
                    ubiBE.Formato = txtformato.Text;
                    ubiBE.Formula = txtformula.Text;
                    mediobe.MedioNombre = cmbmedio.Text;
                    ubiBE.medio = mediobe;
                     
                    ubiBE.Medida = txtmedida.Text;
                    ubiBE.NombreUbicacion = txtnombreubicacion.Text;
                    ubiBE.Precio = Convert.ToDecimal(txtprecio.Text);

                    if (chkhabilitado.Checked == true)
                    {
                        ubiBE.Habilitado = 1;
                    }
                    else
                    {
                        ubiBE.Habilitado = 0;
                    }


                    ubiBE = ubiBLL.daraltaubicacion(ubiBE);


                    MessageBox.Show("Se creo La ubicación exitosamente", "Creacion de Ubicación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LogBE.Criticidad = 3;
                    LogBE.Descripcion = txtnombreubicacion.Text + " " + txtformato.Text;
                    LogBE.FechayHora = DateTime.Now;
                    LogBE.NombreOperacion = "Alta Ubicación";
                    log.IngresarDatoBitacora(cryp.Encriptar(LogBE.NombreOperacion).ToString(), cryp.Encriptar(LogBE.Descripcion).ToString(), LogBE.Criticidad, s.UsuarioID);

                    txtformato.Text = "";
                    txtformula.Text = "";
                    txtmedida.Text = "";
                    txtnombreubicacion.Text = "";

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Hubo un inprevisto,contacte con el administrador del sistema. Error : \n" + ex.Message, "Error de Proceso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void txtprecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
