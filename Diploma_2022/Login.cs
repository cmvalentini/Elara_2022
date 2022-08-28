using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diploma_2022
{
    public partial class Login : Form
    {
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        string var1 = "";
        BE.Usuario UsuBE = new BE.Usuario();
        BE.Seguridad.BitacoraBE logBE = new BE.Seguridad.BitacoraBE();
        BLL.Seguridad.BitacoraBLL logbll = new BLL.Seguridad.BitacoraBLL();

        public Login()
        {
            InitializeComponent();
        }

        private void btn_ingresar_Click(object sender, EventArgs e)
        {
            if (txtclave.Text == "" || txtUsuario.Text == "")
            {
                MessageBox.Show("Por favor, complete los campos", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
             
            try
            {

                BLL.UsuarioBLL USU1 = new BLL.UsuarioBLL();
                UsuBE._Usuario = txtUsuario.Text;
                UsuBE.Clave = cryp.Encriptar(txtclave.Text);

                USU1.TraerDatosUsuario(UsuBE); //trae usuario y clave

                ServiceLayer.Sesion sesion = ServiceLayer.Sesion.GetInstance();

                if (sesion.FlagIntentosLogin >= 3)
                {
                    MessageBox.Show("El Usuario se encuentra Bloquedao");
                }
                else
                {
                    if (sesion.nombreusuario == null)
                    {

                        UsuBE =  USU1.BuscarUsuario(UsuBE);


                        if (UsuBE._Usuario == null)
                        {

                            MessageBox.Show("Usuario no Encontrado:Error 104", "ErrorUser", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            logBE.NombreOperacion = cryp.Encriptar("Login").ToString();
                            logBE.Descripcion = cryp.Encriptar("Login Usuario no encontrado" + txtUsuario.Text + " ").ToString();
                            logBE.Criticidad = 4;
                            logBE.Usuarioid = 0;
                            string rta = logbll.IngresarDatoBitacora(logBE.NombreOperacion.ToString(), logBE.Descripcion, logBE.Criticidad, logBE.Usuarioid).ToString();

                        }
                        else
                        {
                            switch (UsuBE._Usuario.ToString())
                            {
                                case "null":
                                    MessageBox.Show("Usuario no Encontrado:Error 105", "ErrorUser", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;
                                case "":
                                    MessageBox.Show("Complete el campo usuario por favor", "ErrorUser", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    logBE.NombreOperacion = cryp.Encriptar("Login").ToString();
                                    logBE.Descripcion = cryp.Encriptar("Login Usuario no encontrado" + txtUsuario.Text + " ").ToString();
                                    logBE.Criticidad = 4;
                                    logBE.Usuarioid = 0;
                                    string rta = logbll.IngresarDatoBitacora(logBE.NombreOperacion, logBE.Descripcion, logBE.Criticidad, logBE.Usuarioid).ToString();

                                    break;

                                default:

                                    MessageBox.Show("Clave incorrecta para usuario ");
                                    if (UsuBE.FlagIntentosLogin >= 3)
                                    {
                                        //MessageBox.Show("El Usuario se encuentra Bloquedao");
                                        MessageBox.Show("El Usuario se encuentra Bloqueado", "Usuario Bloqueado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                        // ENVIO MAIL CON PASSWORD NUEVA
                                        string clave = cryp.CrearPassword().ToString();
                                        string claveencriptada = cryp.Encriptar(clave).ToString();


                                        USU1.EnviarMail(UsuBE, claveencriptada, clave);

                                    }
                                    else
                                    {
                                        logBE.NombreOperacion = cryp.Encriptar("Login").ToString();
                                        logBE.Descripcion = cryp.Encriptar("Clave incorrecta para usuario" + txtUsuario.Text + " ").ToString();
                                        logBE.Criticidad = 4;
                                        logBE.Usuarioid = UsuBE.UsuarioID;
                                        rta = logbll.IngresarDatoBitacora(logBE.NombreOperacion, logBE.Descripcion, logBE.Criticidad, logBE.Usuarioid).ToString();
                                        USU1.SumarFlagIntentos(UsuBE); //usuid
                                    }
                                    break;
                            }
                        }

                    }
                    else
                    {

                        logBE.NombreOperacion = cryp.Encriptar("Login");
                        logBE.Descripcion = cryp.Encriptar("Login Exitoso: " + txtUsuario.Text + " ").ToString();
                        logBE.Criticidad = 5;
                        logBE.Usuarioid = sesion.UsuarioID;

                        MessageBox.Show(logBE.NombreOperacion);

                        //USUARIO Y CLAVE CORRECTOS
                        string rta = logbll.IngresarDatoBitacora(logBE.NombreOperacion.ToString(), logBE.Descripcion, logBE.Criticidad, logBE.Usuarioid).ToString();

                        MenuPrincipal mp = new MenuPrincipal();

                        UsuBE.UsuarioID = sesion.UsuarioID;
                        USU1.BlanquearIntentos(UsuBE);
                        mp.Show();


                        //this.Close();



                    }
                    
                   



                }
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message );
                
                 
            }


        }

        private void CheckCambiarClave_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckCambiarClave.Checked)
            {
                this.Size = new Size(458, 491);
            }

            else { this.Size = new Size(441, 304); }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                MessageBox.Show("Por favor ingrese Usuario en donde lo indica", "ErrorUser", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                BLL.UsuarioBLL USU = new BLL.UsuarioBLL();
                BE.Usuario usuBE = new BE.Usuario();
                BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();

                BE.Seguridad.Encriptacion entcrip = new BE.Seguridad.Encriptacion();



                string result = cryp.Encriptar(txtClaveAtn.Text);
                string var2 = "";
                string var3 = "";

                var2 = result;

                try
                {
                    UsuBE._Usuario = txtUsuario.Text;
                    UsuBE.Clave = var2;
                    usuBE = USU.BuscarUsuario(UsuBE,var2);

                    if (UsuBE._Usuario != null)
                    {
                        try
                        {


                            result = cryp.Encriptar(txtClaveNew.Text);
                            usuBE.Clave = result;
                            UsuBE = USU.CambiarClave(UsuBE,var3);
                            MessageBox.Show("Se cambió la Clave exitosamente  " + UsuBE.Result);

                            logBE.NombreOperacion = cryp.Encriptar("Cambio de Clave").ToString();
                            logBE.Descripcion = cryp.Encriptar("Cambio Exitoso: " + txtUsuario.Text + " ").ToString();
                            logBE.Criticidad = 3;
                            logBE.Usuarioid = usuBE.UsuarioID;

                            logbll.IngresarDatoBitacora(logBE.NombreOperacion, logBE.Descripcion, logBE.Criticidad, logBE.Usuarioid);

                            txtClaveAtn.Text = "";
                            txtClaveNew.Text = "";
                        }

                        catch (Exception)
                        {
                            MessageBox.Show("Hubo un error al cambiar la clave");
                            throw;
                        }


                    }

                    else { MessageBox.Show("La Clave ingresada, no coincide con la anterior"); }



                }
                catch (Exception  ex)
                {

                    MessageBox.Show( "Hubo el siguiente error:  " + ex.Message);
                }



            }

        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
