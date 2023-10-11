namespace CuentaMovimientosMicroservicio.Domain.Entities;

public class Movimiento : DomainEntity
{    
    public DateTime Fecha { get; set; }
    public string? TipoMovimiento { get; set; }
    public decimal Valor { get; set; }
    public decimal Saldo { get; set; }
    public int NumeroCuenta { get; set; } // Clave foránea hacia Cuenta    
}
