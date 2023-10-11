namespace CuentaMovimientosMicroservicio.Domain.Entities;

public class Cuenta : DomainEntity
{
    public int NumeroCuenta { get; set; }
    public required string TipoCuenta { get; set; }
    public decimal SaldoInicial { get; set; }
    public bool Estado { get; set; }
}