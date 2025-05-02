using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
   public class Acciones
    {
        public string descripcion {  get; set; }
        public int codigo {  get; set; }
        public string numCuenta { get; set; }

        public Acciones(string numCuenta,string descripcion)
        {
            this.numCuenta = numCuenta;
            this.descripcion = descripcion;

        }
    }
}
