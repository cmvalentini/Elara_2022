using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Medio;

namespace BLL.Medio
{
    public class MedioBLL
    {


        BE.Medio.Medio Medio = new BE.Medio.Medio();
        public MedioBLL() { }
        public void DarAlta(BE.Medio.Medio medio)
        {
            DAL.Medio.MedioDAL MedioDAL = new DAL.Medio.MedioDAL();
            MedioDAL.DarAltaMedio(medio);

        }



        public BE.Medio.Medio seleccionarMedio(BE.Medio.Medio medio)
        {
            DAL.Medio.MedioDAL dalmedio = new DAL.Medio.MedioDAL();
            BE.Medio.Medio medioBE = new BE.Medio.Medio();

            medioBE = dalmedio.seleccionarMedio(medio);
            return medioBE;

        }

        public void modificarmedio(BE.Medio.Medio medio)
        {
            DAL.Medio.MedioDAL dalmedio = new DAL.Medio.MedioDAL();
            dalmedio.modificarmedio(medio);

        }

        public List<BE.Medio.Medio> BuscarMedios()
        {
            List<BE.Medio.Medio> listamedios = new List<BE.Medio.Medio>();
            DAL.Medio.MedioDAL mediodal = new DAL.Medio.MedioDAL();
            listamedios = mediodal.BuscarMedios();

            return listamedios;
        }

        public BE.Pedido.Pedido traernumeropedido()
        {
            DAL.Medio.MedioDAL medio = new DAL.Medio.MedioDAL();
            BE.Pedido.Pedido pedidoBE = new BE.Pedido.Pedido();
            pedidoBE = medio.traernumeropedido();
            return pedidoBE;

        }

        public BE.Medio.Medio Eliminarmedio(BE.Medio.Medio medioBE)
        {
            DAL.Medio.MedioDAL dalmedio = new DAL.Medio.MedioDAL();
            medioBE = dalmedio.Eliminarmedio(medioBE);
            return medioBE;
        }






    }
}
