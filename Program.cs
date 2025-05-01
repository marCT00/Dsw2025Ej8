using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using Dsw2025Ej8.Domain;
using Dsw2025Ej8.View;
using Dsw2025Ej8.Controller;

using static Dsw2025Ej8.Controller.Controlador;
using static Dsw2025Ej8.View.Vista;

namespace Dsw2025Ej8;

internal class Program
{
    static void Main(string[] args)
    {
        CrearCuentas();

        EjecutarInterfaz();
    }
}
