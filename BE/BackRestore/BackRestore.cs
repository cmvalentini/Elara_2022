using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.BackRestore
{
   public class BackRestore
    {
        public int Cantidad { get; set; }
        public string Path { get; set; }
        public string Result { get; set; }

        public BackRestore(int Cant,string Ruta) {
            Cantidad = Cant;
            Path = Ruta;

        }
        public BackRestore() { }

    }
}
