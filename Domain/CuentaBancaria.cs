namespace Dsw2025Ej8.Domain;

public class CuentaBancaria
{
    #region Propiedades
    public TipoCuenta Tipo { get; }
    public string Numero { get; protected set; }
    public decimal Saldo { get; protected set; }
    public Estado Estado { get; protected set; }
    public decimal TasaDeInteres { get; protected set; }
    public decimal LimiteDeDescubierto { get; init; }
    public decimal Comision { get; protected set; }
    public string[] Titulares { get; protected set; }
    #endregion

    /*private TipoCuenta _tipo;
    private string _numero;
    private decimal _saldo;
    private Estado _estado;
    private decimal _tasaDeInteres;
    private decimal _limiteDeDescubierto;
    private decimal _comision;
    private string[] _titulares;*/

    #region Constructores
    public CuentaBancaria() { }

    public CuentaBancaria(string numero, decimal saldo, string[] titulares, TipoCuenta tipo)
    {
        Numero = numero;
        Saldo = saldo;
        Tipo = tipo;
        Estado = Estado.Activa;
        Titulares = titulares;
    }
    #endregion

    #region Metodos
    public virtual void Depositar(decimal monto) { }

    public virtual void Retirar(decimal monto) { }

    public void AplicarInteres()
    {
        if (Tipo == TipoCuenta.CajaDeAhorro)
        {
            Saldo += Saldo * TasaDeInteres;
        }
    }
    #endregion

}
