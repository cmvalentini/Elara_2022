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
    public partial class AsignarFamilia : Form
    {

        DataGridViewButtonColumn AsingButtonColumn = new DataGridViewButtonColumn();
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        BLL.Seguridad.BitacoraBLL log = new BLL.Seguridad.BitacoraBLL();
        BE.Seguridad.PerfilUsuario mpuBE = new BE.Seguridad.PerfilUsuario();
        List<BE.Seguridad.PerfilUsuario> listampu = new List<BE.Seguridad.PerfilUsuario>();
        BE.Seguridad.BitacoraBE LogBE = new BE.Seguridad.BitacoraBE();
        ServiceLayer.Sesion sesion = ServiceLayer.Sesion.GetInstance();

        public AsignarFamilia()
        {
            InitializeComponent();
        }

        private void AsignarFamilia_Load(object sender, EventArgs e)
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

            AsingButtonColumn.Name = "AsignarOperaciones";
            AsingButtonColumn.Text = "Asignar Familia de Permisos";
            AsingButtonColumn.UseColumnTextForButtonValue = true;
            this.dgvPerfiles.Columns.Add(AsingButtonColumn);
            dgvPerfiles.Columns["PerfilUsuarioID"].Visible = false;
            dgvPerfiles.Columns["Result"].Visible = false;
        }

        private void dgvPerfiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                    mpuBE.PerfilUsuarioID = Convert.ToInt16(dgvPerfiles.Rows[e.RowIndex].Cells["PerfilUsuarioID"].Value.ToString());
                    mpuBE.NombrePerfil = dgvPerfiles.Rows[e.RowIndex].Cells["NombrePerfil"].Value.ToString();
                    mpuBE.DescPerfil = dgvPerfiles.Rows[e.RowIndex].Cells["DescPerfil"].Value.ToString();

                    AsignarOperacionesAPerfil aop = new AsignarOperacionesAPerfil(mpuBE);
                    aop.Show();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
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

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
