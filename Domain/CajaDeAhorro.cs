using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain;

class CajaDeAhorro : CuentaBancaria
{
    public CajaDeAhorro() { }
    public CajaDeAhorro(string numero, decimal saldo, string[] titulares, TipoCuenta tipo = TipoCuenta.CajaDeAhorro) : base(numero, saldo, titulares, tipo) { }

    #region Metodos
    public override void Depositar(decimal monto)
    {
        try
        {
            switch (Estado)
            {
                case Estado.Inactiva: { throw new CuentaNoActiva($"No se puede operar con la cuenta. Estado: {Estado.ToString()}"); }
                case Estado.Suspendida: { throw new CuentaNoActiva($"No se puede operar con la cuenta. Estado: {Estado.ToString()}"); }
            }

            if (monto <= 0) throw new MontoNoValido("Monto no válido");
            else Saldo += monto;
        }
        catch (MontoNoValido ex) { Console.WriteLine($"{ex.Message}"); }
        catch (CuentaNoActiva ex) { Console.WriteLine($"{ex.Message}"); }
    }

    public override void Retirar(decimal monto)
    {
        try
        {
            switch (Estado)
            {
                case Estado.Inactiva: { throw new CuentaNoActiva("No se puede operar con la cuenta. Estado: Inactiva"); }
                case Estado.Suspendida: { throw new CuentaNoActiva($"No se puede operar con la cuenta. Estado: Suspendida"); }
            }

            if (monto <= 0) throw new MontoNoValido("El monto ingresado no es válido para la operación solicitada");
            else
            {
                if (Saldo <= 0)
                {
                    Estado = Estado.Suspendida;
                    throw new SaldoInsuficiente("La cuenta no cuenta con saldo para la operación solicitada. Fue suspendida.");
                }
                else if (Saldo - monto < 0) throw new SaldoInsuficiente("Saldo insuficiente");
                else Saldo -= monto;
            }
        }
        catch (MontoNoValido ex) { Console.WriteLine($"{ex.Message}"); }
        catch (CuentaNoActiva ex) { Console.WriteLine($"{ex.Message}"); }
        catch (SaldoInsuficiente ex) { Console.WriteLine($"{ex.Message}"); }
        #endregion

    }
}
