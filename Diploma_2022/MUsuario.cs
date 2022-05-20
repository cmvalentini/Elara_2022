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
    public partial class MUsuario : Form
    {
        BE.Usuario usube = new BE.Usuario();
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        BLL.UsuarioBLL usu = new BLL.UsuarioBLL();
        BLL.Seguridad.BitacoraBLL log = new BLL.Seguridad.BitacoraBLL();
        BE.Seguridad.BitacoraBE LogBE = new BE.Seguridad.BitacoraBE();
 
        public MUsuario(BE.Usuario usu)
        {
            usube = usu ;
            InitializeComponent();
        }



        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                usube.Dni = int.Parse(txtdni.Text);
                usube.Email = txtemail.Text;
                usube._Usuario = txtuser.Text;

                int oresult = usu.verificarDuplicidad(usube);

                switch (oresult)
                {
                    case 1://dni repetido
                        MessageBox.Show("el dni: " + txtdni.Text + " ya existe en la base de datos,verifique los usuarios", "Duplicidad de datos", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);

                        break;
                    case 2://email repetido
                        MessageBox.Show("el email: " + txtemail.Text + " ya existe en la base de datos,verifique los usuarios", "Duplicidad de datos", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                        break;
                    case 3://email y dni repetido
                        MessageBox.Show("el email: " + txtemail.Text + " y el dni:" + txtdni.Text + " ya existe en la base de datos,verifique los usuarios", "Duplicidad de datos", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                        break;
                    case 5://Usuario repetido
                        MessageBox.Show("el Usuario: " + txtuser.Text + " !", "Duplicidad de datos", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                        break;
                    case 4: //modifica*/
                        try
                        {
                            bool check;
                            if (checkHabilitado.Checked)
                            {
                                check = true;
                            }
                            else
                            {
                                check = false;
                            }
                            usube = usu.ModificarDatosUsuario(usube);

                            MessageBox.Show(usube.Result);

                            LogBE.Criticidad = 3;
                            LogBE.Descripcion = txtuser.Text + " " + txtlastname.Text + " " + txtname.Text + " " + txtemail.Text + " "
                            + txtdni.Text + " " + check + " " + usube.UsuarioID;
                            LogBE.FechayHora = DateTime.Now;
                            LogBE.NombreOperacion = "Modificar Usuario";

                            log.IngresarDatoBitacora(cryp.Encriptar(LogBE.NombreOperacion).ToString(), cryp.Encriptar(LogBE.Descripcion).ToString(), LogBE.Criticidad, usube.UsuarioID);


                            this.Close();
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message);
                        }
                        break;


                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void MUsuario_Load(object sender, EventArgs e)
        {
            usube = usu.TraerDatosUsuariobyID(usube);

            txtname.Text = usube.Nombre.ToString();
            txtdni.Text = usube.Dni.ToString();
            txtemail.Text = usube.Email.ToString();
            txtlastname.Text = usube.Apellido.ToString();
            txtuser.Text = usube._Usuario.ToString();

            if (usube.Habilitado.ToString() == "true")
            {
                checkHabilitado.Checked = true;
            }
            else
            {
                checkHabilitado.Checked = false;
            }
        }
    }
}
