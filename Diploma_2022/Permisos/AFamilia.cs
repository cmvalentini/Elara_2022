using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diploma_2022.Permisos
{
    public partial class AFamilia : Form
    {

        BLL.Permisos.ManejadorPerfilUsuarios mpu = new BLL.Permisos.ManejadorPerfilUsuarios();
        BLL.Seguridad.BitacoraBLL log = new BLL.Seguridad.BitacoraBLL();
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        BE.Seguridad.PerfilUsuario mpuBE = new BE.Seguridad.PerfilUsuario();
        BE.Seguridad.BitacoraBE LogBE = new BE.Seguridad.BitacoraBE();

        ServiceLayer.Sesion sesion = ServiceLayer.Sesion.GetInstance();



        public AFamilia()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                mpuBE.NombrePerfil = txtNombrePerfil.Text;
                mpuBE.DescPerfil = txtDescripcionPerfil.Text;

                if ((txtNombrePerfil.Text == "") || (txtDescripcionPerfil.Text == ""))//no entra
                {
                    MessageBox.Show("Verifique los datos", "Campos de Texto sin asignar", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }


                else // Entra
                {

                    //   int verificar
                    mpuBE = mpu.VerificarAltafamilia(mpuBE);

                    if (Convert.ToInt16(mpuBE.Result) == 1) //ya existe
                    {
                        MessageBox.Show("El nombre de Perfil de Usuario ya existe en la base de datos, " +
                                        "Verifique el mismo o cambie el nombre", "Error al Borrado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else if (Convert.ToInt16(mpuBE.Result) == 0)//se puede crear
                    {
                        mpuBE = mpu._CrearPerfilUsuario(mpuBE);
                        MessageBox.Show("Se creo el Perfil de Usuario, configure las operaciones para el mismo", "Creacion de Perfil Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LogBE.Criticidad = 2;
                        LogBE.Descripcion = txtNombrePerfil.Text + " " + txtDescripcionPerfil.Text;
                        LogBE.FechayHora = DateTime.Now;
                        LogBE.NombreOperacion = "Alta Perfil";
                        MessageBox.Show(sesion.UsuarioID.ToString());
                        log.IngresarDatoBitacora(cryp.Encriptar(LogBE.NombreOperacion).ToString(), cryp.Encriptar(LogBE.Descripcion).ToString(), LogBE.Criticidad, sesion.UsuarioID);

                        txtDescripcionPerfil.Text = "";
                        txtNombrePerfil.Text = "";
                    }

                    else // hubo un quilombo con la BD
                    {
                        MessageBox.Show("Hubo un error con la base de datos,contacte con el administrador del sistema", "Error de Proceso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            
        }
    }
}
