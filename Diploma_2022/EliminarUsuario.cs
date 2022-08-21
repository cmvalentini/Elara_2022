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
    public partial class EliminarUsuario : Form
    {
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();

        BLL.Seguridad.BitacoraBLL log = new BLL.Seguridad.BitacoraBLL();
        List<BE.Usuario> listausuarios = new List<BE.Usuario>();
        BE.Usuario usuBE = new BE.Usuario();
        BE.Seguridad.BitacoraBE LogBE = new BE.Seguridad.BitacoraBE();
        DataGridViewButtonColumn uninstallButtonColumn = new DataGridViewButtonColumn();
         

        public EliminarUsuario()
        {
            InitializeComponent();
        }

        private void EliminarUsuario_Load(object sender, EventArgs e)
        {
            Timer actualizar_automatico = new Timer();
            actualizar_automatico.Interval = 80000;
            actualizar_automatico.Tick += actualizar_automatico_Tick;
            actualizar_automatico.Enabled = true;

            //dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //traigo usuarios y los cargo
            BLL.UsuarioBLL usu = new BLL.UsuarioBLL();

            listausuarios = usu.MostrarUsuarios();
            dgvUsuarios.DataSource = listausuarios;


            //añado boton borrar usuario
            uninstallButtonColumn.Name = "BorrarUsuario";
            uninstallButtonColumn.Text = "BorrarUsuario";
            uninstallButtonColumn.UseColumnTextForButtonValue = true; //dont forget this line
            this.dgvUsuarios.Columns.Add(uninstallButtonColumn);


            dgvUsuarios.ReadOnly = true;
            

            dgvUsuarios.Columns["UsuarioID"].Visible = false;
            dgvUsuarios.Columns["Clave"].Visible = false;
            dgvUsuarios.Columns["FlagIntentosLogin"].Visible = false;
            dgvUsuarios.Columns["clavesinencriptar"].Visible = false;
            dgvUsuarios.Columns["Result"].Visible = false;


        }

        private void actualizar_automatico_Tick(object sender, EventArgs e)
        {
            //traigo usuarios y los cargo
            BLL.UsuarioBLL usu = new BLL.UsuarioBLL();

            listausuarios = usu.MostrarUsuarios();
            dgvUsuarios.DataSource = listausuarios;


            dgvUsuarios.AllowUserToAddRows = false;

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BLL.UsuarioBLL usu = new BLL.UsuarioBLL();
            if (e.ColumnIndex == dgvUsuarios.Columns["BorrarUsuario"].Index)
            {
                //delete it!

                usuBE.UsuarioID = Convert.ToInt16(dgvUsuarios.Rows[e.RowIndex].Cells[0].Value.ToString());




                if ((MessageBox.Show("¿Esta seguro que desea Eliminar al usuario " + usuBE._Usuario + " de forma permanente?", "Eliminar Usuario",
    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
    MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
                {
                    try
                    {
                        BLL.Permisos.OperacionBLL OP = new BLL.Permisos.OperacionBLL();

                        usuBE = OP.verificarPatentesEscenciales(usuBE);

                        if (usuBE.Result == "True")
                        {




                            LogBE.Criticidad = 2;
                            string a = dgvUsuarios.Rows[e.RowIndex].Cells[3].Value.ToString();
                            string b = dgvUsuarios.Rows[e.RowIndex].Cells[3].Value.ToString();
                            LogBE.Descripcion = a + " " + b;
                            LogBE.FechayHora = DateTime.Now;
                            LogBE.NombreOperacion = "Eliminar Usuario";

                            log.IngresarDatoBitacora(cryp.Encriptar(LogBE.NombreOperacion).ToString(), cryp.Encriptar(LogBE.Descripcion).ToString(), LogBE.Criticidad, usuBE.UsuarioID);

                            usuBE = usu.EliminarUsuario(usuBE);


                             
                            MessageBox.Show("Usuario eliminado correctamente");
                            MessageBox.Show("Usuario eliminado correctamente", "Eliminación de Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Usuario con Patentes Unicas,no se puede eliminar!,Patentes: " + usuBE.Result, "Error al Borrado", MessageBoxButtons.OK, MessageBoxIcon.Stop);


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
