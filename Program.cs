using System.Security.Cryptography;
using Dsw2025Ej8.Domain;
using Dsw2025Ej8.Data;
using Dsw2025Ej8.Excepciones;
using Dsw2025Ej8.Views;
using Dsw2025Ej8.Controlador;

namespace Dsw2025Ej8;

internal class Program
{
    static void Main(string[] args)
    {
        Control c = new Control();
        Vista vista = new Vista(c);

        c.InicializarCuentas();
        vista.EjecutarMenu();
    }
   
}
    
