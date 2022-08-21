using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BE;
using BE.Seguridad;

namespace DAL
{
 public class UsuarioDAL
    {
        Conexion con = new Conexion();
        // DigitosVerificadores dv = new DigitosVerificadores();
        BE.Usuario UsuarioBE = new BE.Usuario();
        DataTable dt = new DataTable();
        Seguridad.DigitosVerificadoresDAL dv = new Seguridad.DigitosVerificadoresDAL();

        public void TraerDatosUsuario(BE.Usuario UsuBE)
        {
         
            string sql = "select UsuarioID,Usuario,Clave,Nombre,Apellido,DNI,Email,Habilitado,FlagIntentosLogin From Usuario " +
                          " where usuario = '" + UsuBE._Usuario + "'" +
                          " and clave = '" + UsuBE.Clave + "' " +
                          " and Habilitado = 1";
            try
            {
                
                dt = con.Ejecutarreader(sql);



                if (dt.Rows.Count > 0)
                {
                    Console.WriteLine("entró reader " + Convert.ToString(dt.Rows[0][0].ToString()));

                    UsuBE.UsuarioID = Convert.ToInt32(dt.Rows[0][0].ToString());
                    UsuBE._Usuario = Convert.ToString(dt.Rows[0][1].ToString());
                    UsuBE.Apellido = Convert.ToString(dt.Rows[0][4].ToString());
                    UsuBE.Nombre = Convert.ToString(dt.Rows[0][3].ToString());
                    UsuBE.Email = Convert.ToString(dt.Rows[0][6].ToString());
                    UsuBE.Dni = Convert.ToInt32(dt.Rows[0][5].ToString());
                    UsuBE.Habilitado = Convert.ToBoolean(dt.Rows[0][7].ToString());
                    UsuBE.FlagIntentosLogin = Convert.ToInt32(dt.Rows[0][8].ToString());

                }
                else
                {


                }

                ServiceLayer.Sesion ss = ServiceLayer.Sesion.GetInstance();
                ss.UsuarioID = UsuBE.UsuarioID;
                ss.nombreusuario = UsuBE._Usuario;
                ss.FlagIntentosLogin = UsuBE.FlagIntentosLogin;

            }
            catch (Exception EX)
            {

                Console.WriteLine(EX.Message);
            }



        }

        public List<Usuario> traerUsuarios()
        {
           
            List<BE.Usuario> listausuario = new List<BE.Usuario>();
            DataTable datausuario = new DataTable();
            string sql = "select distinct usuario from usuario";
            datausuario = con.Ejecutarreader(sql);

            if (datausuario.Rows.Count > 0)
            {

                foreach (DataRow item in datausuario.Rows)
                {
                    BE.Usuario USUBE = new BE.Usuario();
                    USUBE._Usuario = item[0].ToString();
                    listausuario.Add(USUBE);
                }

                Console.WriteLine("entró reader DAL.BITACORA" + Convert.ToString(datausuario.Rows[0][0].ToString()));

            }

            return listausuario;
        }

        public PerfilUsuario traerDatosPerfil(Usuario nombreUsuario)
        {
            try{
                string sql = "select p.NombrePerfil from perfilusuario p " +
" inner join UsuarioFamilia uf on uf.PerfilID = p.PerfilUsuarioID " +
" inner join Usuario u on u.UsuarioID = uf.UsuarioID " +
" where u.Usuario like '%" + nombreUsuario._Usuario + "%'";

                dt = con.Ejecutarreader(sql);

                if (dt.Rows.Count > 0){
                    foreach (DataRow item in dt.Rows)
                    {
                        BE.Seguridad.PerfilUsuario PE = new PerfilUsuario();
                        PE.NombrePerfil = item[0].ToString();
                        UsuarioBE.PerfilUsuario = PE;
                    }
                }


                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return UsuarioBE.PerfilUsuario;

        }

        public List<BE.Usuario> MostrarUsuarios()
        {
            

           
            string sql = "select UsuarioID, Usuario, Clave, Nombre, Apellido, DNI," +
                " Email, Habilitado, FlagIntentosLogin from Usuario ";

            dt = con.Ejecutarreader(sql);
            List<BE.Usuario> listausuarios = new List<BE.Usuario>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                     
                    BE.Usuario BEUsu = new BE.Usuario();
                    BEUsu.UsuarioID = Convert.ToInt32(item[0].ToString());
                    BEUsu._Usuario = Convert.ToString(item[1].ToString());
                    BEUsu.Apellido = Convert.ToString(item[4].ToString());
                    BEUsu.Nombre = Convert.ToString(item[3].ToString());
                    BEUsu.Email = Convert.ToString(item[6].ToString());
                    BEUsu.Dni = Convert.ToInt32(item[5].ToString());
                    BEUsu.Habilitado = Convert.ToBoolean(item[7].ToString());
                    BEUsu.FlagIntentosLogin = Convert.ToInt32(item[8].ToString());

                    listausuarios.Add(BEUsu);

                }
            }
            
