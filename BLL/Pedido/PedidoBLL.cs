using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Pedido
{
    public class PedidoBLL
    {
        DAL.Pedido.PedidoDAL dalpe = new DAL.Pedido.PedidoDAL();

        string result;

        public PedidoBLL() { }

        public string GrabarNegocio(BE.Pedido.Pedido ped)
        {
            try
            {
                result = dalpe.GrabarNegocio(ped);

            }
            catch (Exception ex)
            {
                result = ex.Message;

            }

            return result;
        }

        public List<BE.Pedido.Pedido> ConsultarPedido(BE.Pedido.Pedido PedidoBE, string sqlmedio)
        {
            List<BE.Pedido.Pedido> listpedidos = new List<BE.Pedido.Pedido>();
            listpedidos = dalpe.ConsultarPedido(PedidoBE, sqlmedio);

            return listpedidos;
        }
    }
}
