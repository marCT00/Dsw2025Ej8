using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej8.Controlador;


namespace Dsw2025Ej8.Views
{
    public class Vista
    {
        Control _c;
       

        public Vista(Control control)
        {
            this._c = control;
        }

        public String MenuPrincipal( )
        {
            Console.Clear();
            Console.WriteLine("--------------- MENU DEL BANCO ---------------\n");
            Console.WriteLine("OPCION 1: LISTAR CUENTAS");
            Console.WriteLine("OPCION 2: OPERAR CUENTAS");
            Console.WriteLine("OPCION 3: SALIR");

            Console.WriteLine("\nIngrese una opcion: ");
            string opcion = Console.ReadLine() ?? " " ;
            return opcion;
           
          
        }

        public  void EjecutarMenu()
        {
            do
            {
              
                string opcion = MenuPrincipal();
                switch (opcion)
                {
                    case "1": { _c.ListarDatos(); break; }
                    case "2": { _c.Operaciones(); break; }  
                    case "3": { _c.Salir(); break; }
                    default: {_c.Error(); break; }
                }
            }while (true);

        }

    }
}
