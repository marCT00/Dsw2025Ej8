using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej8.Domain;
namespace Dsw2025Ej8.Excepciones
{
    public class CuentaNoActiva : Exception
    {
       
     
        public CuentaNoActiva( Estado estado,string? message=null  ) : base(message ?? $"No se puede operar con la cuenta {estado.ToString()}")
        {
           
        }


    }
}