            return listausuarios;

        }

        public void Blanquearintentos(BE.Usuario usube)
        {
            string sql = "update usuario set  FlagIntentosLogin = 0 where UsuarioID = " + usube.UsuarioID;

            DataTable dt = new DataTable();
            dt = con.Ejecutarreader(sql);

            dv.RecalcularDVH();
        }

        public BE.Usuario CambiarClave(BE.Usuario usu) // usu, claveNueva, Usuarioid
        {
            string sql = "Update Usuario set Clave = '" + usu.Clave + "' " +
                 " where Usuario = '" + usu._Usuario + "'" +
                 " and Usuarioid = " + usu.UsuarioID + "";

            usu.Result = con.Ejecutar(sql);
            dv.RecalcularDVH();
            return usu;

        }

        public void SumarFlagIntentos(int usuID)
        {
            string sp = "SumarFlagIntentos";
            con.EjecutarProcedure(sp, usuID);
        }

        public int verificarDuplicidad(BE.Usuario UsuBE, int usuarioid) //dni, email,usuario,usuarioid
        {

            string sql = " DECLARE @Dni int = (select count(dni) from usuario where dni = " + UsuBE.Dni + " and UsuarioID not in (" + usuarioid + ")) " +
             "  DECLARE @Email varchar(50) = (select count(Email) from Usuario where Email like '" + UsuBE.Email + "' and UsuarioID not in (" + usuarioid + ")) " +
             " DECLARE @Usuario varchar(50) = (select count(Usuario) from Usuario where Usuario like '" + UsuBE._Usuario + "' and UsuarioID not in (" + usuarioid + ")) " +
             " declare @result int = 4;" +
           " set @result = (select CASE when @Email = 1 then 2 ELSE @result END )" +
           "   set @result = (select CASE when @Dni = 1 then  1 ELSE @result END )" +
           "	  set @result = (select CASE when @Usuario = 1 then 5 ELSE @result end) " +
           "   set @result = (select CASE when @Dni = 1 AND @Email = 1 then 3 ELSE @result end) " +
           "  select @result;";

            int result;
            DataTable dt = new DataTable();
            dt = con.Ejecutarreader(sql);

            if (dt.Rows.Count > 0)
            {
                Console.WriteLine("entró reader " + Convert.ToString(dt.Rows[0][0].ToString()));
                result = Convert.ToInt16(dt.Rows[0][0].ToString());

                return result;
            }
            else
            {
                result = 5;
                return result;
            }

        }


        public int verificarDuplicidad(BE.Usuario UsuBE) // dni, email, usuario
        {
            try
            {
                int result;
                string sql = " DECLARE @Dni int = (select count(dni) from usuario where dni = " + UsuBE.Dni + ")" +
                 "  DECLARE @Email varchar(50) = (select count(Email) from Usuario where Email like '" + UsuBE.Email + "') " +
                 " DECLARE @Usuario varchar(50) = (select count(Usuario) from Usuario where Usuario like '" + UsuBE._Usuario + "') " +
                 " declare @result int = 4;" +
               " set @result = (select CASE when @Email <> 1 then 2 ELSE @result END )" +
               "   set @result = (select CASE when @Dni <> 1 then  1 ELSE @result END )" +
               "	  set @result = (select CASE when @Usuario <> 1 then 5 ELSE @result end) " +
               "   set @result = (select CASE when @Dni <> 1 AND @Email <> 1 then 3 ELSE @result end) " +
               "  select @result;";


                DataTable dt = new DataTable();
                dt = con.Ejecutarreader(sql);

                if (dt.Rows.Count > 0)
                {
                    Console.WriteLine("entró reader " + Convert.ToString(dt.Rows[0][0].ToString()));
                    result = Convert.ToInt16(dt.Rows[0][0].ToString());
                    return result;
                }
                else
                {
                    result = 5;
                    return result;
                }



            }
            catch (Exception EX)
            {
                UsuBE.Result = EX.Message.ToString();
                Console.WriteLine("func verificarDuplicidad: " + EX.Message);
                return 500;
            }

        }

