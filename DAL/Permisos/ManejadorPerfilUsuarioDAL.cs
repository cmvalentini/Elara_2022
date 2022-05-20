using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Seguridad;
using ServiceLayer;
using System.Data;
using BE;

namespace DAL.Permisos
{
    public class ManejadorPerfilUsuarioDAL
    {
        
        BE.Seguridad.PerfilUsuario mpu = new BE.Seguridad.PerfilUsuario();
        Seguridad.DigitosVerificadoresDAL dv = new Seguridad.DigitosVerificadoresDAL();
        Conexion con = new Conexion();

        public List<BE.Seguridad.PerfilUsuario> BuscarPerfilUsuarios()
        {
            DataTable dt = new DataTable();

            string sql = "Select PerfilUsuarioID,NombrePerfil,DescPerfil,DVH from perfilusuario";


            List<BE.Seguridad.PerfilUsuario> listaperfiles = new List<BE.Seguridad.PerfilUsuario>();
           
            con.Conectar();

            con.Ejecutarreader(sql);
            dt = con.Ejecutarreader(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BE.Seguridad.PerfilUsuario mpu = new BE.Seguridad.PerfilUsuario();
                mpu.PerfilUsuarioID = Convert.ToInt16(dt.Rows[i][0].ToString());
                mpu.NombrePerfil = dt.Rows[i][1].ToString();
                mpu.DescPerfil = dt.Rows[i][2].ToString();
                listaperfiles.Add(mpu);
            }

            con.Desconectar();
            return listaperfiles;
            
        }

        public List<Operacion> MostrarListaOperaciones()
        {
            List<BE.Seguridad.Operacion> listaoperaciones = new List<BE.Seguridad.Operacion>();
            DataTable dt = new DataTable();

            string sql = "select Descripcion from OPERACION";

            dt = con.Ejecutarreader(sql);
            
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    BE.Seguridad.Operacion op = new BE.Seguridad.Operacion();
                    op.NombreOperacion = dt.Rows[i]["Descripcion"].ToString();
                    listaoperaciones.Add(op);
                }

            }

