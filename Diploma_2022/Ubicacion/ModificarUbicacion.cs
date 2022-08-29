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
    public partial class ModificarUbicacion : Form
    {
        BE.Medio.Ubicacion UbicacionBE = new BE.Medio.Ubicacion();
        BE.Medio.Medio MedioBE = new BE.Medio.Medio();
        BLL.Medio.UbicacionBLL ubiBLL = new BLL.Medio.UbicacionBLL();
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        BLL.Seguridad.BitacoraBLL log = new BLL.Seguridad.BitacoraBLL();
        ServiceLayer.Sesion s = ServiceLayer.Sesion.GetInstance();
        BE.Seguridad.BitacoraBE logBE = new BE.Seguridad.BitacoraBE();
        BLL.Medio.MedioBLL mediosbll = new BLL.Medio.MedioBLL();
        List<BE.Medio.Medio> listamedios = new List<BE.Medio.Medio>();
        public ModificarUbicacion(BE.Medio.Ubicacion UbiBE)
        {
            UbicacionBE = UbiBE;
            InitializeComponent();
        }

        private void ModificarUbicacion_Load(object sender, EventArgs e)
        {
            //cargar combobox
            listamedios = mediosbll.BuscarMedios();

            foreach (BE.Medio.Medio row in listamedios)
            {
                cmbmedio.Items.Add(row.MedioNombre);
            }


            UbicacionBE = ubiBLL.seliccionarUbicacion(UbicacionBE);

            txtformato.Text = UbicacionBE.Formato;
            txtformula.Text = UbicacionBE.Formula;
            txtmedida.Text = UbicacionBE.Medida;
            txtnombreubicacion.Text = UbicacionBE.NombreUbicacion;
            //cmbmedio.Text = ubi.medio;
            chkhabilitado.Checked = Convert.ToBoolean(UbicacionBE.Habilitado);
            txtPrecio.Text = UbicacionBE.Precio.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_acept_Click(object sender, EventArgs e)
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
                    UbicacionBE.Formato = txtformato.Text;
                    UbicacionBE.Formula = txtformula.Text;
                    MedioBE.MedioNombre = cmbmedio.Text;
                    UbicacionBE.medio = MedioBE;
                    UbicacionBE.Medida = txtmedida.Text;
                    UbicacionBE.NombreUbicacion = txtnombreubicacion.Text;
                    UbicacionBE.Ubicacionid = UbicacionBE.Ubicacionid;
                    UbicacionBE.Precio = Convert.ToDecimal(txtPrecio.Text);

                    if (chkhabilitado.Checked == true){
                        UbicacionBE.Habilitado = 1;
                    }
                    else{
                        UbicacionBE.Habilitado = 0;
                    }


                    UbicacionBE = ubiBLL.Modificarubicacion(UbicacionBE);


                    MessageBox.Show("Se Modificó La ubicación exitosamente", "Modificación de Ubicación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    logBE.Criticidad = 2;
                    logBE.Descripcion = txtnombreubicacion.Text + " " + txtformato.Text;
                    logBE.FechayHora = DateTime.Now;
                    logBE.NombreOperacion = "Modificacion Ubicación";
                    log.IngresarDatoBitacora(cryp.Encriptar(logBE.NombreOperacion).ToString(), cryp.Encriptar(logBE.Descripcion).ToString(), logBE.Criticidad, s.UsuarioID);


                    txtformato.Text = "";
                    txtformula.Text = "";
                    txtmedida.Text = "";
                    txtnombreubicacion.Text = "";
                    txtPrecio.Text = "";


                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Hubo un error ,contacte con el administrador del sistema \n" + ex.Message, "Error de Proceso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }
    }
}
