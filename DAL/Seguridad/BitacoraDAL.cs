﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Seguridad
{
   public class BitacoraDAL
    {
        BE.Seguridad.BitacoraBE logBE = new BE.Seguridad.BitacoraBE();
        DigitosVerificadoresDAL dv = new DigitosVerificadoresDAL();
        Conexion con = new Conexion();

        public BE.Seguridad.BitacoraBE IngresarDatoBitacora(string nombreOperacion, string descripcion, int criticidad, int usuarioid)
        {

            string sql = "insert into Bitacora(NombreOperacion,Descripcion,UsuarioID,Criticidad,FechayHora) values ('"
                        + nombreOperacion + "','" + descripcion + "'," + usuarioid + ","
                        + criticidad + ",getdate())";

            logBE.result = con.Ejecutar(sql);
            dv.RecalcularDVH();


            return logBE;

        }

        public List<BE.Usuario> traerUsuarios()
        {
            BE.Usuario USUBE = new BE.Usuario();
            List<BE.Usuario> listausuario = new List<BE.Usuario>();
            DataTable datausuario = new DataTable();
            string sql = "select distinct usuario from usuario";
            datausuario = con.Ejecutarreader(sql);

            if (datausuario.Rows.Count > 0)
            {

                foreach (DataRow item in datausuario.Rows)
                {
                    USUBE._Usuario = item[0].ToString();
                    listausuario.Add(USUBE);
                }

                Console.WriteLine("entró reader DAL.BITACORA" + Convert.ToString(datausuario.Rows[0][0].ToString()));

            }

            return listausuario;

        }

        public List<BE.Seguridad.BitacoraBE> ConsultarBitacora(DateTime fechadesde, DateTime fechahasta, string sqlcriticidad, string sqlusuario)
        {
            List<BE.Seguridad.BitacoraBE> listabitacora = new List<BE.Seguridad.BitacoraBE>();


            DataTable dt = new DataTable();

            string sql =
         "select NombreOperacion, Descripcion, UsuarioID, Criticidad, FechayHora from Bitacora" +
         " where fechayhora BETWEEN '" + fechadesde + "' AND '" + fechahasta + "' " +
         " and Criticidad IN(" + sqlcriticidad + ")" +
         " AND UsuarioID IN(" + sqlusuario + ")";

            dt = con.Ejecutarreader(sql);

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow item in dt.Rows)
                {
                    BE.Seguridad.BitacoraBE BitacoraBE = new BE.Seguridad.BitacoraBE();
                    BitacoraBE.NombreOperacion = item[0].ToString();
                    BitacoraBE.Descripcion = item[1].ToString();
                    BitacoraBE.Usuarioid = Convert.ToInt16(item[2].ToString());
                    BitacoraBE.Criticidad = Convert.ToInt16(item[3].ToString());
                    BitacoraBE.FechayHora = Convert.ToDateTime(item[4].ToString());
                    listabitacora.Add(BitacoraBE);
                }
                Console.WriteLine("entró reader DAL.bitacora.ConsultarBitacora" + Convert.ToString(dt.Rows[0][0].ToString()));

            }
            
            return listabitacora;

        }

    }
}
