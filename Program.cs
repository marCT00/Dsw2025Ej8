using System.Security.Cryptography;
using Dsw2025Ej8.Domain;
using Dsw2025Ej8.Data;
using Dsw2025Ej8.Excepciones;

namespace Dsw2025Ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Persistencia p = new Persistencia();
            p.Inicializar();
            List<CuentaBancaria> cuentas = p.Cuentas;



            /*Clase anonima que muestra lo detalles de cada cuenta*/
            Console.WriteLine("--- DATOS DE CUENTA ---");
            ClaseAnonima(cuentas);
            /*Clase que realiza las operaciones de prueba para cada cuenta*/
            Console.WriteLine("--- OPERACIONES --- ");
            Operaciones(cuentas);
            
            

        }

        public static void Operaciones(List<CuentaBancaria> cuentas) {
            CuentaDeAhorro _cuentaRicardo = (CuentaDeAhorro)cuentas[0];
            CuentaDeAhorro _cuentaPedro = (CuentaDeAhorro)cuentas[2];

            CuentaCorriente _cuentaLuis = (CuentaCorriente)cuentas[1];
            CuentaCorriente _cuentaAgustin = (CuentaCorriente)cuentas[3];

            _cuentaRicardo.Estado = Estado.Activa;
            DepositarAhorro(_cuentaRicardo, 10);
            DepositarCorriente(_cuentaAgustin,30);
            RetirarAhorro(_cuentaPedro, 200);
            RetirarCorriente(_cuentaLuis, 50);
            AplicarIntereses(_cuentaRicardo);
            DepositarAhorro(_cuentaPedro, 0);
            RetirarCorriente(_cuentaLuis,50000);
            DepositarCorriente(_cuentaLuis, 10);

        }
        public static void ClaseAnonima(List<CuentaBancaria> cuentas)
        {
            foreach(var cuenta in cuentas)
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
        public static void DepositarAhorro(CuentaDeAhorro c , decimal monto)
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
                }catch(MontoNoValido ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (CuentaNoActiva ex) {
                Console.WriteLine(ex.Message);
            }
        }

        public static void RetirarAhorro(CuentaDeAhorro c,decimal monto) {
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
    
        public static void DepositarCorriente(CuentaCorriente c, decimal monto) {
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
        
        public static void RetirarCorriente(CuentaCorriente c , decimal monto)
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
    
        public static void AplicarIntereses(CuentaDeAhorro c)
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
        

        
    }
        
}