        public void Dar_Alta_Usuario(BE.Usuario UsuBE) //_Usuario, apellido, nombre, email, dni, habilitado, clave,clavesinencriptar
        {


            string sql = "insert into Usuario values( '" + UsuBE._Usuario + "',"
               + "'" + UsuBE.Clave + "','" + UsuBE.Nombre + "','" + UsuBE.Apellido + "'," + UsuBE.Dni + ",'" + UsuBE.Email + "','" + UsuBE.Habilitado + "',0," + "'_DVH')";

            string result = con.Ejecutar(sql);
            dv.RecalcularDVH();

            EmailSevice.EmailServiceDAL mail = new EmailSevice.EmailServiceDAL();
            mail.EnviarEmail(UsuBE.Email,UsuBE);

        }

        public BE.Usuario TraerDatosUsuariobyID(BE.Usuario usube) //usuid
        {

            string sql = "select UsuarioID,Usuario,Clave,Nombre,Apellido,DNI,Email,Habilitado,FlagIntentosLogin From Usuario " +
                          "where usuarioid = " + usube.UsuarioID + "";
            try
            {
                DataTable dt = new DataTable();
                dt = con.Ejecutarreader(sql);

                if (dt.Rows.Count > 0)
                {
                    Console.WriteLine("entró reader UsuarioDal" + Convert.ToString(dt.Rows[0][0].ToString()));

                    UsuarioBE.UsuarioID = Convert.ToInt32(dt.Rows[0][0].ToString());
                    UsuarioBE._Usuario = Convert.ToString(dt.Rows[0][1].ToString());
                    UsuarioBE.Apellido = Convert.ToString(dt.Rows[0][4].ToString());
                    UsuarioBE.Nombre = Convert.ToString(dt.Rows[0][3].ToString());
                    UsuarioBE.Email = Convert.ToString(dt.Rows[0][6].ToString());
                    UsuarioBE.Dni = Convert.ToInt32(dt.Rows[0][5].ToString());
                    UsuarioBE.Habilitado = Convert.ToBoolean(dt.Rows[0][7].ToString());
                    UsuarioBE.FlagIntentosLogin = Convert.ToInt32(dt.Rows[0][8].ToString());

                }
           
                return UsuarioBE;

            }
            catch (Exception ex){

                UsuarioBE.Result = ex.Message;
                return UsuarioBE;
            }



        }


        public void EnviarMail(BE.Usuario UsuBE, string claveencriptada, string clavesinencriptar){

            string email = "";
            string sql = " select Email from usuario " +
                         " where UsuarioID = " + UsuBE.UsuarioID.ToString() ;

            dt = con.Ejecutarreader(sql);

            if (dt.Rows.Count > 0){
                foreach (DataRow item in dt.Rows)
                {
                    email = item[0].ToString();
                }
            }

            string sql1 = "Update Usuario set Clave = '" + claveencriptada.ToString() + "' " +
                " where Usuarioid = " + UsuBE.UsuarioID.ToString() + "";


            string rta = con.Ejecutar(sql1);
            dv.RecalcularDVH();

            EmailSevice.EmailServiceDAL es = new EmailSevice.EmailServiceDAL();

            UsuBE.clavesinencriptar = clavesinencriptar;
            es.EnviarEmail(email, UsuBE);





        }

