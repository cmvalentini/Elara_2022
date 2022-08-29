using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Medio
{
    public class UbicacionBLL
    {

        List<BE.Medio.Ubicacion> listaubicaciones;


        public UbicacionBLL()
        {

        }



        public List<BE.Medio.Ubicacion> TraerUbicaciones()
        {
            DAL.Medio.UbicacionDAL ubidal = new DAL.Medio.UbicacionDAL();
            listaubicaciones = ubidal.traerubicaciones();


            return listaubicaciones;
        }

        public List<BE.Medio.Ubicacion> TraerUbicaciones(BE.Medio.Medio medio)
        {
            DAL.Medio.UbicacionDAL ubi = new DAL.Medio.UbicacionDAL();
            listaubicaciones = ubi.traerubicaciones(medio);

            return listaubicaciones;
        }

        public List<BE.Medio.Medio> TraerMedios()
        {
            DAL.Medio.UbicacionDAL ubi = new DAL.Medio.UbicacionDAL();
            List<BE.Medio.Medio> listamedios = new List<BE.Medio.Medio>();

            listamedios = ubi.TraerMedios();



            return listamedios;

        }

        public BE.Medio.Ubicacion seliccionarUbicacion(BE.Medio.Ubicacion ubibe)//ubicacionid
        {
            BE.Medio.Ubicacion ubicacionBE = new BE.Medio.Ubicacion();
            DAL.Medio.UbicacionDAL ubi = new DAL.Medio.UbicacionDAL();
            ubicacionBE = ubi.seleccionarUbicacion(ubibe);



            return ubicacionBE;

        }



        public BE.Medio.Ubicacion daraltaubicacion(BE.Medio.Ubicacion ubicacion)
        {
            DAL.Medio.UbicacionDAL dalubicacion = new DAL.Medio.UbicacionDAL();


            ubicacion = dalubicacion.daraltaubicacion(ubicacion);

            return ubicacion;
        }

        public BE.Medio.Ubicacion traerPrecio(BE.Medio.Ubicacion ubibe) //nombremedio, ubicacionmedio
        {


            DAL.Medio.UbicacionDAL dalubicacion = new DAL.Medio.UbicacionDAL();

            ubibe = dalubicacion.traerPrecio(ubibe);


            
            return ubibe;
        }

        public BE.Medio.Ubicacion Modificarubicacion(BE.Medio.Ubicacion ubicacion)
        {
            DAL.Medio.UbicacionDAL dalubicacion = new DAL.Medio.UbicacionDAL();

            ubicacion = dalubicacion.Modificarubicacion(ubicacion);

            return ubicacion;


        }

        public BE.Medio.Ubicacion EliminarUbicacion(BE.Medio.Ubicacion ubiBE)
        {
            DAL.Medio.UbicacionDAL dalubicacion = new DAL.Medio.UbicacionDAL();
            ubiBE.Result = "False";
            try
            {
                ubiBE = dalubicacion.EliminarUbicacion(ubiBE);
                return ubiBE;
            }
            catch (Exception ex)
            {
                ubiBE.Result = ex.Message;
                return ubiBE;
            }


        }

    }
}
