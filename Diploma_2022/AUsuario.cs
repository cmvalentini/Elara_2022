using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diploma_2022
{
    public partial class AUsuario : Form
    {

        string clavesinencriptar = "";
        string claveencriptada = "";

        BE.Usuario usuBE = new BE.Usuario();

        public AUsuario()
        {
            InitializeComponent();
        }

        private void AUsuario_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
            BLL.Seguridad.BitacoraBLL log = new BLL.Seguridad.BitacoraBLL();
            BE.Seguridad.BitacoraBE logbe = new BE.Seguridad.BitacoraBE();
            ServiceLayer.Sesion usulog = ServiceLayer.Sesion.GetInstance();

            try
            {
                bool _habilitado;
                if (checkHabilitado.Checked)
                {
                    _habilitado = true;
                }
                else { _habilitado = false; }


                BE.Seguridad.Encriptacion crip = new BE.Seguridad.Encriptacion();

                cryp.CrearPassword(crip);
                clavesinencriptar = crip.Result;

                crip.Texto = clavesinencriptar;
                crip = cryp.Encriptar(clavesinencriptar);
                claveencriptada = crip.Result;

                BE.Usuario usuBE = new BE.Usuario(txtuser.Text, txtLastname.Text, txtName.Text, txtMail.Text, int.Parse(txtDocument.Text), _habilitado, claveencriptada.ToString(), clavesinencriptar);
                BLL.UsuarioBLL usuBLL = new BLL.UsuarioBLL();

                //verificar si existe usuario
                BE.Usuario usuBE2 = new BE.Usuario();
                usuBE2 = usuBLL.BuscarUsuario(usuBE);  

                if (usuBE2._Usuario != null)
                {
                    MessageBox.Show("el nombre de usuario: " + txtuser.Text + " ya existe en la base de datos,verifique los usuarios", "Duplicidad de datos", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                }

                else
                {

                    
                    int oresult = usuBLL.verificarDuplicidad(usuBE);


                    switch (oresult)
                    {
                        case 1://dni repetido
                            MessageBox.Show("el dni: " + txtDocument.Text + " ya existe en la base de datos,verifique los usuarios", "Duplicidad de datos", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);

                            break;
                        case 2://email repetido
                            MessageBox.Show("el email: " + txtMail.Text + " ya existe en la base de datos,verifique los usuarios", "Duplicidad de datos", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                            break;
                        case 3://email y dni repetido
                            MessageBox.Show("el email: " + txtMail.Text + " y el dni:" + txtDocument.Text + " ya existe en la base de datos,verifique los usuarios", "Duplicidad de datos", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                            break;

                        case 5://usuario repetiro
                            MessageBox.Show("el usuario: " + txtuser.Text + " ", "Duplicidad de datos", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                            break;


                        case 4://no existe en la base

                            usuBLL.Dar_Alta_Usuario(usuBE);


                            MessageBox.Show("Usuario " + txtuser.Text + " se dió de alta satisfactoriamente, se envia clave al correo", "Alta de usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            string[] lineas = { " Usuario: " + txtuser.Text, " Clave: " + clavesinencriptar };

                            using (StreamWriter outputfile = new StreamWriter("C:\\Users\\Default\\Desktop\\Nueva carpeta\\Usuario.txt"))
                            {
                                foreach (string linea in lineas)
                                {
                                    outputfile.WriteLine(linea);
                                }




                            }

                            logbe.NombreOperacion = cryp.Encriptar("Alta Usuario").ToString();
                            logbe.Descripcion = cryp.Encriptar("Alta de " + txtuser.Text + " realizada con Exito!").ToString();
                            logbe.Criticidad = 1;

                            string rta = log.IngresarDatoBitacora(logbe.NombreOperacion, logbe.Descripcion, logbe.Criticidad, usulog.UsuarioID).ToString();


                            txtLastname.Clear();
                            txtDocument.Clear();
                            txtMail.Clear();
                            txtName.Clear();
                            txtuser.Clear();

                            break;

                        default: //ocurrio un error
                            MessageBox.Show("Ha ocurrido un error,code description: " + oresult.ToString(), "Error");
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
