using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Seguridad;

namespace BLL.Seguridad
{
    public class DigitosVerificadores
    {

        int contadorDVV = 0;

        DAL.Seguridad.DigitosVerificadoresDAL digitos = new DAL.Seguridad.DigitosVerificadoresDAL();
        BE.Seguridad.DigitosVerificadores dv = new BE.Seguridad.DigitosVerificadores();

        public BE.Seguridad.DigitosVerificadores CalcularDigitosVerificadores()
        {
            dv = digitos.VerificarDV();

            return dv;
        }


        public BE.Seguridad.DigitosVerificadores RecalcularDVH()
        {
            dv = digitos.RecalcularDVH();
            return dv;
        }

        public int CarlcularDVH(string aux)
        {
            char[] charArray = aux.ToCharArray();

            foreach (char ch in charArray)
            {
                contadorDVV += (int)ch;
            }

            return contadorDVV;
        }


    }
}