        public Usuario BuscarUsuario(Usuario usube)
        {
            string sql = "select UsuarioID,Usuario,Clave,Nombre,Apellido,DNI,Email,Habilitado,FlagIntentosLogin from Usuario where Usuario = '" + usube._Usuario + "'";

            try{

                dt = con.Ejecutarreader(sql);
                
                if (dt.Rows.Count > 0)
                {
                    Console.WriteLine("entró reader " + Convert.ToString(dt.Rows[0][0].ToString()));

                    UsuarioBE.UsuarioID = Convert.ToInt32(dt.Rows[0][0].ToString());
                    UsuarioBE._Usuario = Convert.ToString(dt.Rows[0][1].ToString());
                    UsuarioBE.Apellido = Convert.ToString(dt.Rows[0][4].ToString());
                    UsuarioBE.Nombre = Convert.ToString(dt.Rows[0][3].ToString());
                    UsuarioBE.Email = Convert.ToString(dt.Rows[0][6].ToString());
                    UsuarioBE.Dni = Convert.ToInt32(dt.Rows[0][5].ToString());
                    UsuarioBE.Habilitado = Convert.ToBoolean(dt.Rows[0][7].ToString());
                    UsuarioBE.FlagIntentosLogin = Convert.ToInt32(dt.Rows[0][8].ToString());

                }
        


                return UsuarioBE;

            }
            catch (Exception ex)
            {

                UsuarioBE.Result = ex.Message;
                return UsuarioBE;
            }



        }

        public Usuario BuscarUsuario(Usuario usube,string Clave)
        {
            string sql = "select UsuarioID,Usuario,Clave,Nombre,Apellido,DNI,Email,Habilitado,FlagIntentosLogin from Usuario where Usuario = '" + usube._Usuario + "'" +
                "and Clave = '"+ Clave + "' ";

            try
            {

                dt = con.Ejecutarreader(sql);

                if (dt.Rows.Count > 0)
                {
                    Console.WriteLine("entró reader " + Convert.ToString(dt.Rows[0][0].ToString()));

                    UsuarioBE.UsuarioID = Convert.ToInt32(dt.Rows[0][0].ToString());
                    UsuarioBE._Usuario = Convert.ToString(dt.Rows[0][1].ToString());
                    UsuarioBE.Apellido = Convert.ToString(dt.Rows[0][4].ToString());
                    UsuarioBE.Nombre = Convert.ToString(dt.Rows[0][3].ToString());
                    UsuarioBE.Email = Convert.ToString(dt.Rows[0][6].ToString());
                    UsuarioBE.Dni = Convert.ToInt32(dt.Rows[0][5].ToString());
                    UsuarioBE.Habilitado = Convert.ToBoolean(dt.Rows[0][7].ToString());
                    UsuarioBE.FlagIntentosLogin = Convert.ToInt32(dt.Rows[0][8].ToString());

                }
                
                return UsuarioBE;

            }
            catch (Exception ex)
            {

                UsuarioBE.Result = ex.Message;
                return UsuarioBE;
            }



        }


        public BE.Usuario ModificarDatosUsuario(BE.Usuario UsuBE) // _Usuario, apellido, nombre, email, dni, habilitado usuarioid
        {

            int h;
            if (UsuBE.Habilitado.ToString() == "True")
            {
                h = 1;
            }
            else
            {
                h = 0;
            }
            string sql = "update Usuario set Usuario = '" + UsuBE._Usuario + "',apellido = '" + UsuBE.Apellido + "',nombre='" + UsuBE.Nombre + "',DNI=" + UsuBE.Dni + ",email='" + UsuBE.Email + "',Habilitado=" + h + " "
            + "where Usuarioid = " + UsuBE.UsuarioID + ";";

            UsuBE.Result = con.Ejecutar(sql);

            dv.RecalcularDVH();
            return UsuBE;

        }

        public BE.Usuario EliminarUsuario(BE.Usuario UsuBE) //usuarioid
        {
            string sql = " Delete UsuarioOperacion where Usuarioid =" + UsuBE.UsuarioID + " " +
                         " Delete usuariofamilia where Usuarioid =" + UsuBE.UsuarioID + " " +
                         " Delete usuario where usuarioid = " + UsuBE.UsuarioID + ";";

            UsuBE.Result = con.Ejecutar(sql);

            dv.RecalcularDVH();
            return UsuBE;
        }




    }
}
