using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej8.Controller;
using Dsw2025Ej8.Domain;

using static Dsw2025Ej8.Controller.Controlador;

namespace Dsw2025Ej8.View;

public static class Vista
{
    static void MenuPrincipal(out string opcion)
    {
        Console.Clear();
        Console.WriteLine("--------------- MENU DEL BANCO ---------------\n");
        Console.WriteLine("OPCION 1: LISTADO DE CUENTAS");
        Console.WriteLine("OPCION 2: DEPOSITAR EN CUENTA");
        Console.WriteLine("OPCION 3: RETIRAR EN CUENTA");
        Console.WriteLine("OPCION 4: SALIR");

        Console.Write("\nINGRESE UNA OPCION: ");
        opcion = Console.ReadLine();
    }

    public static void EjecutarInterfaz()
    {
        do
        {
            MenuPrincipal(out string opcion);

            switch (opcion)
            {
                case "1": { ListarCuentas(); break; }
                case "2": { Depositar(); break; }
                case "3": { Retirar(); break; }
                case "4": { Salir(); break; }
                default: { Error(); break; }
            }
        }
        while(true);
    }
}