            return listaoperaciones;

        }

        public List<Operacion> MostrarListaOperaciones(PerfilUsuario mpu)
        {
            List<BE.Seguridad.Operacion> listaoperaciones1 = new List<BE.Seguridad.Operacion>();
            listaoperaciones1.Clear();
            DataTable dt = new DataTable();

            //si viene parametro NombrePerfil
            if (mpu.PerfilUsuarioID.ToString() == "" && mpu.NombrePerfil != null)
            {
                string sql = " Select op.Descripcion from perfiloperacion po inner join" +
                 " operacion op on op.OperacionID = po.Operacionid " +
                 " where PerfilUsuarioID = (select PerfilUsuarioID from PerfilUsuario" +
                 " where NombrePerfil like '%" + mpu.NombrePerfil + "%');";
                dt = con.Ejecutarreader(sql);
            }
            //si viene parametro PerfilID
            else if (mpu.PerfilUsuarioID.ToString() != "")
            {
                string sql1 = "Select op.Descripcion from perfiloperacion po inner join " +
                " operacion op on op.OperacionID = po.Operacionid " +
                " where PerfilUsuarioID = " + mpu.PerfilUsuarioID;
                dt = con.Ejecutarreader(sql1);
            }


            
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    BE.Seguridad.Operacion op = new BE.Seguridad.Operacion();
                    op.NombreOperacion = dt.Rows[i]["Descripcion"].ToString();
                    listaoperaciones1.Add(op);
                }

            }

            return listaoperaciones1;
        }

        public void AsignarOperacionesalPerfil(PerfilUsuario perfilBE, List<Operacion> listaoperacionesperfil)
        {
            string primersql = "delete perfiloperacion where PerfilUsuarioID = " + mpu.PerfilUsuarioID;
            con.Ejecutar(primersql);
            con.Desconectar();

            con.Conectar();

            string sql;
            foreach (BE.Seguridad.Operacion item in listaoperacionesperfil)
            {

                sql = "INSERT INTO perfiloperacion (OperacionID,PerfilUsuarioID)" +
                      " SELECT OperacionID, " + mpu.PerfilUsuarioID + " " +
                      " FROM OPERACION op" +
                      " WHERE op.Descripcion like '" + item.NombreOperacion.ToString() + "';";

                con.Ejecutar(sql);
                dv.RecalcularDVH();
            }
            con.Desconectar();
        }

        public void AsignarOperacionesalUsuario(Usuario usu, List<Operacion> listaoperacionesperfil)
        {
            //1er sql
            string primersql = " delete usuariooperacion where usuarioid = (select Usuarioid " +
                                " from usuario where Usuario like '" + usu._Usuario + "'); ";
            con.Ejecutar(primersql);
            con.Desconectar();

            con.Conectar();

            string sql;
            foreach (BE.Seguridad.Operacion item in listaoperacionesperfil)
            {
                sql = " INSERT INTO usuariooperacion (UsuarioID,OperacionID,Habilitado)" +
                      " SELECT usu.UsuarioID,op.OperacionID,'S' as Habilitado" +
                      " FROM OPERACION op, Usuario usu" +
                      " WHERE op.Descripcion like '" + item.NombreOperacion.ToString() + "'" +
                      " and usu.Usuario like '" + usu._Usuario.ToString() + "';";

                con.Ejecutar(sql);
            }
            dv.RecalcularDVH();
            con.Desconectar();
        }

        public BE.Seguridad.PerfilUsuario _CrearPerfilUsuario(BE.Seguridad.PerfilUsuario mpu) // string nombrePerfil, string descPerfil
        {
            string sql = "insert into PerfilUsuario(NombrePerfil,DescPerfil,DVH) values('" + mpu.NombrePerfil + "','" + mpu.DescPerfil + "',NULL)";


            mpu.Result = con.Ejecutar(sql);
            dv.RecalcularDVH();
            return mpu;
        }


        public BE.Seguridad.PerfilUsuario VerificarAltafamilia(BE.Seguridad.PerfilUsuario mpu) //nombrePerfil
        {
            string sql = " select case when count(NombrePerfil) <> 0 then 1 else 0  end 'columna'  from PerfilUsuario where NombrePerfil like '" + mpu.NombrePerfil + "'";
            mpu.Result = "0";
            DataTable dt = new DataTable();
            con.Conectar();
            con.Ejecutarreader(sql);
            dt = con.Ejecutarreader(sql);
            con.Desconectar();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                { mpu.Result = dt.Rows[i]["columna"].ToString(); }

            }

            return mpu;
        }

        public PerfilUsuario EliminarPerfilUsuario(PerfilUsuario mpu)
        {

            string sql = "Delete perfilusuario where PerfilUsuarioID = " + mpu.PerfilUsuarioID + ";" +
                       "Delete perfiloperacion where PerfilUsuarioID = " + mpu.PerfilUsuarioID + ";";

            try
            {
                con.Ejecutar(sql);
                //dv.RecalcularDVH();
                con.Desconectar();
                mpu.Result = "True";
                return mpu;
            }
            catch (Exception ex)
            {
                mpu.Result = ex.Message;
                return mpu;
            }


        }

        public PerfilUsuario ModificarPerfilUsuario(PerfilUsuario puBE)
        {
            string sql = "Update perfilusuario set NombrePerfil = '" + mpu.NombrePerfil + "',DescPerfil= '" + mpu.DescPerfil + "'" +
                " where PerfilUsuarioID = " + mpu.PerfilUsuarioID + ";";

            try{
                con.Ejecutar(sql);
                dv.RecalcularDVH();
                mpu.Result = "True";
                return mpu;
            }

            catch (Exception ex){

                mpu.Result = ex.Message;
                dv.RecalcularDVH();
                return mpu;
            }
        }

        public Usuario verificarPatentesEscenciales(Usuario usu)
        {
            try
            {
                            BE.Usuario usuBE = new BE.Usuario();
                            DataTable DT = new DataTable();
                            if (usu._Usuario != "" && usu.UsuarioID.ToString() == "")
                            {

                                string sql = "select Descripcion from operacion where operacionid in" +
                " (select distinct OperacionID from usuariooperacion " +
                " where UsuarioID = (select usuarioid from usuario where Usuario like '" + usu._Usuario + "')" +
                " EXCEPT" +
                " select distinct OperacionID from usuariooperacion " +
                " WHERE OperacionID IN(select distinct OperacionID from usuariooperacion" +
                " where UsuarioID <> (select usuarioid from usuario where Usuario like '" + usu._Usuario + "') " + " ))";
                                DT = con.Ejecutarreader(sql);
                            }
                            else if (usu.UsuarioID.ToString() != "")
                            {

                                string sql = "select Descripcion from operacion where operacionid in" +
                " (select distinct OperacionID from usuariooperacion " +
                " where UsuarioID = " + usu.UsuarioID +
                " EXCEPT" +
                " select distinct OperacionID from usuariooperacion " +
                " WHERE OperacionID IN(select distinct OperacionID from usuariooperacion" +
                " where UsuarioID <>" + usu.UsuarioID + " ))";
                                DT = con.Ejecutarreader(sql);
                            }


                            if (DT.Rows.Count > 0)
                            {
                                foreach (DataRow row in DT.Rows)
                                {

                                    usuBE.Result = usuBE.Result + "--" + row[0].ToString() + "--";
                                }
                                Console.WriteLine(mpu.Result);
                                return usuBE;
                            }
                            else
                            {
                                usuBE.Result = "True";
                                return usuBE;
                            }
            }
            catch (Exception ex)
            {

                usu.Result = ex.Message;
                return usu;
            }
           

        }



       

        public List<Operacion> MostrarMenuperfiles(Sesion s)
        {
            List<BE.Seguridad.Operacion> listaoperaciones = new List<BE.Seguridad.Operacion>();
            

            listaoperaciones = this.traeroperacionesusuario(s);
           
            ServiceLayer.Composite.Composite comp = new ServiceLayer.Composite.Composite("comp");

            comp.ObtenerHijos(listaoperaciones);


            return listaoperaciones;
        }

        internal List<BE.Seguridad.Operacion> traeroperacionesusuario(Sesion s) // Usuarioid
        {
            DataTable dt = new DataTable();

            List<BE.Seguridad.Operacion> listaoperaciones = new List<BE.Seguridad.Operacion>();
            
            string sql = "select o.Descripcion " +
                " from usuariooperacion uo INNER JOIN OPERACION o ON O.OperacionID = UO.OperacionID " +
                 " where uo.UsuarioID = " + s.UsuarioID + " and uo.Habilitado = 'S' ";

            con.Conectar();

            con.Ejecutarreader(sql);
            dt = con.Ejecutarreader(sql);
          
            if (dt.Rows.Count > 0)
            {
                Console.WriteLine("entró reader MPUDAL" + Convert.ToString(dt.Rows[0][0].ToString()));
               
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    BE.Seguridad.Operacion op = new BE.Seguridad.Operacion();
                    op.NombreOperacion = dt.Rows[i]["Descripcion"].ToString();
                    listaoperaciones.Add(op);
                }

            }


            con.Desconectar();

            return listaoperaciones;
        }


        public BE.Seguridad.PerfilUsuario verificarPatentesBloqueo(BE.Usuario usu, BE.Seguridad.Operacion patente)
        {


            string sql = "select Descripcion from operacion where operacionid in " +
" (select distinct OperacionID from usuariooperacion " +
" where UsuarioID = (select usuarioid from usuario where Usuario like '%" + usu._Usuario + "%')" +
" EXCEPT" +
" select distinct OperacionID from usuariooperacion " +
" WHERE OperacionID IN(select distinct OperacionID from usuariooperacion" +
" where UsuarioID <> (select usuarioid from usuario where Usuario like '%" + usu._Usuario + "%') " + " ))" +
" and Descripcion like '" + patente.NombreOperacion + "'";

            DataTable DT = con.Ejecutarreader(sql);


            if (DT.Rows.Count > 0)
            {
                mpu.Result = DT.Rows[0][0].ToString();
                return mpu;
            }
            else
            {
                mpu.Result = "True";
                return mpu;
            }


        }
    }
}
