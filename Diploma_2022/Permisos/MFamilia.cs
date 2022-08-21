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
    public partial class MFamilia : Form
    {

        BLL.Permisos.ManejadorPerfilUsuarios mpu = new BLL.Permisos.ManejadorPerfilUsuarios();
        BLL.Seguridad.BitacoraBLL log = new BLL.Seguridad.BitacoraBLL();
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        BE.Seguridad.BitacoraBE logbe = new BE.Seguridad.BitacoraBE();
        BE.Seguridad.PerfilUsuario PuBE = new BE.Seguridad.PerfilUsuario(); 
        public MFamilia(BE.Seguridad.PerfilUsuario PUBE)
        {
            InitializeComponent();
            PuBE = PUBE;
        }

        private void MFamilia_Load(object sender, EventArgs e)
        {
            List<BE.Seguridad.PerfilUsuario> ListaPerfiles = new List<BE.Seguridad.PerfilUsuario>();




            txtNombrePerfil.Text = PuBE.NombrePerfil;
            txtDescripcionPerfil.Text = PuBE.DescPerfil;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((txtNombrePerfil.Text == "") || (txtDescripcionPerfil.Text == ""))//no entra
            {
                MessageBox.Show("Verifique los datos", "Campos de Texto sin asignar", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                PuBE.NombrePerfil = txtNombrePerfil.Text;
                PuBE.DescPerfil = txtDescripcionPerfil.Text;
                PuBE.PerfilUsuarioID = PuBE.PerfilUsuarioID;

                PuBE = mpu.ModificarPerfilUsuario(PuBE);
                ServiceLayer.Sesion sesion = ServiceLayer.Sesion.GetInstance();
                if (PuBE.Result == "True")
                {
                    logbe.Criticidad = 2;
                    logbe.Descripcion = txtNombrePerfil.Text + " " + txtDescripcionPerfil.Text;
                    logbe.FechayHora = DateTime.Now;
                    logbe.NombreOperacion = "Modificacion Perfil";
                    log.IngresarDatoBitacora(cryp.Encriptar(logbe.NombreOperacion).ToString(), cryp.Encriptar(logbe.Descripcion).ToString(), logbe.Criticidad, sesion.UsuarioID);

                    txtDescripcionPerfil.Text = "";
                    txtNombrePerfil.Text = "";

                    MessageBox.Show("Se modificó el perfil exitosamente", "Modificacion OK", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("No se pudo modificar el perfil", "Modificacion Incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }




            }
        }
    }
}
