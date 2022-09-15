using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualBasic;


namespace DAL.Seguridad
{
    public class DigitosVerificadoresDAL
    {

        EncriptacionDAL cryp = new EncriptacionDAL();
        Conexion con = new Conexion();
        DataTable dtusuarios = new DataTable();

        BE.Seguridad.DigitosVerificadores DV = new BE.Seguridad.DigitosVerificadores();
      

        string RegistrosACalcular = "select Usuarioid,Usuario,Clave,dni,email,habilitado,dvh from usuario";


        public BE.Seguridad.DigitosVerificadores VerificarDV()
        {
            try
            {

                con.Conectar();
                dtusuarios = con.Ejecutarreader(RegistrosACalcular);

                foreach (DataRow item in dtusuarios.Rows)
                {
                    string usuarioid = item[0].ToString();
                    string usuario = item[1].ToString();
                    string Clave = item[2].ToString();
                    string dni = item[3].ToString();
                    string email = item[4].ToString();
                    string habilitado = item[5].ToString();
                    string dvh = cryp.Desencriptar(item[6].ToString());

                    long Lusuarioid = calculartabladvh(usuarioid);
                    long Lusuario = calculartabladvh(usuario);
                    long LClave = calculartabladvh(Clave);
                    long Ldni = calculartabladvh(dni);
                    long Lemail = calculartabladvh(email);
                    long Lhabilitado = calculartabladvh(habilitado);

                    long suma = Lusuarioid + Lusuario + LClave + Ldni + Lemail + Lhabilitado;

                     if (suma == Convert.ToInt32(dvh))
                    {
                       
                    }
                    else
                    {
                        DV.result = "La consistencia de los datos ha sido alterada en el usuario"+ usuario +" ";
                        return DV;
                    }
                    DV.result = "Comprobación de Digitos Verificadores OK";

                }
                return DV;

            }
            catch (Exception ex)
            {

                DV.result = ex.Message;

                return DV;
            }


        }

        private long calculartabladvh(string Texto) {

            long digitoHorizontal = 0;
            byte[] ASCIIValues = Encoding.ASCII.GetBytes(Texto);

            int posicion = 1;
            foreach (byte b in ASCIIValues)
            {
                digitoHorizontal += b * posicion;
                posicion += 1;
            }
            return digitoHorizontal;
            

        }


        public BE.Seguridad.DigitosVerificadores RecalcularDVH()
        {
            BE.Seguridad.DigitosVerificadores DV = new BE.Seguridad.DigitosVerificadores();
            try
            {

                con.Conectar();
                dtusuarios = con.Ejecutarreader(RegistrosACalcular);
                long totdvhusuario = 0;

                foreach (DataRow item in dtusuarios.Rows)
                {
                    string usuarioid = item[0].ToString();
                    string usuario = item[1].ToString();
                    string Clave = item[2].ToString();
                    string dni = item[3].ToString();
                    string email = item[4].ToString();
                    string habilitado = item[5].ToString();
                    string dvh = cryp.Desencriptar(item[6].ToString());

                    long Lusuarioid = calculartabladvh(usuarioid);
                    long Lusuario = calculartabladvh(usuario);
                    long LClave = calculartabladvh(Clave);
                    long Ldni = calculartabladvh(dni);
                    long Lemail = calculartabladvh(email);
                    long Lhabilitado = calculartabladvh(habilitado);

                    long suma = Lusuarioid + Lusuario + LClave + Ldni + Lemail + Lhabilitado;
                    totdvhusuario = +suma;
                    string sumaencriptada = cryp.Encriptar(suma.ToString());
                    string sql = "update usuario set dvh = '" + sumaencriptada +
                        "'  where usuarioid = " + usuarioid + " ";

                    con.Ejecutar(sql);
                }
                string dvvtotal = cryp.Encriptar(totdvhusuario.ToString());
                string sqldvv = "update dvv set dvv = " + dvvtotal +
                        "where tabla = 'Usuario' ";

                con.Desconectar();
                DV.result = "Dígitos recalculados correctamente";
                return DV;
            }
            catch (Exception ex)
            {

                DV.result = ex.Message;
                return DV;

            }

        }

    

    }
}
