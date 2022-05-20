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
    public partial class MenuPrincipal : Form
    {

        IList<ServiceLayer.Composite.Component> listaoperaciones = new List<ServiceLayer.Composite.Component>();
        BLL.Idioma.IdiomaBLL idi = new BLL.Idioma.IdiomaBLL();

        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            ServiceLayer.Sesion s = ServiceLayer.Sesion.GetInstance();
            BLL.Permisos.DirectorioperfilBLL pu = new BLL.Permisos.DirectorioperfilBLL("LogIn");
            pu.obtenerhijos(s);
            ServiceLayer.Composite.Composite composite = new ServiceLayer.Composite.Composite("LogIn");
            listaoperaciones = composite.devolerinstanciapermisos();
            
            this.MapeoComponentes(listaoperaciones);



        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogOut logout = new LogOut();
            logout.Show();
        }

        private void aBMUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }


        public void MapeoComponentes(IList<ServiceLayer.Composite.Component> listaoperaciones)
        {


            //Cambio el idioma de los componentes
          //  BLL.IdiomaBLL idi = new BLL.IdiomaBLL();
           // string idioma = idi.CargarIdioma().ToString();

            

            foreach (var i in listaoperaciones) //hacer aca el composite
            {
                string var = i.Nombre.ToString();

                switch (var)
                {
                    //agregar aca las Operaciones del Menu
                    case "hacerbackup":
                        gestiónDeBackUpToolStripMenuItem.Enabled = true;
                        gestiónDeBackUpToolStripMenuItem.Visible = true;
                        break;
                    case "abmusuario":
                        aBMUsuariosToolStripMenuItem.Enabled = true;
                        aBMUsuariosToolStripMenuItem.Visible = true;
                        break;
                    case "abmperfilusuario":
                        aBMFamiliasToolStripMenuItem.Enabled = true;
                        aBMFamiliasToolStripMenuItem.Visible = true;
                        break;
                    case "ConfigurarIdioma":
                        idiomaToolStripMenuItem.Enabled = true;
                        idiomaToolStripMenuItem.Visible = true;
                        configurarIdiomaToolStripMenuItem.Enabled = true;
                        configurarIdiomaToolStripMenuItem.Visible = true;
                        break;
                    case "abmfamilias":
                        aBMFamiliasToolStripMenuItem.Enabled = true;
                        aBMFamiliasToolStripMenuItem.Visible = true;
                        break;
                    case "hacerrestore":
                        realizarStoreToolStripMenuItem.Enabled = true;
                        realizarStoreToolStripMenuItem.Visible = true;
                        break;
                    case "consultarbitacora":
                        logsSistemaToolStripMenuItem.Enabled = true;
                        logsSistemaToolStripMenuItem.Visible = true;
                        consultarBitácoraToolStripMenuItem.Enabled = true;
                        consultarBitácoraToolStripMenuItem.Visible = true;
                        break;
                    case "digitosverificadores":
                        calcularDVToolStripMenuItem.Enabled = true;
                        calcularDVToolStripMenuItem.Visible = true;
                        break;
                    case "Asignacion_de_Patentes":
                        asignacionesRolesToolStripMenuItem.Enabled = true;
                        asignacionesRolesToolStripMenuItem.Visible = true;
                        break;
                    case "BloquearDesbloquearOperacionesaUsuario":
                        bloqueoDesbloqueoUsuariosToolStripMenuItem.Enabled = true;
                        bloqueoDesbloqueoUsuariosToolStripMenuItem.Visible = true;
                        break;
                    case "DesbloquearOperacionAUsuariocs":
                        bloqueoDesbloqueoUsuariosToolStripMenuItem.Enabled = true;
                        bloqueoDesbloqueoUsuariosToolStripMenuItem.Visible = true;
                        break;

                    //menu negocio
                    case "ABMMedios":
                        aBMUbicacionesToolStripMenuItem.Enabled = true;
                        aBMUbicacionesToolStripMenuItem.Visible = true;
                        break;
                    case "ABMUbicacion":
                        aBMUbicacionesToolStripMenuItem.Enabled = true;
                        aBMUbicacionesToolStripMenuItem.Visible = true;
                        break;
                    case "ABMClientes":
                        aBMClientesToolStripMenuItem.Enabled = true;
                        aBMClientesToolStripMenuItem.Visible = true;
                        break;
                    case "CrearNegocio":
                        negocioToolStripMenuItem.Enabled = true;
                        negocioToolStripMenuItem.Visible = true;
                        break;
                    case "ConsultaOperacion":
                        consultarBitácoraToolStripMenuItem.Enabled = true;
                        consultarBitácoraToolStripMenuItem.Visible = true;
                        break;

                    default:

                        break;


                }

            }


           /* string idiom = idi.CargarIdioma().ToString();

            switch (idiom)
            {
                case "Español":

                    crearNegocioToolStripMenuItem.Text = Idioma.Espanol.crearnegocio;
                    aBMClientesToolStripMenuItem.Text = Idioma.Espanol.abmclientes;
                    aBMUbicacionesToolStripMenuItem.Text = Idioma.Espanol.abmubicaciones;
                    aBMMediosToolStripMenuItem.Text = Idioma.Espanol.abmmedios;

                    dígitosVerificadoresToolStripMenuItem.Text = Idioma.Espanol.calculardigitosverificadores.ToString();
                    aBMUsuariosToolStripMenuItem.Text = Idioma.Espanol.abmusuario.ToString();
                    aBMPerfilDeUsuariosToolStripMenuItem.Text = Idioma.Espanol.abmfamilias.ToString();
                    gestionDeRestoreToolStripMenuItem.Text = Idioma.Espanol.hacerrestore.ToString();
                    gestiónDeBackUpToolStripMenuItem.Text = Idioma.Espanol.hacerbackup.ToString();
                    configurarIdiomaToolStripMenuItem.Text = Idioma.Espanol.configuraridioma.ToString();
                    consultarBitácoraToolStripMenuItem.Text = Idioma.Espanol.consultarbitacora.ToString();
                    asignaciónDePatentesToolStripMenuItem.Text = Idioma.Espanol.Asignacion_de_Patentes.ToString();
                    bloqueoDeOperacionesToolStripMenuItem.Text = Idioma.Espanol.BloquearDesbloquearOperacionesaUsuario.ToString();
                    desbloqueoDeOperacionesToolStripMenuItem.Text = Idioma.Espanol.DesbloquearOperacionAUsuariocs.ToString();


                    break;

                case "Ingles":

                    crearNegocioToolStripMenuItem.Text = Idioma.Ingles.crearnegocio;
                    aBMClientesToolStripMenuItem.Text = Idioma.Ingles.abmclientes;
                    aBMUbicacionesToolStripMenuItem.Text = Idioma.Ingles.abmubicaciones;
                    aBMMediosToolStripMenuItem.Text = Idioma.Ingles.abmmedios;

                    dígitosVerificadoresToolStripMenuItem.Text = Idioma.Ingles.calculardigitosverificadores.ToString();
                    aBMUsuariosToolStripMenuItem.Text = Idioma.Ingles.abmusuario.ToString();
                    aBMPerfilDeUsuariosToolStripMenuItem.Text = Idioma.Ingles.abmfamilias.ToString();
                    gestionDeRestoreToolStripMenuItem.Text = Idioma.Ingles.hacerrestore.ToString();
                    gestiónDeBackUpToolStripMenuItem.Text = Idioma.Ingles.hacerbackup.ToString();
                    configurarIdiomaToolStripMenuItem.Text = Idioma.Ingles.configuraridioma.ToString();
                    consultarBitácoraToolStripMenuItem.Text = Idioma.Ingles.consultarbitacora.ToString();
                    asignaciónDePatentesToolStripMenuItem.Text = Idioma.Ingles.Asignacion_de_Patentes.ToString();
                    bloqueoDeOperacionesToolStripMenuItem.Text = Idioma.Ingles.BloquearDesbloquearOperacionesaUsuario.ToString();
                    desbloqueoDeOperacionesToolStripMenuItem.Text = Idioma.Ingles.DesbloquearOperacionAUsuariocs.ToString();

                    break;

                default:
                    break;

            }*/

            
        }

        private void altaUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AUsuario au = new AUsuario();
            au.Show();
        }

        private void modificarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificarUsuarios mu = new ModificarUsuarios();
            mu.Show();
        }

        private void eliminarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EliminarUsuario eu = new EliminarUsuario();
            eu.Show();
        }

        private void altaFamiliaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Permisos.AFamilia af = new Permisos.AFamilia();
            af.Show();
        }

        private void modificarFamiliaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Permisos.ModificarFamilia mf = new Permisos.ModificarFamilia();
            mf.Show();
        }

        private void eliminarFamiliaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Permisos.EliminarFamilia ef = new Permisos.EliminarFamilia();
            ef.Show();
        }

        private void asignarFamiliaAUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Permisos.AsignarFamilia af = new Permisos.AsignarFamilia();
            af.Show();
        }
    }
}
