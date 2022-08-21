using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diploma_2022
{
    public partial class LogOut : Form
    {

        ServiceLayer.Sesion usu = ServiceLayer.Sesion.GetInstance();
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        BLL.Seguridad.BitacoraBLL log = new BLL.Seguridad.BitacoraBLL();
        BE.Seguridad.BitacoraBE logbe = new BE.Seguridad.BitacoraBE();

        public LogOut()
        {
            InitializeComponent();
        }

        private void lblConfirm_Click(object sender, EventArgs e)
        {

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            logbe.NombreOperacion = cryp.Encriptar("LogOut").ToString();
            logbe.Descripcion = cryp.Encriptar("LogOut Usuario " + usu.UsuarioID + " ").ToString();
            logbe.Criticidad = 4;
            logbe.Usuarioid = usu.UsuarioID;
            string rta = log.IngresarDatoBitacora(logbe.NombreOperacion, logbe.Descripcion, logbe.Criticidad, logbe.Usuarioid).ToString();



            Environment.Exit(1);
        }
    }
}
