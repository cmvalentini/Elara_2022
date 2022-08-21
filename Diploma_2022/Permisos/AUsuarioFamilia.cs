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
    public partial class AUsuarioFamilia : Form
    {
        BLL.UsuarioBLL usu = new BLL.UsuarioBLL();
        BE.Usuario UsuarioBE = new BE.Usuario();
        BE.Seguridad.PerfilUsuario PU = new BE.Seguridad.PerfilUsuario();

        BLL.Seguridad.BitacoraBLL log = new BLL.Seguridad.BitacoraBLL();
        BLL.Permisos.ManejadorPerfilUsuarios MPU = new BLL.Permisos.ManejadorPerfilUsuarios();
        List<BE.Seguridad.Operacion> listaoperaciones = new List<BE.Seguridad.Operacion>();
        ServiceLayer.Sesion sesion = ServiceLayer.Sesion.GetInstance();
        
     
        public AUsuarioFamilia(BE.Usuario usu)
        {
            UsuarioBE = usu;
            InitializeComponent();
        }

        private void AUsuarioFamilia_Load(object sender, EventArgs e)
        {
            lblNombreUsuario.Text = UsuarioBE._Usuario;
            PU = usu.traerDatosPerfil(UsuarioBE);

            if (PU == null)
            {
                lblNombrePerfil.Text = "Sin Perfil Asignado";
            }
            else
            {
                lblNombrePerfil.Text = PU.NombrePerfil.ToString();
            }

            //carga de los perfiles

            List<BE.Seguridad.PerfilUsuario> listaperfiles = new List<BE.Seguridad.PerfilUsuario>();
            listaperfiles = MPU.BuscarPerfilUsuarios();

            foreach (BE.Seguridad.PerfilUsuario item in listaperfiles)
            {
                cmbPerfiles.Items.Add(item.NombrePerfil.ToString());
            }


        }

        private void brn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAsignarPerfil_Click(object sender, EventArgs e)
        {

            if (cmbPerfiles.Text == "")
            {
                MessageBox.Show("Por favor seleccione un Perfil");
            }
            else{
                if ((MessageBox.Show("¿Esta seguro que desea asignarle el Perfil a " + UsuarioBE._Usuario.ToString() + "?", "Asignar Perfil Usuario",
MessageBoxButtons.YesNo, MessageBoxIcon.Question,
MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
                {
                    try
                    {
                        if (cmbPerfiles.Text == "")
                        {
                            MessageBox.Show("Asigne el Perfil de Usuario!");
                        }
                        else
                        {
                            BE.Seguridad.PerfilUsuario PUbe = new BE.Seguridad.PerfilUsuario();
                            PUbe.NombrePerfil = cmbPerfiles.Text;
                            //asignamos la familia al usuario
                            PUbe = MPU.AsignarUsuarioaPerfil(PUbe, UsuarioBE);



                        }

                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());

                    }

                }
            }

        }
    }
}
