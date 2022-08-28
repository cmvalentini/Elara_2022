using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diploma_2022.Bitacora
{
    public partial class Consultar_Bitacora : Form
    {
        BLL.Seguridad.BitacoraBLL log = new BLL.Seguridad.BitacoraBLL();
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        List<BE.Usuario> listausuarios = new List<BE.Usuario>();
        List<BE.Seguridad.BitacoraBE> ListaLogs = new List<BE.Seguridad.BitacoraBE>();
         
        public Consultar_Bitacora()
        {
            InitializeComponent();
        }

        private void Consultar_Bitacora_Load(object sender, EventArgs e)
        {
            BLL.UsuarioBLL usubll = new BLL.UsuarioBLL();
            listausuarios = usubll.traerUsuarios();
            cmbUsuario.Items.Add("Todos");

            foreach (BE.Usuario item in listausuarios)
            {
                BE.Usuario usu = new BE.Usuario();
                usu = item;

                cmbUsuario.Items.Add(item._Usuario.ToString());
 
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           this.ExportarExcel(); 
        }

        private void ExportarExcel()
        {
            SaveFileDialog fichero = new SaveFileDialog();
            fichero.Filter = "Excel (*.xls)|*.xls";
            if (fichero.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel.Application aplicacion;
                Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                aplicacion = new Microsoft.Office.Interop.Excel.Application();
                libros_trabajo = aplicacion.Workbooks.Add();
                hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
                //Recorremos el DataGridView rellenando la hoja de trabajo
                for (int i = 0; i < dgvBitacora.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgvBitacora.Columns.Count; j++)
                    {
                        hoja_trabajo.Cells[i + 1, j + 1] = dgvBitacora.Rows[i].Cells[j].Value.ToString();
                    }
                }
                libros_trabajo.SaveAs(fichero.FileName,
                    Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                libros_trabajo.Close(true);
                aplicacion.Quit();
            }


            MessageBox.Show("Excel Exportado con Exito", "Exportacion Excel OK", MessageBoxButtons.OK,
                     MessageBoxIcon.Information);

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime fechadesde = Convert.ToDateTime(dtpdesde.Text);
                DateTime fechahasta = Convert.ToDateTime(dtphasta.Text);
                string criticidad = cmbCriticidad.Text;
                string usuario = cmbUsuario.Text;
                string sqlusuario = "";
                string sqlcriticidad = "";

                switch (usuario)
                {
                    case "":
                        MessageBox.Show("seccione un usuario", "Usuario Vacio", MessageBoxButtons.OK,
                      MessageBoxIcon.Hand);
                        break;
                    case "Todos":
                        sqlusuario = "select usuarioid from usuario";
                        break;
                    default:
                        sqlusuario = "select usuarioid from usuario where usuario like '" + usuario + "'";
                        break;
                }

                switch (criticidad)
                {
                    case "":
                        MessageBox.Show("seccione un usuario", "Usuario Vacio", MessageBoxButtons.OK,
                      MessageBoxIcon.Hand);
                        break;
                    case "Todas":
                        sqlcriticidad = "select distinct criticidad from bitacora";
                        break;
                    default:
                        sqlcriticidad = "select criticidad from bitacora where criticidad = " + Convert.ToInt16(criticidad) + "";
                        break;
                }

                //llenamos la bitacora con todo lo filtrado

               

                ListaLogs = log.ConsultarBitacora(fechadesde, fechahasta, sqlcriticidad, sqlusuario);



                foreach (BE.Seguridad.BitacoraBE item in ListaLogs)
                {
                    string cryp1 = "";
                    cryp1 = cryp.Desencriptar(item.NombreOperacion);
                    //MessageBox.Show(cryp1);
                    item.NombreOperacion = cryp1;
                    cryp1 = cryp.Desencriptar(item.Descripcion);
                   // MessageBox.Show(cryp1);
                    item.Descripcion = cryp1;

                }

                dgvBitacora.DataSource = ListaLogs;
                dgvBitacora.ReadOnly = true;

                this.dgvBitacora.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                this.dgvBitacora.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                this.dgvBitacora.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                this.dgvBitacora.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                this.dgvBitacora.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;




            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
