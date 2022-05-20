using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer;

namespace BLL.Permisos
{
    public class DirectorioperfilBLL :ServiceLayer.Composite.Component
    {


        private List<BE.Seguridad.Operacion> listaoperaciones;
        ManejadorPerfilUsuarios mpu = new ManejadorPerfilUsuarios();


        private List<ServiceLayer.Composite.Component> _hijos = new List<ServiceLayer.Composite.Component>();
        public DirectorioperfilBLL(string nombre) : base(nombre)
        {
            //   _hijos = new List<Componente>();
        }

        public override List<BE.Seguridad.Operacion> obtenerpatente
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override void AgregarHijo(ServiceLayer.Composite.Component c)
        {
            _hijos.Add(c);
        }

        public override IList<ServiceLayer.Composite.Component> obtenerhijos()
        {
            return _hijos.ToArray();
        }


         

        public void obtenerhijos(Sesion s)
        {
            listaoperaciones = new List<BE.Seguridad.Operacion>();
            listaoperaciones = mpu.MostrarMenuPerfiles(s);


        }
    }
}
