using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej8.Domain;
using Dsw2025Ej8.View;
using static Dsw2025Ej8.Domain.Persistencia;

namespace Dsw2025Ej8.Controller;

static class Controlador
{
    static List<CuentaBancaria> cuentas = new List<CuentaBancaria>();

    public static void CrearCuentas() { cuentas = Persistencia.Inicializar(); }
 
    public static void Depositar()
    {
        Console.Clear();
        Console.WriteLine("----------------- DEPOSITO -----------------\n");

        Console.Write("INGRESE CUENTA: ");
        string op = Console.ReadLine();
        bool flag = false;

        try
        {
            foreach (var cuenta in cuentas)
            {
                if (op == cuenta.Numero)
                {
                    flag = true;
                    Console.Write("CANTIDAD A DEPOSITAR: ");
                    string cadena = Console.ReadLine();
                    decimal cantidad = decimal.Parse(cadena);

                    Console.WriteLine();
                    cuenta.Depositar(cantidad);
                }
            }
            if (!flag) throw new CuentaNoEncontrada("ERROR: Cuenta no encontrada.");
            else Console.WriteLine("Depósito realizado con éxito!");
        }
        catch (CuentaNoEncontrada ex) { Console.WriteLine($"\n{ex.Message}"); }

        Console.WriteLine("\nPresione una tecla para continuar...");
        Console.ReadKey();
    }

    public static void Retirar()
    {
        Console.Clear();
        Console.WriteLine("----------------- RETIRO -----------------\n");
        Console.Write("INGRESE CUENTA: ");
        string op = Console.ReadLine();
        bool flag = false;

        try
        {
            foreach (var cuenta in cuentas)
            {
                if (op == cuenta.Numero)
                {
                    flag = true;
                    Console.Write("CANTIDAD A RETIRAR: ");
                    string cadena = Console.ReadLine();
                    decimal cantidad = decimal.Parse(cadena);

                    Console.WriteLine();
                    cuenta.Retirar(cantidad);
                }
            }
            if (!flag) throw new CuentaNoEncontrada("\nERROR: Cuenta no encontrada.");
            else Console.WriteLine("Retiro realizado con éxito!");
        }
        catch (Exception ex) { Console.WriteLine($"{ex.Message}"); }
       
        Console.WriteLine("\nPresione una tecla para continuar...");
        Console.ReadKey();
    }

    public static void ListarCuentas()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------- LISTADO DE CUENTAS ----------------------------------\n");

        foreach (var cuenta in cuentas)
        {
            var resumen = new
            {
                Numero = cuenta.Numero,
                Tipo = cuenta.Tipo.ToString(),
                Saldo = cuenta.Saldo,
                Estado = cuenta.Estado,
            };

            Console.WriteLine($"Número: {resumen.Numero}, Tipo: {resumen.Tipo}, Saldo: {resumen.Saldo}, Estado de cuenta: {resumen.Estado}");
        }

        Console.WriteLine("\nPresione una tecla para continuar...");
        Console.ReadKey();
    }

    public static void Salir()
    {
        Console.Clear();
        Console.WriteLine("Saliendo...");
        Thread.Sleep(1000);
        Environment.Exit(0);
    }

    public static void Error()
    {
        Console.Clear();
        Console.WriteLine("ERROR: Opcion incorrecta");
        Console.WriteLine("\nSaliendo...");
        Thread.Sleep(2000);
        Environment.Exit(1);
    }

}
