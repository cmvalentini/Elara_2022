using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Medio
{
    public class UbicacionDAL
    {
        List<BE.Medio.Ubicacion> listaubicacion = new List<BE.Medio.Ubicacion>();
        public string Nombremedio { get; set; }
        Conexion con = new Conexion();
        List<BE.Medio.Ubicacion> listubi = new List<BE.Medio.Ubicacion>();
        BE.Medio.Ubicacion ubicacionbe = new BE.Medio.Ubicacion();
        DataTable dt = new DataTable();
        BE.Medio.Medio mediobe = new BE.Medio.Medio();


        public List<BE.Medio.Ubicacion> traerubicaciones()
        {
            try
            {
                string sql = "select u.Nombreubicacion,m.medionombre, " +
                                   "u.Medidas,u.Formato, u.Formula,u.Habilitado, " +
                                   "u.Ubicacionid,u.Medioid,u.precio " +
                                   "from ubicacion u inner join medio m " +
                                   "on m.medioid = u.Medioid";


                dt = con.Ejecutarreader(sql);

                foreach (DataRow row in dt.Rows)
                {
                    BE.Medio.Ubicacion ubicacionbe = new BE.Medio.Ubicacion();
                    BE.Medio.Medio mediobe = new BE.Medio.Medio();
                    ubicacionbe.NombreUbicacion = row["Nombreubicacion"].ToString();
                    mediobe.MedioNombre = row["medionombre"].ToString();
                    ubicacionbe.medio = mediobe;
                    ubicacionbe.Medida = row["Medidas"].ToString();
                    ubicacionbe.Formato = row["Formato"].ToString();
                    ubicacionbe.Formula = row["Formula"].ToString();
                    ubicacionbe.Ubicacionid = Convert.ToInt16(row["Ubicacionid"].ToString());
                    ubicacionbe.medio.Medioid = Convert.ToInt16(row["Medioid"].ToString());
                    ubicacionbe.Precio = Convert.ToDecimal(row["precio"].ToString());

                    listaubicacion.Add(ubicacionbe);
                }


                return listaubicacion;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
           

        }

        public List<BE.Medio.Ubicacion> traerubicaciones(BE.Medio.Medio MedioBE)
        {
            string sql = "select u.Nombreubicacion,m.medionombre, " +
                    "u.Medidas,u.Formato, u.Formula,u.Habilitado, " +
                    "u.Ubicacionid,u.Medioid,u.precio " +
                    "from ubicacion u inner join medio m " +
                    "on m.medioid = u.Medioid " +
                    "where m.medionombre like '%" + MedioBE.MedioNombre + "%';";

            dt = con.Ejecutarreader(sql);

            foreach (DataRow row in dt.Rows)
            {
                BE.Medio.Ubicacion Ubi = new BE.Medio.Ubicacion();
                BE.Medio.Medio Medio = new BE.Medio.Medio();
                Ubi.NombreUbicacion = row["Nombreubicacion"].ToString();
                Medio.MedioNombre = row["medionombre"].ToString();
                Ubi.medio = Medio;
                Ubi.Medida = row["Medidas"].ToString();
                Ubi.Formato = row["Formato"].ToString();
                Ubi.Formula = row["Formula"].ToString();
                Ubi.Ubicacionid = Convert.ToInt16(row["Ubicacionid"].ToString());
                Ubi.medio.Medioid = Convert.ToInt16(row["Medioid"].ToString());
                Ubi.Precio = Convert.ToDecimal(row["precio"].ToString());

                listaubicacion.Add(Ubi);
            }


            return listaubicacion;
        }

        public List<BE.Medio.Medio> TraerMedios()
        {
            List<BE.Medio.Medio> listamedios = new List<BE.Medio.Medio>();
            
            string sql = "select distinct medionombre from medio";
            con.Conectar();
            dt = con.Ejecutarreader(sql);
            con.Desconectar();

            foreach (DataRow row in dt.Rows)
            {
                BE.Medio.Medio medio = new BE.Medio.Medio();
                medio.MedioNombre = row[0].ToString();
                listamedios.Add(medio);
            }


            return listamedios;
        }

        public BE.Medio.Ubicacion seleccionarUbicacion(BE.Medio.Ubicacion ubibe)
        {
            try
            {
                string sql = " select Ubicacionid,medionombre,Nombreubicacion,medidas,Formato,Formula,Habilitado,precio " +
                          " from ubicacion u inner join medio m on m.medioid = u.Medioid " +
                          " where u.Ubicacionid =" + ubibe.Ubicacionid + ";";

                dt = con.Ejecutarreader(sql);
                BE.Medio.Ubicacion ubi = new BE.Medio.Ubicacion();
             

                foreach (DataRow item in dt.Rows)
                {

                    ubi.Ubicacionid = Convert.ToInt16(item[0].ToString());
                    ubi.NombreMedio = item[1].ToString();
                    ubi.NombreUbicacion = item[2].ToString();
                    ubi.Medida = item[3].ToString();
                    ubi.Formato = item[4].ToString();
                    ubi.Formula = item[5].ToString();
                    if (item[6].ToString() == "True")
                    {
                        ubi.Habilitado = 1;
                    }

                    else
                    {
                        ubi.Habilitado = 0;
                    }

                    
                    ubi.Precio = Convert.ToDecimal(item[7].ToString());
                    listubi.Add(ubi);
                }

                return ubi;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message) ;
                
                throw;
            }



        
        }

        public BE.Medio.Ubicacion daraltaubicacion(BE.Medio.Ubicacion dalubicacion)
        {

            string sql = "select medioid from medio where medionombre " +
                         "like '%" + dalubicacion.medio.MedioNombre.ToString() + "%'";
            con.Conectar();
            dt = con.Ejecutarreader(sql);


            foreach (DataRow item in dt.Rows)
            {
                dalubicacion.medio.Medioid = Convert.ToInt16(item[0].ToString());
            }

            con.Desconectar();

            con.Conectar();
            string sql1 = "insert into ubicacion(Nombreubicacion, Medioid, Medidas, Formato, Formula, Habilitado,Precio) " +
                         " values('" + dalubicacion.NombreUbicacion.ToString() + "'," + dalubicacion.medio.Medioid.ToString() + ", " +
                         "'" + dalubicacion.Medida.ToString() + "','" + dalubicacion.Formato.ToString() + "','" + dalubicacion.Formula.ToString() + "', " +
                         " " + dalubicacion.Habilitado.ToString() + "," + dalubicacion.Precio + ") ";

            try
            {
                dalubicacion.Result = con.Ejecutar(sql1);



            }
            catch (Exception ex)
            {

                dalubicacion.Result = ex.Message;
            }

            return dalubicacion;


        }

        public BE.Medio.Ubicacion traerPrecio(BE.Medio.Ubicacion UbiBE) // nombremedio, ubicacionmedio
        {

            string sql = " select Ubicacionid,medionombre,Nombreubicacion,medidas,Formato,Formula,Habilitado,precio " +
                        " from ubicacion u inner join medio m on m.medioid = u.Medioid " +
                        " where u.habilitado = 1 " +
                        " and m.medionombre like '%" + UbiBE.medio.MedioNombre + "%' " +
                        " and u.Nombreubicacion like '%" + UbiBE.NombreUbicacion + "%' ";

            dt = con.Ejecutarreader(sql);
            BE.Medio.Ubicacion ubi = new BE.Medio.Ubicacion();
            foreach (DataRow item in dt.Rows)
            {
               
                ubi.Ubicacionid = Convert.ToInt16(item[0].ToString());
                ubi.NombreUbicacion = item[2].ToString();
                ubi.Medida = item[3].ToString();
                ubi.Formato = item[4].ToString();
                ubi.Formula = item[5].ToString();
                ubi.Precio = Convert.ToDecimal(item[7].ToString());
                // listubi.Add(ubi);
            }



            return ubi;
        }

        public BE.Medio.Ubicacion EliminarUbicacion(BE.Medio.Ubicacion UBIbe) 
        {
            UBIbe.Result = "False";
            string sql = "delete ubicacion where ubicacionid = " + UBIbe.Ubicacionid + "; ";
            try
            {
                con.Conectar();
                con.Ejecutar(sql);
                UBIbe.Result = "True";
                return UBIbe;
            }
            catch (Exception ex)
            {
                UBIbe.Result = ex.Message;
                return UBIbe;
            }

            finally
            {
                con.Desconectar();
            }

        }

        public BE.Medio.Ubicacion Modificarubicacion(BE.Medio.Ubicacion ubicacionBE)
        {
            string sql =
                          "  declare @medioid int; " +
                           " select @medioid = medioid from medio m where m.medionombre like '%" + ubicacionBE.medio.MedioNombre + "%' ;" +
                           " update ubicacion  " +
                           " set Nombreubicacion ='" + ubicacionBE.NombreUbicacion + "'," +
                           " Medioid = @medioid ," +
                           " medidas ='" + ubicacionBE.Medida + "'," +
                           " Formato ='" + ubicacionBE.Formato + "'," +
                           " formula ='" + ubicacionBE.Formula + "'," +
                           " habilitado =" + ubicacionBE.Habilitado + "," +
                           " precio =" + ubicacionBE.Precio.ToString().Replace(",", ".") + " " +
                           " where ubicacionid =" + ubicacionBE.Ubicacionid + "; ";
                           
            con.Conectar();
            ubicacionBE.Result = con.Ejecutar(sql);


            return ubicacionBE;

        }


    }
}
