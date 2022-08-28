using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Medio
{
   public class Medio
    {
       

        public string MedioNombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Iva { get; set; }
        public int Medioid { get; set; }

        public string Result { get; set; }

        public Medio() { }

        public Medio(string Medio, string Desc, int iva) {
            MedioNombre = Medio;
            Descripcion = Desc;
            Iva = iva;

        }

    }
}
