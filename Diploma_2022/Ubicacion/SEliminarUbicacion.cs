using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diploma_2022.Ubicacion
{
    public partial class SEliminarUbicacion : Form
    {
        BLL.Medio.UbicacionBLL ubi = new BLL.Medio.UbicacionBLL();
        BE.Medio.Ubicacion ubiBE = new BE.Medio.Ubicacion();
        DataGridViewButtonColumn uninstallButtonColumn = new DataGridViewButtonColumn();
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        BLL.Seguridad.BitacoraBLL log = new BLL.Seguridad.BitacoraBLL();
        BE.Seguridad.BitacoraBE logBE = new BE.Seguridad.BitacoraBE();

        DataGridViewButtonColumn ModifyButtonColumn = new DataGridViewButtonColumn();
        ServiceLayer.Sesion s = ServiceLayer.Sesion.GetInstance();


        public SEliminarUbicacion()
        {
            InitializeComponent();
        }

        private void SEliminarUbicacion_Load(object sender, EventArgs e)
        {
            dgvubicaciones.DataSource = ubi.TraerUbicaciones();
            
            uninstallButtonColumn.Name = "Borraubicacion";
            uninstallButtonColumn.Text = "Borra Ubicación";
            uninstallButtonColumn.UseColumnTextForButtonValue = true; //dont forget this line
            this.dgvubicaciones.Columns.Add(uninstallButtonColumn);


            dgvubicaciones.ReadOnly = true;

        }

        private void actualizar_automatico_Tick(object sender, EventArgs e)
        {
 
            dgvubicaciones.DataSource = ubi.TraerUbicaciones();
            dgvubicaciones.AllowUserToAddRows = false;

            dgvubicaciones.Columns["ubicacionid"].Visible = false;
            dgvubicaciones.Columns["medioid"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvubicaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
               if (e.ColumnIndex == dgvubicaciones.Columns["Borraubicacion"].Index)
                {
                    ubiBE.Ubicacionid = Convert.ToInt16(dgvubicaciones.Rows[e.RowIndex].Cells["ubicacionid"].Value.ToString());

                    if ((MessageBox.Show("¿Esta seguro que desea Eliminar La Ubicacion de forma permanente?", "Eliminar Ubicación",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question,
        MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
                    {
                        try
                        {

                            //hacer
                            ubiBE = ubi.EliminarUbicacion(ubiBE);


                            if (ubiBE.Result == "True")
                            {

                                logBE.Criticidad = 2;
                                string a = dgvubicaciones.Rows[e.RowIndex].Cells[3].Value.ToString();
                                string b = dgvubicaciones.Rows[e.RowIndex].Cells[3].Value.ToString();
                                logBE.Descripcion = a + " " + b;
                                logBE.FechayHora = DateTime.Now;
                                logBE.NombreOperacion = "Eliminar Perfil";

                                log.IngresarDatoBitacora(cryp.Encriptar(logBE.NombreOperacion), cryp.Encriptar(logBE.Descripcion), logBE.Criticidad, s.UsuarioID);

                                // Recargar DataGrid
                                this.Load += new EventHandler(SEliminarUbicacion_Load);
                                MessageBox.Show("Perfil eliminado correctamente");

                            }
                            else
                            {
                                MessageBox.Show("Error en la eliminacion de Perfil " + ubiBE.Result , "Error al Borrado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }


                        }
                        catch (Exception ex)
                        {
                         MessageBox.Show("Error" + ex, "Se presentó un Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }


                    }
                }
            }

        }
    }

