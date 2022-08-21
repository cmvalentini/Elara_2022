using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BE.Seguridad;

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

        public BE.Usuario verificarPatentesEscenciales(List<Operacion> listaoperacionessistema, Usuario usuBe)
        {
             

            DAL.Permisos.OperacionDAL opDAL = new DAL.Permisos.OperacionDAL();
            usuBe = opDAL.verificarPatentesEscenciales(listaoperacionessistema, usuBe);

            return usuBe;

        }
    }
}
