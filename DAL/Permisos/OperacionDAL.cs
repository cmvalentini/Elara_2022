using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BE.Seguridad;

namespace DAL.Permisos
{
    public class OperacionDAL
    {
        Conexion con = new Conexion();
        public OperacionDAL() { }

        public List<BE.Seguridad.Operacion> MostraroperacionUsuario(BE.Usuario usube)
        {
            List<BE.Seguridad.Operacion> listaoperaciones1 = new List<BE.Seguridad.Operacion>();
            listaoperaciones1.Clear();
            DataTable dt = new DataTable();

            string sql = "Select op.Descripcion from usuariooperacion uo inner join " +
                       " operacion op on op.OperacionID = uo.Operacionid " +
                       " where uo.UsuarioID = (select UsuarioID from Usuario where" +
                       " Usuario like '" + usube._Usuario + "');";
          
            dt = con.Ejecutarreader(sql);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    BE.Seguridad.Operacion OpBE = new BE.Seguridad.Operacion();
                    OpBE.NombreOperacion = dt.Rows[i]["Descripcion"].ToString();
                    listaoperaciones1.Add(OpBE);
                }

            }

            return listaoperaciones1;

        }

        public BE.Usuario verificarPatentesEscenciales(List<Operacion> listaoperacionessistema, Usuario usuBe)
        {
           
            
            foreach (BE.Seguridad.Operacion item in listaoperacionessistema) //recorro las huerfanas 
            {
                string verificarusuariosql = " select UsuarioID from usuariooperacion uo " +
                " inner join operacion o on o.OperacionID = uo.OperacionID " +
                "  where o.Descripcion = '" + item.NombreOperacion.ToString() + "' " +
      "and UsuarioID = (select usuarioid from usuario where Usuario not like '" + usuBe._Usuario + "');";

                DataTable Data = con.Ejecutarreader(verificarusuariosql);

                if (Data.Rows.Count > 0)
                {
                    usuBe.Result = "True";
                    return usuBe;
                }

                else
                {
                    foreach (DataRow row in Data.Rows)
                    {
                        usuBe.Result = usuBe.Result + "--" + row[0].ToString() + "--";
                    }
                }

            }
            return usuBe;




        }
    }
}
