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
    public partial class EliminarFamilia : Form
    {

        DataGridViewButtonColumn uninstallButtonColumn = new DataGridViewButtonColumn();
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        BLL.Seguridad.BitacoraBLL log = new BLL.Seguridad.BitacoraBLL();
        BE.Seguridad.PerfilUsuario mpuBE = new BE.Seguridad.PerfilUsuario();
        List<BE.Seguridad.PerfilUsuario> listampu = new List<BE.Seguridad.PerfilUsuario>();
        BE.Seguridad.BitacoraBE LogBE = new BE.Seguridad.BitacoraBE();
        ServiceLayer.Sesion sesion = ServiceLayer.Sesion.GetInstance();
        public EliminarFamilia()
        {
            InitializeComponent();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EliminarFamilia_Load(object sender, EventArgs e)
        {
            Timer actualizar_automatico = new Timer();
            actualizar_automatico.Interval = 10000;
            actualizar_automatico.Tick += actualizar_automatico_Tick;
            actualizar_automatico.Enabled = true;


            //traigo usuarios y los cargo
            BLL.Permisos.ManejadorPerfilUsuarios mpf = new BLL.Permisos.ManejadorPerfilUsuarios();

            listampu = mpf.BuscarPerfilUsuarios();
            dgvPerfiles.DataSource = listampu;


            //añado boton Modificar usuario

            uninstallButtonColumn.Name = "EliminarPerfil";
            uninstallButtonColumn.Text = "EliminarPerfil";
            uninstallButtonColumn.UseColumnTextForButtonValue = true;
            this.dgvPerfiles.Columns.Add(uninstallButtonColumn);
            dgvPerfiles.Columns["PerfilUsuarioID"].Visible = false;
            dgvPerfiles.Columns["Result"].Visible = false;



        }

        private void actualizar_automatico_Tick(object sender, EventArgs e)
        {
            //traigo usuarios y los cargo
            BLL.Permisos.ManejadorPerfilUsuarios mpu = new BLL.Permisos.ManejadorPerfilUsuarios();
            listampu.Clear();
            listampu = mpu.BuscarPerfilUsuarios();
            dgvPerfiles.DataSource = listampu;
            dgvPerfiles.AllowUserToAddRows = false;

        }


        private void dgvPerfiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                    
                //delete it!
                try
                {
                    mpuBE.PerfilUsuarioID = Convert.ToInt16(dgvPerfiles.Rows[e.RowIndex].Cells["PerfilUsuarioID"].Value.ToString());



                    if ((MessageBox.Show("¿Esta seguro que desea Eliminar el perfil de forma permanente?", "Eliminar Perfil Usuario",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question,
        MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
                    {

                        BLL.Permisos.ManejadorPerfilUsuarios MPU = new BLL.Permisos.ManejadorPerfilUsuarios();

                        mpuBE = MPU.EliminarPerfilUsuario(mpuBE);

                        if (mpuBE.Result == "True")
                        {

                            LogBE.Criticidad = 2;
                            string a = dgvPerfiles.Rows[e.RowIndex].Cells[3].Value.ToString();
                            string b = dgvPerfiles.Rows[e.RowIndex].Cells[3].Value.ToString();
                            LogBE.Descripcion = a + " " + b;
                            LogBE.FechayHora = DateTime.Now;
                            LogBE.NombreOperacion = "Eliminar Perfil";
                            ServiceLayer.Sesion sesion = ServiceLayer.Sesion.GetInstance();
                            log.IngresarDatoBitacora(cryp.Encriptar(LogBE.NombreOperacion).ToString(), cryp.Encriptar(LogBE.Descripcion).ToString(), LogBE.Criticidad, sesion.UsuarioID);

                                      
                            MessageBox.Show("Perfil eliminado correctamente, salga de la pestaña para ver reflejado los cambios", "Eliminación de Perfil", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        }
                        else
                        {
                            MessageBox.Show("El perfil esta siendo utilizado, no se puede eliminar " + mpuBE.Result, "Error al Borrado", MessageBoxButtons.OK, MessageBoxIcon.Stop);


                        }



                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());

                }

       
        }
    }
}
