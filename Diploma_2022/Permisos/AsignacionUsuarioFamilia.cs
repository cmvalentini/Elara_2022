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
    public partial class AsignacionUsuarioFamilia : Form
    {

        BE.Usuario UsuBE = new BE.Usuario();
        List<BE.Usuario> listausuarios = new List<BE.Usuario>();
        BLL.UsuarioBLL UsuBLL = new BLL.UsuarioBLL();

        public AsignacionUsuarioFamilia()
        {
            InitializeComponent();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AsignacionUsuarioFamilia_Load(object sender, EventArgs e)
        {
            try
            {

                listausuarios = UsuBLL.traerUsuarios();

                foreach (BE.Usuario item in listausuarios)
                {
                    cmbUsuario.Items.Add(item._Usuario.ToString());

                     
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message); 
            }
            
        }

        private void btn_seleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbUsuario.Text != "")
                {
                    UsuBE._Usuario = cmbUsuario.Text;
                    Permisos.AUsuarioFamilia auf = new AUsuarioFamilia(UsuBE);
                    auf.Show();

                }
                else
                {
                    MessageBox.Show("Seleccione un usuario", "Campos de Texto sin asignar", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
