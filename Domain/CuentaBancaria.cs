namespace Dsw2025Ej8.Domain;

public abstract class CuentaBancaria
{
  
    private string _numero;
    private decimal _saldo;
    private Estado _estado;
    
    
    private string[] _titulares;

    public CuentaBancaria(string numero, decimal saldo, string[] titulares)
    {
        _numero = numero;
        _saldo = saldo;
        _estado = Estado.Activa;
        _titulares = titulares;
    }
    #region Getters/Setters

    public String Numero { get => _numero; }
    public decimal Saldo { get => _saldo; set => _saldo = value; }
    public Estado Estado { get => _estado; set => _estado = value; }
 
    

   

    public String[] Titulares { get => _titulares; }

    #endregion

    public virtual void Depositar(decimal monto){}

    public virtual void Retirar(decimal monto) {}

    public virtual void AplicarInteres(){}
}
