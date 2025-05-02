using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsw2025Ej8.Excepciones;
using Dsw2025Ej8.Domain;
using System.Security.Cryptography;

namespace Dsw2025Ej8.Data
{
    public class Persistencia
    {
        private List<CuentaBancaria> _cuentas = new List<CuentaBancaria>();



        public List<CuentaBancaria> Inicializar()
        {
            _cuentas.Add(new CuentaDeAhorro("1", 3000, ["Ricardo"])
            {
                TasaDeInteres = 0.12M
            });
            _cuentas.Add(new CuentaCorriente("2", 2100, ["Luis"])
            {
                LimiteDeDescubierto = 10000
            });
            _cuentas.Add(new CuentaDeAhorro("3", 1000, ["Pedro"])
            {
                TasaDeInteres= 0.10M
            });
            _cuentas.Add(new CuentaCorriente("4", 6100, ["Agustin"])
            {
                LimiteDeDescubierto=15000
            });
            return _cuentas;

        }



      

        

    }
}
