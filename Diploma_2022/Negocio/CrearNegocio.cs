using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diploma_2022.Negocio
{
    public partial class CrearNegocio : Form
    {
        BLL.Seguridad.EncriptacionBLL crypBLL = new BLL.Seguridad.EncriptacionBLL();
        BLL.Seguridad.BitacoraBLL logBLL = new BLL.Seguridad.BitacoraBLL();
        BLL.Medio.UbicacionBLL ubiBLL = new BLL.Medio.UbicacionBLL();
        BLL.Cliente.ClienteBLL agenciasBLL = new BLL.Cliente.ClienteBLL();
        BLL.Medio.MedioBLL medioBLL = new BLL.Medio.MedioBLL();
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        ServiceLayer.Sesion s = ServiceLayer.Sesion.GetInstance();
        ServiceLayer.Sesion usulog = ServiceLayer.Sesion.GetInstance();
        BE.Pedido.Pedido Pedido = new BE.Pedido.Pedido();
        BE.Medio.Ubicacion UbiBE = new BE.Medio.Ubicacion();
        BE.Medio.Medio MedioBE = new BE.Medio.Medio();
        BE.Seguridad.BitacoraBE logBE = new BE.Seguridad.BitacoraBE();
        List<BE.Medio.Ubicacion> listubi = new List<BE.Medio.Ubicacion>();
        List<BE.Medio.Medio> listm = new List<BE.Medio.Medio>();
        List<BE.Cliente.Cliente> listcli = new List<BE.Cliente.Cliente>();
       
        decimal Preciopedido;       
        string nombremedio = ""; 
        int impresiones = 0;
 




        public CrearNegocio()
        {
            InitializeComponent();
        }

        private void CrearNegocio_Load(object sender, EventArgs e)
        {
            //cargar Medios
            listm = medioBLL.BuscarMedios();
            foreach (BE.Medio.Medio row in listm)
            {
                
                cmbmedio.Items.Add(row.MedioNombre.ToString());
            }
            //Cargar Agencias
            listcli = agenciasBLL.traeragencias();

            foreach (BE.Cliente.Cliente row in listcli)
            {
                cmbagencia.Items.Add(row.razon_social.ToString());
            }

            Pedido = medioBLL.traernumeropedido();

            lblNumeropedido.Text = Pedido.pedidoid.ToString();
        }

        private void btncalcularprecio_Click(object sender, EventArgs e)
        {
            if (txtprints.Text == "" || txtprints.Text == " " || cmbubicacion.Text == " " || cmbubicacion.Text == "" || cmbmedio.Text == "--Sin Asignar--")
            {
                MessageBox.Show("Por favor, Complete los campos", "Campos sin completar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            }
            else
            {
               
                UbiBE.medio = MedioBE;
                MedioBE.MedioNombre = cmbmedio.Text;
                UbiBE.NombreUbicacion = cmbubicacion.Text;
                impresiones = Convert.ToInt32(txtprints.Text);

                UbiBE = ubiBLL.traerPrecio(UbiBE);

                Preciopedido = UbiBE.Precio * impresiones;

                txtprecio.Text = Preciopedido.ToString();
            }
        }

        private void btn_grabar_Click(object sender, EventArgs e)
        {
            DateTime fechainicio = mcpublicacion.SelectionStart;
            DateTime fechafin = mcpublicacion.SelectionEnd;

            BLL.Pedido.PedidoBLL pedbll = new BLL.Pedido.PedidoBLL();

            try
            {
                if (impresiones == 0 || cmbagencia.Text == "" || cmbagencia.Text == " ")
                {
                    MessageBox.Show("Ha ocurrido un error,verifique los datos que ingresa ", "Verifique los datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else if (Convert.ToDecimal(txtprecio.Text) <= 0)
                {
                    MessageBox.Show("No se permiten valores menores a Cero", "Verifique los datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    Pedido.Preciopedido = Preciopedido;
                    Pedido.Impresiones = impresiones;
                    Pedido.FechainicioPublicacion = fechainicio;
                    Pedido.FechafinPublicacion = fechafin;
                    Pedido.Descripcion = txtdescripcion.Text;
                    UbiBE.NombreUbicacion = cmbubicacion.Text;
                    MedioBE.MedioNombre = cmbmedio.Text;
                    Pedido.NombreAgencia = cmbagencia.Text;
                    Pedido.ubicacion = UbiBE;
                    UbiBE.medio = MedioBE;
                    Pedido.medio = MedioBE;

                    string result = pedbll.GrabarNegocio(Pedido);


                    if (result == "Alta pedido exitosa")
                    {
                        logBE.NombreOperacion = cryp.Encriptar("Alta de Pedido");
                        logBE.Descripcion = cryp.Encriptar("Alta de pedido" + lblNumeropedido.Text + " realizada con Exito!");
                        logBE.Criticidad = 1;

                        logBE = logBLL.IngresarDatoBitacora(logBE.NombreOperacion, logBE.Descripcion, logBE.Criticidad, s.UsuarioID);

                        MessageBox.Show("Alta de Pedido Exitosa " + lblNumeropedido.Text + "", "Alta de Negocio", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Pedido = medioBLL.traernumeropedido();

                        lblNumeropedido.Text = Pedido.pedidoid.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error: --" + result + "-- ", "Error al grabar", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }


                }




            }
            catch (Exception ex)
            {

                MessageBox.Show("Ha ocurrido un error: " + ex.Message + " ", "Error al grabar", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbmedio_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cmbubicacion.Items.Clear();
                nombremedio = cmbmedio.Text;
                MedioBE.MedioNombre = nombremedio;
                listubi = ubiBLL.TraerUbicaciones(MedioBE);

                foreach (BE.Medio.Ubicacion row in listubi)
                {
                    cmbubicacion.Items.Add(row.NombreUbicacion);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
         

           
        }

        private void txtprints_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
             (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
