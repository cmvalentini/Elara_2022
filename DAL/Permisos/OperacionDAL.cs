using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            BE.Seguridad.Operacion OpBE = new BE.Seguridad.Operacion();
            dt = con.Ejecutarreader(sql);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    OpBE.NombreOperacion = dt.Rows[i]["Descripcion"].ToString();
                    listaoperaciones1.Add(OpBE);
                }

            }

            return listaoperaciones1;

        }

    }
}
