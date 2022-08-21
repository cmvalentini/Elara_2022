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
    public partial class AsignarOperacionesaUsuario : Form
    {

        BLL.Seguridad.BitacoraBLL log = new BLL.Seguridad.BitacoraBLL();
        BLL.Permisos.ManejadorPerfilUsuarios MPU = new BLL.Permisos.ManejadorPerfilUsuarios();
        List<BE.Seguridad.Operacion> listaoperaciones = new List<BE.Seguridad.Operacion>();
        BLL.UsuarioBLL usu = new BLL.UsuarioBLL();
        ServiceLayer.Sesion sesion = ServiceLayer.Sesion.GetInstance();
        BE.Usuario UsuBe = new BE.Usuario();
        BE.Seguridad.PerfilUsuario PU = new BE.Seguridad.PerfilUsuario();
        BE.Seguridad.Operacion ope = new BE.Seguridad.Operacion();


        public AsignarOperacionesaUsuario(BE.Usuario usube)
        {
            UsuBe = usube;
            InitializeComponent();
        }

        private void AsignarOperacionesaUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                 
                 lblNombreUsuario.Text = UsuBe._Usuario;
                PU = usu.traerDatosPerfil(UsuBe);

                if (PU == null){
                    lblNombrePerfil.Text = "Sin Perfil Asignado";
                }
                else{
                    lblNombrePerfil.Text = PU.NombrePerfil.ToString() ;
                }
               

                 // lista de operaciones cargo
                 listaoperaciones = MPU.MostrarListaOperaciones();
                 foreach (BE.Seguridad.Operacion item in listaoperaciones)
                 {
                     LstOperaciones.Items.Add(item);
                 }
                 LstOperaciones.DisplayMember = "NombreOperacion";
                 LstOperaciones.ValueMember = "NombreOperacion";


                 //Muestro lista del Perfil del Usuario

                 listaoperaciones.Clear(); // limpio lista y la reutilizo

                 listaoperaciones = usu.MostraroperacionUsuario(UsuBe);
                 foreach (BE.Seguridad.Operacion item in listaoperaciones)
                 {
                     LstUsuarioOperaciones.Items.Add(item);
                     LstOperaciones.Items.Remove(item);
                 }
                 LstUsuarioOperaciones.DisplayMember = "NombreOperacion";
                 LstUsuarioOperaciones.ValueMember = "NombreOperacion";

                //carga de los perfiles

                List<BE.Seguridad.PerfilUsuario> listaperfiles = new List<BE.Seguridad.PerfilUsuario>();
                listaperfiles = MPU.BuscarPerfilUsuarios();

                 foreach (BE.Seguridad.PerfilUsuario item in listaperfiles)
                 {
                     cmbPerfiles.Items.Add(item.NombrePerfil.ToString());
                 }


                 
            }
            catch (Exception ex){

                 MessageBox.Show(ex.Message);
                 }
           
            }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAsignarPerfil_Click(object sender, EventArgs e)
        {

            if ((MessageBox.Show("¿Esta seguro que desea asignarle el Perfil a " + UsuBe._Usuario.ToString() + "?", "Asignar Perfil Usuario",
MessageBoxButtons.YesNo, MessageBoxIcon.Question,
MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
            {
                try
                {
                    if (cmbPerfiles.Text == "")
                    {
                        MessageBox.Show("Asigne el Perfil de Usuario!");
                    }
                    else
                    {
                        BE.Seguridad.PerfilUsuario PUbe = new BE.Seguridad.PerfilUsuario();
                        PUbe.NombrePerfil = cmbPerfiles.Text;
                        //asignamos la familia al usuario
                        PUbe = MPU.AsignarUsuarioaPerfil(PUbe, UsuBe);

                        //cargamos la familia en los listbox 
                        //para despues grabarla con sus permisos
                        this.reasignaroperaciones(PUbe);

                    }

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());

                }

            }
        }

        private void reasignaroperaciones(BE.Seguridad.PerfilUsuario perfil)
        {
            try
            {
                //limpio todo
                LstOperaciones.Items.Clear();
                LstUsuarioOperaciones.Items.Clear();

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

                listaoperaciones = MPU.MostrarListaOperaciones(perfil);
                foreach (BE.Seguridad.Operacion item in listaoperaciones)
                {
                    LstUsuarioOperaciones.Items.Add(item);
                     
                    LstOperaciones.Items.Remove(item);
                }
                LstUsuarioOperaciones.DisplayMember = "NombreOperacion";
                LstUsuarioOperaciones.ValueMember = "NombreOperacion";


                ////////////////
                ope = (BE.Seguridad.Operacion)LstOperaciones.SelectedItem;
                LstUsuarioOperaciones.Items.Add(ope);


                LstOperaciones.Items.Remove(LstOperaciones.SelectedItem);
                LstOperaciones.Refresh();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           

          

        }

        private void BtnAgregar_Click(object sender, EventArgs e){
            try{

                ope = (BE.Seguridad.Operacion)LstOperaciones.SelectedItem;
                LstUsuarioOperaciones.Items.Add(ope);


                LstOperaciones.Items.Remove(LstOperaciones.SelectedItem);
                LstOperaciones.Refresh();
            }
            catch (Exception ex){

                MessageBox.Show(ex.Message, "Seleccione un Elemento!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnDesagregar_Click(object sender, EventArgs e)
        {
            try{
                if (LstUsuarioOperaciones.SelectedItem.ToString() == ""){
                    MessageBox.Show("Seleccione un Elemento!");
                }
                else{
                    ope = (BE.Seguridad.Operacion)LstUsuarioOperaciones.SelectedItem;
                    LstOperaciones.Items.Add(ope);

                    LstUsuarioOperaciones.Items.Remove(LstUsuarioOperaciones.SelectedItem);
                    LstUsuarioOperaciones.Refresh();
                }
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message, "Seleccione un Elemento!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            List<BE.Seguridad.Operacion> listaoperacioneUsuario = new List<BE.Seguridad.Operacion>();
            foreach (BE.Seguridad.Operacion item in LstUsuarioOperaciones.Items)
            {
                listaoperacioneUsuario.Add(item);
            }

            List<BE.Seguridad.Operacion> listaoperacionessistema = new List<BE.Seguridad.Operacion>();
            foreach (BE.Seguridad.Operacion item in LstOperaciones.Items)
            {
                listaoperacionessistema.Add(item);
            }



          
            try
            {
                if (Convert.ToInt16(listaoperacionessistema.Count().ToString()) == 0)
                {
                    //todas las patentes asignadas
                  
                    UsuBe.Result = "true";
                    
                }
                else
                {
                    BLL.Permisos.OperacionBLL opBLL = new BLL.Permisos.OperacionBLL();
                    UsuBe = opBLL.verificarPatentesEscenciales(listaoperacionessistema, UsuBe);
                }

                if (UsuBe.Result == "True")
                {
                    //si es true, lo puede reasignar
                    MPU.AsignarOperacionesaUsuario(UsuBe, listaoperacioneUsuario); //nombre usuario , listaoperaciones
                    MessageBox.Show("Operaciones asignadas exitosamente", "Asignacion Correcta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    log.IngresarDatoBitacora("Asignacion de Patentes", "Asignacion de patentes", 3, sesion.UsuarioID);

                }
                else
                {
                    MessageBox.Show("Usuario con Patentes Unicas, Reasigne las patentes", "Asignacion Incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                

            }

            catch (Exception ex){

                MessageBox.Show(ex.Message, "Error en la Asignación", MessageBoxButtons.OK, MessageBoxIcon.None);

            }


        }


    }//fin
}
