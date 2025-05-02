using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej8.Excepciones;

namespace Dsw2025Ej8.Domain
{
    public class CuentaCorriente : CuentaBancaria
    {
        private decimal _limiteDeDescubierto;
        private decimal _comision;
        public CuentaCorriente(string numero, decimal saldo, string[] titulares) : base(numero, saldo, titulares)
        {
        }

        public decimal LimiteDeDescubierto { get ;init; }

        public decimal Comision { get => _comision; set => _comision = value; }


        override public void  Depositar(decimal monto)
        {
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
                monto -= monto * _comision;
                Saldo += monto;

            }


        }
            

        override public void Retirar(decimal monto)
        {
            if (Estado != Estado.Activa)
            {
                throw new CuentaNoActiva(Estado);
            }
            if (monto <= 0)
            {
                throw new MontoNoValido();

            }

            if (Saldo - monto < -LimiteDeDescubierto)
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

   

 }

     
