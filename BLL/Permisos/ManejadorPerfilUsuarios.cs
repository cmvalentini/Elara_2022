using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BE.Seguridad;
using ServiceLayer;

namespace BLL.Permisos
{
    public class ManejadorPerfilUsuarios
    {
        DAL.Permisos.ManejadorPerfilUsuarioDAL mpudal = new DAL.Permisos.ManejadorPerfilUsuarioDAL();
        BE.Seguridad.PerfilUsuario mpuBE = new PerfilUsuario();
        List<Operacion> listaoperaciones = new List<Operacion>();
        public BE.Seguridad.PerfilUsuario _CrearPerfilUsuario(BE.Seguridad.PerfilUsuario perfil) //string NombrePerfil,string DescPerfil
        {
            
           
            mpuBE = mpudal._CrearPerfilUsuario(perfil);


            return mpuBE;
        }


        public List<PerfilUsuario> BuscarPerfilUsuarios()
        {
            List<PerfilUsuario> lpu = new List<PerfilUsuario>();
            lpu = mpudal.BuscarPerfilUsuarios();
            return lpu;
        }

       

        public List<Operacion> MostrarListaOperaciones()
        {
            listaoperaciones = mpudal.MostrarListaOperaciones();
            return listaoperaciones;
        }

        public List<Operacion> MostrarListaOperaciones(PerfilUsuario mpu) //perfilID
        {
            listaoperaciones.Clear();
            listaoperaciones = mpudal.MostrarListaOperaciones(mpu);
            return listaoperaciones;
        }

        internal List<Operacion> MostrarMenuPerfiles(Sesion s)
        {
            List<BE.Seguridad.Operacion> listaoperaciones = new List<BE.Seguridad.Operacion>();
            listaoperaciones = mpudal.MostrarMenuperfiles(s);

            return listaoperaciones;
        }

        public BE.Seguridad.PerfilUsuario VerificarAltafamilia(BE.Seguridad.PerfilUsuario mpu) //nombrePerfil
        {
             mpu = mpudal.VerificarAltafamilia(mpu);
            return mpu;
        }

        public PerfilUsuario ModificarPerfilUsuario(PerfilUsuario puBE)
        {
            puBE.Result = "False";
            try{
                puBE = mpudal.ModificarPerfilUsuario(puBE);
                return puBE;
                }
            catch (Exception ex)
            {
                puBE.Result = ex.Message;
                return puBE;
            }
        }

        public PerfilUsuario EliminarPerfilUsuario(PerfilUsuario mpu)
        {
            mpu.Result = "False";
            try{
                mpu = mpudal.EliminarPerfilUsuario(mpu);
               }
            catch (Exception EX)
            {
                mpu.Result = EX.Message;
                return mpu;
            }
            return mpu;
        }

       
        public void AsignarOperacionesalUsuario(BE.Usuario usu, List<Operacion> listaoperacionesperfil) //NombreUsuario listaoperacionesperfil
        {
            mpudal.AsignarOperacionesalUsuario(usu, listaoperacionesperfil);
        }


        public void AsignarOperacionesalPerfil(PerfilUsuario perfilBE, List<Operacion> listaoperacionesperfil){
          mpudal.AsignarOperacionesalPerfil(perfilBE, listaoperacionesperfil);
        }

        public PerfilUsuario AsignarUsuarioaPerfil(PerfilUsuario pUbe, Usuario usuBe){
            pUbe = mpudal.AsignarUsuarioaPerfil(pUbe, usuBe);
            return pUbe;
        }

        public void AsignarOperacionesaUsuario(Usuario usuBe, List<Operacion> listaoperacioneUsuario){
            mpudal.AsignarOperacionesaUsuario(usuBe, listaoperacioneUsuario);
        }

    }//fin
}
