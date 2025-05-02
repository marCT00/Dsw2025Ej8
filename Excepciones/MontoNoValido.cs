using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Excepciones
{
    public class MontoNoValido : Exception
    {

        public MontoNoValido(string? message= "El monto ingresado no es valido para la operacion solicitada") : base(message)
        {
        }
    }
}
