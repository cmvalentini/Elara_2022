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
    public partial class AsignarOperacionesAPerfil : Form
    {
        BLL.Permisos.ManejadorPerfilUsuarios MPU = new BLL.Permisos.ManejadorPerfilUsuarios();
        List<BE.Seguridad.Operacion> listaoperaciones = new List<BE.Seguridad.Operacion>();
        BE.Seguridad.Operacion ope = new BE.Seguridad.Operacion();
        BE.Seguridad.PerfilUsuario PerfilBE = new BE.Seguridad.PerfilUsuario();
        public AsignarOperacionesAPerfil(BE.Seguridad.PerfilUsuario PuBE)
        {
            PerfilBE = PuBE;
            InitializeComponent();
        }

        private void AsignarOperacionesAPerfil_Load(object sender, EventArgs e)
        {
            lblNombreUsuario.Text = PerfilBE.NombrePerfil;

            //Muestro lista de operaciones
          
            listaoperaciones = MPU.MostrarListaOperaciones();
            foreach (BE.Seguridad.Operacion item in listaoperaciones)
            {
                LstOperaciones.Items.Add(item);
            }
            LstOperaciones.DisplayMember = "NombreOperacion";
            LstOperaciones.ValueMember = "NombreOperacion";


            //Muestro lista del Perfil de Usuario

            listaoperaciones.Clear(); // limpio lista y la reutilizo

            listaoperaciones = MPU.MostrarListaOperaciones(PerfilBE);
            foreach (BE.Seguridad.Operacion item in listaoperaciones)
            {

                LstPerfilOperaciones.Items.Add(item);
                LstOperaciones.Items.Remove(item);
            }

            LstPerfilOperaciones.DisplayMember = "NombreOperacion";
            LstPerfilOperaciones.ValueMember = "NombreOperacion";
            LstOperaciones.DisplayMember = "NombreOperacion";
            LstOperaciones.ValueMember = "NombreOperacion";


        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                ope = (BE.Seguridad.Operacion)LstOperaciones.SelectedItem;
                
                LstPerfilOperaciones.Items.Add(ope);


                LstOperaciones.Items.Remove(LstOperaciones.SelectedItem);
                LstOperaciones.Refresh();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Seleccione un Elemento!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnDesagregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (LstPerfilOperaciones.SelectedItem.ToString() == "")
                {
                    MessageBox.Show("Seleccione un Elemento!");
                }
                else
                {
                    ope = (BE.Seguridad.Operacion)LstPerfilOperaciones.SelectedItem;

                    LstOperaciones.Items.Add(ope);
                     
                    LstPerfilOperaciones.Items.Remove(LstPerfilOperaciones.SelectedItem);
                    LstPerfilOperaciones.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Seleccione un Elemento!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            List<BE.Seguridad.Operacion> listaoperacionesperfil = new List<BE.Seguridad.Operacion>();
            foreach (BE.Seguridad.Operacion item in LstPerfilOperaciones.Items) {
                listaoperacionesperfil.Add(item);
                                                                                 }

            try
            {
                MPU.AsignarOperacionesalPerfil(PerfilBE, listaoperacionesperfil);

                MessageBox.Show("Operaciones asignadas exitosamente", "Asignacion Correcta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error en la Asignación", MessageBoxButtons.OK, MessageBoxIcon.None);

            }
        }
    }
}
