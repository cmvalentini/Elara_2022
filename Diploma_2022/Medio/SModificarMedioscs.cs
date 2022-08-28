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
    public partial class SModificarMedioscs : Form
    {

       
        
        DataGridViewButtonColumn ModifyButtonColumn = new DataGridViewButtonColumn();
        
        BLL.Medio.MedioBLL medio = new BLL.Medio.MedioBLL();
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        List<BE.Medio.Medio> listamedios = new List<BE.Medio.Medio>();
        public SModificarMedioscs()
        {
            InitializeComponent();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SModificarMedioscs_Load(object sender, EventArgs e)
        {
            Timer actualizar_automatico = new Timer();
            actualizar_automatico.Interval = 30000;
            actualizar_automatico.Tick += actualizar_automatico_Tick;
            actualizar_automatico.Enabled = true;

            //dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //traigo usuarios y los cargo
            BLL.Medio.MedioBLL medio = new BLL.Medio.MedioBLL();

            listamedios = medio.BuscarMedios();
            dgvMedios.DataSource = listamedios;

            
            dgvMedios.ReadOnly = true;

            //añado boton Modificar usuario

            ModifyButtonColumn.Name = "ModificarMedio";
            ModifyButtonColumn.Text = "Modificar Medio";
            ModifyButtonColumn.UseColumnTextForButtonValue = true; //dont forget this line
            this.dgvMedios.Columns.Add(ModifyButtonColumn);

            dgvMedios.Columns["medioid"].Visible = false;

        }


        private void actualizar_automatico_Tick(object sender, EventArgs e)
        {
            //traigo usuarios y los cargo

            listamedios.Clear();
            listamedios = medio.BuscarMedios();
            dgvMedios.DataSource = listamedios;
            dgvMedios.AllowUserToAddRows = false;
        }

        private void dgvMedios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //modify
            if (e.ColumnIndex == dgvMedios.Columns["ModificarMedio"].Index)
            {
                //Modify 

                string medioid = dgvMedios.Rows[e.RowIndex].Cells["medioid"].Value.ToString();

                Medio.ModificarMedio mu = new Medio.ModificarMedio(Convert.ToInt16(medioid));
                mu.Show();//mostrar form modificar

          
            }

        }
    }
}
