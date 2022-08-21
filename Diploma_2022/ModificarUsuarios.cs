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
    public partial class ModificarUsuarios : Form
    {


        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();

        BLL.Seguridad.BitacoraBLL log = new BLL.Seguridad.BitacoraBLL();
        List<BE.Usuario> listausuarios = new List<BE.Usuario>();
        BE.Usuario usuBE = new BE.Usuario();
        BE.Seguridad.BitacoraBE LogBE = new BE.Seguridad.BitacoraBE();
        DataGridViewButtonColumn uninstallButtonColumn = new DataGridViewButtonColumn();
        DataGridViewButtonColumn ModifyButtonColumn = new DataGridViewButtonColumn();

        public ModificarUsuarios()
        {
            InitializeComponent();
        }
      
        private void ModificarUsuarios_Load(object sender, EventArgs e)
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

         
            dgvUsuarios.ReadOnly = true;

            //añado boton Modificar usuario


            ModifyButtonColumn.Name = "ModificarUsuario";
            ModifyButtonColumn.Text = "ModificarUsuario";
            ModifyButtonColumn.UseColumnTextForButtonValue = true; //dont forget this line
            this.dgvUsuarios.Columns.Add(ModifyButtonColumn);



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

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                BLL.UsuarioBLL usu = new BLL.UsuarioBLL();
                if (e.ColumnIndex == dgvUsuarios.Columns["ModificarUsuario"].Index)
                {
                    //Modify 
             //       usuBE.UsuarioID = Convert.ToInt16(dgvUsuarios.Rows[e.RowIndex].Cells[0].Value.ToString());
                  usuBE.UsuarioID = Convert.ToInt16(dgvUsuarios.Rows[e.RowIndex].Cells[0].Value.ToString());
               
           
                    MUsuario mu = new MUsuario(usuBE);

                    mu.Show();


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
         


        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
