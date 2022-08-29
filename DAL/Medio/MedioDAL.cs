using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Medio;
using System.Data;

namespace DAL.Medio
{
    public class MedioDAL
    {
        
        Conexion con = new Conexion();
        DataTable dt = new DataTable();
        public void DarAltaMedio(BE.Medio.Medio medio)
        {
            string sql = "insert into Medio (medionombre,descripcion,iva) values" +
                         " ('" + medio.MedioNombre + "','" + medio.Descripcion + "',"+ medio.Iva.ToString().Replace(",", ".") +") " ; //CAST('" + medio.Iva + "'AS DECIMAL(4, 2)) 


            con.Ejecutar(sql);
            
        }

        public void modificarmedio(BE.Medio.Medio medioBE)
        {
            string sql = "update medio set medionombre = '" + medioBE.MedioNombre + "'," +
                          "descripcion = '" + medioBE.Descripcion + "'," +
                          "iva = " + medioBE.Iva.ToString().Replace(",", ".") + " " +
                          "where medioid =" + medioBE.Medioid + " ;";

            con.Ejecutar(sql);

        }

        public List<BE.Medio.Medio> BuscarMedios()
        {
            string sql = "select medionombre,descripcion,iva,medioid from medio";

            List<BE.Medio.Medio> listamedio = new List<BE.Medio.Medio>();
            con.Conectar();

            con.Ejecutarreader(sql);
            dt = con.Ejecutarreader(sql);
          

            foreach (DataRow item in dt.Rows)
            {
                BE.Medio.Medio medioBE = new BE.Medio.Medio();
                medioBE.MedioNombre = item[0].ToString();
                medioBE.Descripcion = item[1].ToString();
                medioBE.Iva = Convert.ToDecimal(item[2].ToString());
                medioBE.Medioid = Convert.ToInt16(item[3].ToString());

                listamedio.Add(medioBE);
            }

            con.Desconectar();

            return listamedio;
        }

        public BE.Medio.Medio seleccionarMedio(BE.Medio.Medio Medio)
        {
             
            string sql = "select descripcion,medionombre,iva from medio " +
                       " where medioid = " + Medio.Medioid + ";";

            dt = con.Ejecutarreader(sql);

            if (dt.Rows.Count > 0)
            {
                Console.WriteLine("entró reader " + Convert.ToString(dt.Rows[0][0].ToString()));

                Medio.Descripcion = dt.Rows[0][0].ToString();
                Medio.MedioNombre = dt.Rows[0][1].ToString();
                Medio.Iva = Convert.ToDecimal(dt.Rows[0][2].ToString());

            }


            return Medio;

        }

        public BE.Pedido.Pedido traernumeropedido()
        {
            BE.Pedido.Pedido ped = new BE.Pedido.Pedido();
            ped.pedidoid = 0;
            string sql = "select top(1)pedidoid from pedido order by 1 desc";
            dt = con.Ejecutarreader(sql);

            foreach (DataRow item in dt.Rows)
            {
                ped.pedidoid = Convert.ToInt16(item[0].ToString()) + 1;
            }


            return ped;
        }

        public BE.Medio.Medio Eliminarmedio(BE.Medio.Medio medio)
        {

            string sql = "delete medio where medioid = " + medio.Medioid + ";";
            try
            {
                con.Ejecutar(sql);
                medio.Result = "True";
            }
            catch (Exception exp)
            {
                medio.Result = exp.Message;
            }
            return medio;


        }


      




    }
}
