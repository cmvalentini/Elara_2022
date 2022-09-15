using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Cliente;

namespace BLL.Cliente
{
    public class ClienteBLL
    {

        DAL.Cliente.ClienteDAL dalcli = new DAL.Cliente.ClienteDAL();
        BE.Cliente.Cliente ClienteBE = new BE.Cliente.Cliente();

        public ClienteBLL() { }


        public List<BE.Cliente.Cliente> BuscarClientes()
        {
            List<BE.Cliente.Cliente> listaclientes = new List<BE.Cliente.Cliente>();
            listaclientes = dalcli.BuscarClientes();

            return listaclientes;

        }

        public void daraltacliente(BE.Cliente.Cliente cli)
        {

            dalcli.daraltacliente(cli);

        }

        public List<BE.Cliente.Cliente> traeragencias()
        {
            List<BE.Cliente.Cliente> listaclientes = new List<BE.Cliente.Cliente>();

            DAL.Cliente.ClienteDAL cli = new DAL.Cliente.ClienteDAL();

            listaclientes = cli.traeragencias();

            return listaclientes;
        }

        public BE.Cliente.Cliente EliminarCliente(BE.Cliente.Cliente cli) // clienteid
        {

            ClienteBE = dalcli.EliminarCliente(cli);

            return ClienteBE;
        }

     
    }
}
