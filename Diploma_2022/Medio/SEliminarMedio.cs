using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diploma_2022.Medio
{
    public partial class SEliminarMedio : Form
    {
        DataGridViewButtonColumn uninstallButtonColumn = new DataGridViewButtonColumn();
         
        BLL.Medio.MedioBLL medioBLL = new BLL.Medio.MedioBLL();
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        BLL.Seguridad.BitacoraBLL log = new BLL.Seguridad.BitacoraBLL();
        List<BE.Medio.Medio> listamedios = new List<BE.Medio.Medio>();
        BE.Medio.Medio medioBE = new BE.Medio.Medio();
        BE.Seguridad.BitacoraBE LogBE = new BE.Seguridad.BitacoraBE();

        public SEliminarMedio()
        {
            InitializeComponent();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SEliminarMedio_Load(object sender, EventArgs e)
        {
            Timer actualizar_automatico = new Timer();
            actualizar_automatico.Interval = 30000;
            actualizar_automatico.Tick += actualizar_automatico_Tick;
            actualizar_automatico.Enabled = true;

             
           
            BLL.Medio.MedioBLL medio = new BLL.Medio.MedioBLL();

            listamedios = medio.BuscarMedios();
            dgvMedios.DataSource = listamedios;


            dgvMedios.ReadOnly = true;

            uninstallButtonColumn.Name = "BorraMedio";
            uninstallButtonColumn.Text = "Borra Medio";
            uninstallButtonColumn.UseColumnTextForButtonValue = true; 
            this.dgvMedios.Columns.Add(uninstallButtonColumn);

            dgvMedios.Columns["medioid"].Visible = false;
        }

        private void actualizar_automatico_Tick(object sender, EventArgs e)
        {
            //traigo usuarios y los cargo

            listamedios.Clear();
            listamedios = medioBLL.BuscarMedios();
            dgvMedios.DataSource = listamedios;
            dgvMedios.AllowUserToAddRows = false;
        }

        private void dgvMedios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           if (e.ColumnIndex == dgvMedios.Columns["BorraMedio"].Index)
            {
                medioBE.Medioid = Convert.ToInt16(dgvMedios.Rows[e.RowIndex].Cells["medioid"].Value);



                if ((MessageBox.Show("¿Esta seguro que desea Eliminar el Medio de forma permanente?", "Eliminar Perfil Usuario",
MessageBoxButtons.YesNo, MessageBoxIcon.Question,
MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
                {
                    try
                    {


                        medioBE = medioBLL.Eliminarmedio(medioBE);

                        if (medioBE.Result == "True")
                        {

                            LogBE.Criticidad = 2;
                            string a = dgvMedios.Rows[e.RowIndex].Cells[3].Value.ToString();
                            string b = dgvMedios.Rows[e.RowIndex].Cells[3].Value.ToString();
                            LogBE.Descripcion = a + " " + b;
                            LogBE.FechayHora = DateTime.Now;
                            LogBE.NombreOperacion = "Eliminar Medio";
                            BE.Seguridad.Encriptacion cyrp = new BE.Seguridad.Encriptacion();
                            ServiceLayer.Sesion s = ServiceLayer.Sesion.GetInstance();
                            log.IngresarDatoBitacora(cryp.Encriptar(LogBE.NombreOperacion).ToString(), cryp.Encriptar(LogBE.Descripcion).ToString(), LogBE.Criticidad, s.UsuarioID);

                            // Recargar DataGrid
                          
                             
                            MessageBox.Show("Medio eliminado correctamente");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Error en la eliminación del Medio " + medioBE.Result, "Error al Borrado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hubo un error: " + ex.Message.ToString(), "Error,contacte al administrador", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    }

                }



            }//fin if
        }
    }
}
