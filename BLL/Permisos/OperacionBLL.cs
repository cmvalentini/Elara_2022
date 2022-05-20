using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BLL.Permisos
{
    public class OperacionBLL
    {
        public Usuario verificarPatentesEscenciales(Usuario usuBE)
        {
            DAL.Permisos.ManejadorPerfilUsuarioDAL MPU = new DAL.Permisos.ManejadorPerfilUsuarioDAL();
            usuBE = MPU.verificarPatentesEscenciales(usuBE);

            return usuBE;
        }
    }
}
