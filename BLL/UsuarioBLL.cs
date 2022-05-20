using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class UsuarioBLL
    {
        BE.Usuario usuarioBE = new BE.Usuario();
        public UsuarioBLL() { }

        public void TraerDatosUsuario(BE.Usuario usuBE) // nombreusuario,  clave
        {
            DAL.UsuarioDAL usu = new DAL.UsuarioDAL();
            usu.TraerDatosUsuario(usuBE); //nombreusuario, clave

        }

        public BE.Usuario BuscarUsuario(BE.Usuario usube)
        {
            DAL.UsuarioDAL dalusu = new DAL.UsuarioDAL();
            usube = dalusu.BuscarUsuario(usube);

            return usube; 
        }

        public BE.Usuario BuscarUsuario(BE.Usuario usube,string clave)
        {
            DAL.UsuarioDAL dalusu = new DAL.UsuarioDAL();
            usube = dalusu.BuscarUsuario(usube, clave);

            return usube;
        }

        public void EnviarMail(BE.Usuario usu, string claveencriptada, string clavesinencriptar) //usuarioid,claveencrp,clave
        {
            DAL.UsuarioDAL usu2 = new DAL.UsuarioDAL();
            usu2.EnviarMail(usu, claveencriptada, clavesinencriptar);


        }

        public void SumarFlagIntentos(BE.Usuario usube) //usuID
        {
            DAL.UsuarioDAL USU = new DAL.UsuarioDAL();
            USU.SumarFlagIntentos(usube.UsuarioID);

        }

        public void BlanquearIntentos(BE.Usuario usube) //usuarioID
        {
            DAL.UsuarioDAL usu = new DAL.UsuarioDAL();
            usu.Blanquearintentos(usube);
        }

        public BE.Usuario TraerDatosUsuariobyID(BE.Usuario usube) //usuid
        {
            DAL.UsuarioDAL usu = new DAL.UsuarioDAL();

            usuarioBE = usu.TraerDatosUsuariobyID(usube);


            return usuarioBE;

        }

        public int verificarDuplicidad(BE.Usuario usuBE, int usuarioid) //dni,email,usuario,usuarioid
        {
            int result = 0;
            DAL.UsuarioDAL usu = new DAL.UsuarioDAL();

            result = usu.verificarDuplicidad(usuBE, usuarioid); //dni, email,usuario,usuarioid

            return result;

        }



        public int verificarDuplicidad(BE.Usuario usuBE) // dni,  email, usuario
        {
            int result = 0;
            DAL.UsuarioDAL usu = new DAL.UsuarioDAL();

            result = usu.verificarDuplicidad(usuBE); //dni, email, usuario

            return result;

        }

    
        public List<BE.Seguridad.Operacion> MostraroperacionUsuario(BE.Usuario usuBE) //nombreUsuario
        {
            List<BE.Seguridad.Operacion> listaoperaciones = new List<BE.Seguridad.Operacion>();
            DAL.Permisos.OperacionDAL opDAL = new DAL.Permisos.OperacionDAL();

            listaoperaciones = opDAL.MostraroperacionUsuario(usuBE);

            return listaoperaciones;
        }





        public void Dar_Alta_Usuario(BE.Usuario usube)
        //(string _Usuario, string apellido, string nombre, string email, int dni, bool habilitado, string clave, string clavesinencriptar)
        {
            DAL.UsuarioDAL usu1 = new DAL.UsuarioDAL();
            usu1.Dar_Alta_Usuario(usube);

        }


        public BE.Usuario verificarPatentesBloqueo(BE.Usuario usube, BE.Seguridad.Operacion opbe)
        {
            DAL.Permisos.ManejadorPerfilUsuarioDAL MPU = new DAL.Permisos.ManejadorPerfilUsuarioDAL();
            usube.Result = MPU.verificarPatentesBloqueo(usube, opbe).ToString();

            return usube;
        }



        public BE.Usuario BuscarUsuariopornombre(BE.Usuario usube) //NombreUsuario
        {

            DAL.UsuarioDAL usu = new DAL.UsuarioDAL();
            usuarioBE = usu.BuscarUsuario(usube);
            return usuarioBE;
        }




        public BE.Usuario ModificarDatosUsuario(BE.Usuario usube)
        //(string _Usuario, string apellido, string nombre, string email, Int64 dni, bool habilitado,int usuarioid)
        {
            DAL.UsuarioDAL usu = new DAL.UsuarioDAL();
            
            usube = usu.ModificarDatosUsuario(usube);


            return usube;

        }

        public BE.Usuario EliminarUsuario(BE.Usuario usube) //idusuario
        {
            DAL.UsuarioDAL usu = new DAL.UsuarioDAL();
            usube = usu.EliminarUsuario(usube);

            return usube;
        }


        public BE.Usuario CambiarClave(BE.Usuario usube, string ClaveNueva) //Usuario, ClaveNueva,Usuarioid
        {
            DAL.UsuarioDAL usu = new DAL.UsuarioDAL();
            usube.Clave = ClaveNueva;

            usube = usu.CambiarClave(usube);

            return usube;
        }

        
        public List<BE.Usuario> MostrarUsuarios()
        {
            List<BE.Usuario> listausuarios = new List<BE.Usuario>();

            DAL.UsuarioDAL USU = new DAL.UsuarioDAL();

            listausuarios = USU.MostrarUsuarios();


            return listausuarios;
        }




    }///---- fin clase
    

}

