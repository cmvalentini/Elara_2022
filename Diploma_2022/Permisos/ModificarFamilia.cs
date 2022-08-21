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
    public partial class ModificarFamilia : Form
    {
        DataGridViewButtonColumn uninstallButtonColumn = new DataGridViewButtonColumn();
        BE.Seguridad.PerfilUsuario mpuBE = new BE.Seguridad.PerfilUsuario();
        List<BE.Seguridad.PerfilUsuario> listampu = new List<BE.Seguridad.PerfilUsuario>();
        BE.Seguridad.BitacoraBE LogBE = new BE.Seguridad.BitacoraBE();
        ServiceLayer.Sesion sesion = ServiceLayer.Sesion.GetInstance();
        
        public ModificarFamilia()
        {
            InitializeComponent();
        }

        private void ModificarFamilia_Load(object sender, EventArgs e)
        {
            Timer actualizar_automatico = new Timer();
            actualizar_automatico.Interval = 10000;
            actualizar_automatico.Tick += actualizar_automatico_Tick;
            actualizar_automatico.Enabled = true;

            
            //traigo usuarios y los cargo
            BLL.Permisos.ManejadorPerfilUsuarios mpf = new BLL.Permisos.ManejadorPerfilUsuarios();

            listampu = mpf.BuscarPerfilUsuarios();
            dgvPerfiles.DataSource = listampu;

              
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
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
            BLL.Permisos.ManejadorPerfilUsuarios MPU = new BLL.Permisos.ManejadorPerfilUsuarios();
            if (e.ColumnIndex == dgvPerfiles.Columns["ModificarPerfil"].Index)
            {
                //Modify 

                mpuBE.PerfilUsuarioID = Convert.ToInt16(dgvPerfiles.Rows[e.RowIndex].Cells["PerfilUsuarioID"].Value.ToString());
                mpuBE.NombrePerfil = dgvPerfiles.Rows[e.RowIndex].Cells["NombrePerfil"].Value.ToString();
                mpuBE.DescPerfil = dgvPerfiles.Rows[e.RowIndex].Cells["DescPerfil"].Value.ToString();
                

                Permisos.MFamilia mu = new Permisos.MFamilia(mpuBE);
                mu.Show();//mostrar form modificar


            }
        }
    }
}
