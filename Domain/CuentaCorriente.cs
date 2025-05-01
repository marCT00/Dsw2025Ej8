using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain;

class CuentaCorriente : CuentaBancaria
{
    public CuentaCorriente() { }
    public CuentaCorriente(string numero, decimal saldo, string[] titulares, TipoCuenta tipo = TipoCuenta.CuentaCorriente, decimal comision = 0.09M) : base(numero, saldo, titulares, tipo) { Comision = comision; }

    #region Metodos
    public override void Depositar(decimal monto)
    {
        try
        {
            switch (Estado)
            {
                case Estado.Inactiva: { throw new CuentaNoActiva("No se puede operar con la cuenta. Estado: Inactiva"); }
                case Estado.Suspendida: { throw new CuentaNoActiva("No se puede operar con la cuenta. Estado: Suspendida"); }
            }

            if (monto <= 0) throw new MontoNoValido("Monto no válido");
            else
            {
                monto -= monto * Comision;
                Saldo += monto;
            }
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
                if (Saldo < 0)
                {
                    Estado = Estado.Suspendida;
                    throw new SaldoInsuficiente("Saldo insuficiente");
                }
                else if (Saldo - monto >= -LimiteDeDescubierto) Saldo -= monto;
                else throw new SaldoInsuficiente("Saldo insuficiente");
            }
        }
        catch (MontoNoValido ex) { Console.WriteLine($"{ex.Message}"); }
        catch (CuentaNoActiva ex) { Console.WriteLine($"{ex.Message}"); }
        catch (SaldoInsuficiente ex) { Console.WriteLine($"{ex.Message}"); }
    }
    #endregion
}
