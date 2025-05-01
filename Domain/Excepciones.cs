using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain;

public class MontoNoValido : Exception
{
    public MontoNoValido() { }
    public MontoNoValido(string message) : base(message) { }
}

public class CuentaNoActiva : Exception
{
    public CuentaNoActiva() { }
    public CuentaNoActiva(string message) : base(message) { }
}

public class SaldoInsuficiente : Exception
{
    public SaldoInsuficiente() { }
    public SaldoInsuficiente(string message) : base(message) { }
}

public class CuentaNoEncontrada : Exception
{
    public CuentaNoEncontrada() { }
    public CuentaNoEncontrada(string message) : base(message) { }
}
