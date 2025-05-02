using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej8.Domain;

namespace Dsw2025Ej8.Excepciones
{
    public class SaldoInsuficiente : Exception
    {
       

        public SaldoInsuficiente(string? message = "La cuenta no cuenta con saldo para la operación solicitada. Fue suspendida.") : base(message)
        {
         
        }


    }
}
