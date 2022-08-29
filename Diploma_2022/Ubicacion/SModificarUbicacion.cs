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
    public partial class SModificarUbicacion : Form
    {
        BLL.Medio.UbicacionBLL ubi = new BLL.Medio.UbicacionBLL();
        BE.Medio.Ubicacion ubiBE = new BE.Medio.Ubicacion();
        
        DataGridViewButtonColumn ModifyButtonColumn = new DataGridViewButtonColumn();
       
        public SModificarUbicacion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SModificarUbicacion_Load(object sender, EventArgs e)
        {
            dgvubicaciones.DataSource = ubi.TraerUbicaciones();

            dgvubicaciones.ReadOnly = true;

            ModifyButtonColumn.Name = "ModificarUbicacion";
            ModifyButtonColumn.Text = "Modificar Ubicación";
            ModifyButtonColumn.UseColumnTextForButtonValue = true; 
            this.dgvubicaciones.Columns.Add(ModifyButtonColumn);


        }

        private void actualizar_automatico_Tick(object sender, EventArgs e)
        {
            dgvubicaciones.DataSource = ubi.TraerUbicaciones();
            dgvubicaciones.AllowUserToAddRows = false;

            dgvubicaciones.Columns["ubicacionid"].Visible = false;
            dgvubicaciones.Columns["medioid"].Visible = false;
        }

        private void dgvubicaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvubicaciones.Columns["ModificarUbicacion"].Index)
            {
                ubiBE.Ubicacionid = Convert.ToInt16(dgvubicaciones.Rows[e.RowIndex].Cells["ubicacionid"].Value.ToString());
                Ubicacion.ModificarUbicacion mu = new Ubicacion.ModificarUbicacion(ubiBE);
                mu.Show(); 
            }
        }
    }
}
