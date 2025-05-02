using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej8.Data;
using Dsw2025Ej8.Domain;
using Dsw2025Ej8.Excepciones;

namespace Dsw2025Ej8.Controlador
{
    public class Control
    {
        public List<Acciones>Historial = new List<Acciones>();
        private List<CuentaBancaria> _cuentasControl = new List<CuentaBancaria>();

        public  void InicializarCuentas()
        {
            Persistencia p = new Persistencia();
            _cuentasControl = p.Inicializar();
        }


        public void Salir()
        {
            Console.Clear();
            Console.WriteLine("Saliendo...");
            Thread.Sleep(1000);
            Environment.Exit(0);
        }

        public void ListarDatos()
        {
            Console.WriteLine("----------------- LISTADO CUENTAS -----------------\n");
            ClaseAnonima(_cuentasControl);
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        public void Operaciones()
        {
            Console.WriteLine("----------------- OPERACIONES PRUEBA -----------------\n");
            CuentaDeAhorro _cuentaRicardo = (CuentaDeAhorro)_cuentasControl[0];
            

            CuentaDeAhorro _cuentaPedro = (CuentaDeAhorro)_cuentasControl[2];

            CuentaCorriente _cuentaLuis = (CuentaCorriente)_cuentasControl[1];

            CuentaCorriente _cuentaAgustin = (CuentaCorriente)_cuentasControl[3];

            DepositarAhorro(_cuentaRicardo, 10,Historial);

            DepositarAhorro(_cuentaRicardo, 50, Historial);

            DepositarCorriente(_cuentaAgustin, 30);

            RetirarAhorro(_cuentaPedro,200, Historial);

            RetirarAhorro(_cuentaRicardo,200, Historial);

            RetirarCorriente(_cuentaLuis, 50);
           
            DepositarAhorro(_cuentaPedro, 0, Historial);

            RetirarCorriente(_cuentaLuis, 50000);

            DepositarCorriente(_cuentaLuis, 10);


            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }

        public void ClaseAnonima(List<CuentaBancaria> cuentas)
        {
            foreach (var cuenta in cuentas)
            {
                var detalles = new
                {
                    numero = cuenta.Numero,
                    tipo = cuenta.GetType().Name,
                    saldo = cuenta.Saldo
                };
                Console.WriteLine($"Cuenta N: {detalles.numero}, Tipo: {detalles.tipo}, Saldo: {detalles.saldo}");
            }
        }

        public void DepositarAhorro(CuentaDeAhorro c, decimal monto, List<Acciones> Historial)
        {
            try
            {
                try
                {
                    try
                    {
                            int ultimoCodigo = Historial
                            .Where(h => h.numCuenta == c.Numero)
                            .Select(h => h.codigo)
                            .DefaultIfEmpty(0)
                            .Max();

                            Acciones a = new Acciones(c.Numero, "Deposito");
                            a.codigo = ultimoCodigo + 1;

                            Historial.Add(a);

                        c.Depositar(monto);
                        Console.WriteLine($"DEPOSITO: Cuenta N: {c.Numero}, Nuevo Saldo: {c.Saldo}");

                    }
                    catch (SaldoInsuficiente ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                catch (MontoNoValido ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (CuentaNoActiva ex)
            {
                Console.WriteLine(ex.Message);
            }
            TasaAplicada(c, Historial);
        }

        public  void RetirarAhorro(CuentaDeAhorro c, decimal monto, List<Acciones>Historial)
        {
            try
            {
                try
                {
                    try
                    {
                        int ultimoCodigo = Historial
                            .Where(h => h.numCuenta == c.Numero)
                            .Select(h => h.codigo)
                            .DefaultIfEmpty(0)
                            .Max();

                        Acciones a = new Acciones(c.Numero, "Retiro");
                        a.codigo = ultimoCodigo + 1;

                        Historial.Add(a);

                        c.Retirar(monto);
                        Console.WriteLine($"RETIRO: Cuenta N: {c.Numero}, Nuevo Saldo: {c.Saldo}");
                    }
                    catch (SaldoInsuficiente ex)
                    {
                        Console.WriteLine(ex.Message);

                    }
                }
                catch (MontoNoValido ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (CuentaNoActiva ex)
            {
                Console.WriteLine(ex.Message);
            }
            TasaAplicada(c, Historial);
        }

        public  void DepositarCorriente(CuentaCorriente c, decimal monto)
        {
            try
            {
                try
                {
                    try
                    {
                        c.Depositar(monto);
                        Console.WriteLine($"DEPOSITO: Cuenta N: {c.Numero}, Nuevo Saldo: {c.Saldo}");
                    }
                    catch (SaldoInsuficiente ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                catch (MontoNoValido ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (CuentaNoActiva ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public  void RetirarCorriente(CuentaCorriente c, decimal monto)
        {
            try
            {
                try
                {
                    try
                    {
                        c.Retirar(monto);
                        Console.WriteLine($"RETIRO: Cuenta N: {c.Numero}, Nuevo Saldo: {c.Saldo}");
                    }
                    catch (SaldoInsuficiente ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                catch (MontoNoValido ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (CuentaNoActiva ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public  void AplicarIntereses(CuentaDeAhorro c)
        {
            try
            {
                c.AplicarInteres();
                Console.WriteLine($"INTERES: Cuenta N: {c.Numero}, Nuevo Saldo: {c.Saldo}");
            }
            catch (CuentaNoActiva ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public  void Error()
        {
            Console.Clear();
            Console.WriteLine("ERROR: Opcion incorrecta");
            Console.WriteLine("\nSaliendo...");
            Thread.Sleep(2000);
            Environment.Exit(1);
        }

        public void TasaAplicada(CuentaDeAhorro c, List<Acciones> H)
        {

            int ultimoCodigo = Historial
                .Where(h => h.numCuenta == c.Numero)
                .Select(h => h.codigo)
                .DefaultIfEmpty(0)
                .Max();

            if (ultimoCodigo % 3 == 0)
            {
                AplicarIntereses(c);
            }
        }
    }

}
