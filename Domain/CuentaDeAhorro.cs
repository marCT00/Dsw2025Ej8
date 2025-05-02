using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej8.Excepciones;

namespace Dsw2025Ej8.Domain;
public class CuentaDeAhorro : CuentaBancaria
{
    private decimal _tasaDeInteres;
    public CuentaDeAhorro(string numero, decimal saldo, string[] titulares) : base(numero, saldo, titulares){}

    public decimal TasaDeInteres { get ; init; }

    override public void Depositar(decimal monto)
    {
        if(Estado != Estado.Activa)
        {
            throw new CuentaNoActiva(Estado);
        }
       
        if (monto <= 0)
        {
            throw new MontoNoValido();
        }
        else
        {
            Saldo += monto;
        }
    }

    override public void Retirar(decimal monto) {

        if (Estado != Estado.Activa)
        {
            throw new CuentaNoActiva(Estado);
        }

        if (monto <= 0)
        {
           throw new MontoNoValido();
        }
        else
        {
            if (monto > Saldo)
            {
                Estado = Estado.Suspendida;
                throw new SaldoInsuficiente();
            }
            else
            {
                Saldo -= monto;
            }
        }
    }

    override public void AplicarInteres( )
    {
        if (Estado != Estado.Activa)
        {
            throw new CuentaNoActiva(Estado);
        }
       
        decimal interes = Saldo * TasaDeInteres;
        Depositar(interes);
    }
}
