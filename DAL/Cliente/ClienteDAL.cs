using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Cliente
{
   public class ClienteDAL
    {
        BE.Cliente.Cliente clienteBE = new BE.Cliente.Cliente();
        DataTable dt = new DataTable();
        Conexion con = new Conexion();
        public List<BE.Cliente.Cliente> BuscarClientes()
        {
           
            List<BE.Cliente.Cliente> listaclientes = new List<BE.Cliente.Cliente>();
            String sql = " select clienteid,razon_social,condicion_fiscal,telefono,Domicilio," +
                          " Habilitado from cliente " +
                          " where Habilitado = 1";
            con.Conectar();

            dt = con.Ejecutarreader(sql);

            foreach (DataRow row in dt.Rows)
            {
                BE.Cliente.Cliente cliente = new BE.Cliente.Cliente();
                cliente.Clienteid = Convert.ToInt16(row["clienteid"].ToString());
                cliente.razon_social = row["razon_social"].ToString();
                cliente.Condicion_fiscal = row["condicion_fiscal"].ToString();
                cliente.telefono = row["telefono"].ToString();
                cliente.Domicilio = row["Domicilio"].ToString();
                cliente.Habilitado = Convert.ToInt16(row["Habilitado"].ToString());


                listaclientes.Add(cliente);
            }


            con.Desconectar();

            return listaclientes;

        }

        public List<BE.Cliente.Cliente> traeragencias()
        {
            List<BE.Cliente.Cliente> listaclientes = new List<BE.Cliente.Cliente> ();
             
            string sql = "select distinct razon_social from cliente";
            con.Conectar();
            dt = con.Ejecutarreader(sql);
            con.Desconectar();

            foreach (DataRow row in dt.Rows)
            {
                BE.Cliente.Cliente clienteBE = new BE.Cliente.Cliente();
                clienteBE.razon_social = row["razon_social"].ToString();
                listaclientes.Add(clienteBE);
            }


            return listaclientes;
        }


        public void daraltacliente(BE.Cliente.Cliente cli)
        {
            string sql = "insert into cliente(razon_social,condicion_fiscal,telefono,Domicilio,Habilitado) values (" +
                          "'" + cli.razon_social + "','" + cli.Condicion_fiscal + "','" + cli.telefono + "'," +
                          "'" + cli.Domicilio + "'," + cli.Habilitado + ");";

            con.Conectar();
            con.Ejecutar(sql);
            con.Desconectar();
        }


        public BE.Cliente.Cliente EliminarCliente(BE.Cliente.Cliente cli) //clienteid 
        {
            string sql = "delete cliente where clienteid =" + cli.Clienteid + "";

            try
            {
                con.Conectar();

                con.Ejecutar(sql);
                con.Desconectar();

                cli.result = "True";
                return cli;
            }
            catch (Exception ex)
            {
                cli.result = ex.Message;
                return cli;
            }

        }


    }
}
