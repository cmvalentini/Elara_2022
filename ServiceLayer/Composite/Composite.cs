﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Composite
{
    public class Composite : Component
    {
        private static IList<Component> _hijos;
        public IList<Component> newchild;

        public override List<BE.Seguridad.Operacion> obtenerpatente{
            get
            {
                throw new NotImplementedException();
            }
        }

        public Composite(string nombre) : base(nombre)
        {
        }

     

        public override void AgregarHijo(Component c)
        {
            throw new NotImplementedException();
        }



        public void ObtenerHijos(List<BE.Seguridad.Operacion> listaoperacionesusuario){
            _hijos = this.devolerinstanciapermisos();
            foreach (var operacion in listaoperacionesusuario)
            {
               Leaf leaf = new Leaf(operacion.NombreOperacion.ToString());
                _hijos.Add(leaf);

                Console.WriteLine("se agrego a leaf" + operacion.ToString());
            }



        }

        public IList<Component> devolerinstanciapermisos()
        {
            if (_hijos == null)

                _hijos = new List<Component>();

            return _hijos;

        }

        public override IList<Component> obtenerhijos()
        {
            throw new NotImplementedException();
        }
    }
}
