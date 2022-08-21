using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.BackRestore;
using System.Data.SqlClient;
using System.Data;

namespace DAL.BackRestore
{
    public class BackRestoreDAL
    {
        public void RealizarBackUp(BE.BackRestore.BackRestore br)
        {
            List<SqlParameter> ParametrosSP = new List<SqlParameter>();
            SqlParameter Parametro1 = new SqlParameter("@CANT", Convert.ToInt16(br.Cantidad));
            ParametrosSP.Add(Parametro1);


            try
            {
                DAL.Conexion con = new Conexion();

                con.EjecutarProcedureconListaParametros("RealizarBackUp", ParametrosSP);

                Console.WriteLine( "Back Up exitoso");
            }
            catch (Exception ex)
            {

                Console.WriteLine( "Revise el acceso a la carpeta " + ex.Message);
            }
        }

        public BE.BackRestore.BackRestore RealizarRestore(BE.BackRestore.BackRestore restoreBe)
        {
            try
            {
                string stringcon = "DESKTOP-VF25GBN\\SERVERCHARLY;Initial Catalog=master;Integrated Security=True";


                SqlConnection con1 = new SqlConnection(stringcon);
                con1.Open();

                SqlCommand com = new SqlCommand("RealizarRestore", con1);
                com.CommandType = CommandType.StoredProcedure;

                SqlParameter Parametro1 = new SqlParameter("@CANT", restoreBe.Cantidad);

                com.Parameters.Add(Parametro1);


                com.ExecuteReader();

                con1.Close();
                restoreBe.Result = "Restore OK";
                return restoreBe;

            }

            catch (Exception ex)
            {
                restoreBe.Result = ex.Message;
                return restoreBe;
            }



        }
    }
}
