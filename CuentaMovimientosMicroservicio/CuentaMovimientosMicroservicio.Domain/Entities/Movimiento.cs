namespace CuentaMovimientosMicroservicio.Domain.Entities;

public class Movimiento : DomainEntity
{    
    public DateTime Fecha { get; set; }
    public string? TipoMovimiento { get; set; }
    public decimal Valor { get; set; }
    public decimal Saldo { get; set; }
    public int NumeroCuenta { get; set; }
    public Guid CuentaId { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? LastModifiedOn { get; set; }

    public Movimiento()
    {
        CreatedOn = DateTime.UtcNow;
    }

    public Movimiento(int numeroCuenta, decimal valor, DateTime fecha, string tipoMovimiento, decimal saldo)
    {
        NumeroCuenta = numeroCuenta;
        Valor = valor;
        Fecha = fecha;
        TipoMovimiento = tipoMovimiento;
        Saldo = saldo;
        CreatedOn = DateTime.UtcNow;
    }
}
