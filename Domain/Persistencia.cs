using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Dsw2025Ej8.Domain;

internal class Persistencia
{
    public static List<CuentaBancaria> Inicializar()
    {
        var cuentas = new List<CuentaBancaria>
        {
            new CajaDeAhorro("CA001", 1000m, new[] { "Genaro Toledo" }) ,
            new CajaDeAhorro("CA002", 5000m, new[] { "María Gómez" }),
            new CuentaCorriente("CC001", 2000m, new[] { "Christopher Tula" }) { LimiteDeDescubierto = 1000 },
            new CuentaCorriente("CC002", -500m, new[] { "Carlos López" }) { LimiteDeDescubierto = 500 },
        };

        return cuentas;
    }
}
