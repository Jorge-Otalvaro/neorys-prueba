using System.ComponentModel.DataAnnotations.Schema;

namespace CuentaMovimientosMicroservicio.Domain.Entities;

public class Movimiento : DomainEntity
{    
    public DateTime Fecha { get; set; }
    public TipoMovimiento TipoMovimiento { get; set; }
    public decimal Valor { get; set; }
    public decimal Saldo { get; set; }

    public DateTime CreatedOn { get; set; }
    public DateTime? LastModifiedOn { get; set; }

    public Guid CuentaId { get; set; }

    [NotMapped]
    public int NumeroCuenta { get; set; }    

    public Movimiento()
    {
        CreatedOn = DateTime.UtcNow;
    }

    public Movimiento(decimal valor, DateTime fecha, string tipoMovimiento, decimal saldo)
    {        
        Valor = valor;
        Fecha = fecha;
        TipoMovimiento = (TipoMovimiento)Enum.Parse(typeof(TipoMovimiento), tipoMovimiento);
        Saldo = saldo;
        CreatedOn = DateTime.UtcNow;
    }

    public Movimiento(Guid id, decimal valor, DateTime fecha, string tipoMovimiento, decimal saldo)
    {
        Id = id;        
        Valor = valor;
        Fecha = fecha;
        TipoMovimiento = (TipoMovimiento)Enum.Parse(typeof(TipoMovimiento), tipoMovimiento);
        Saldo = saldo;
        CreatedOn = DateTime.UtcNow;
    }

    public Movimiento(Guid id, decimal valor, DateTime fecha, string tipoMovimiento, decimal saldo, DateTime createdOn, DateTime? lastModifiedOn)
    {
        Id = id;        
        Valor = valor;
        Fecha = fecha;
        TipoMovimiento = (TipoMovimiento)Enum.Parse(typeof(TipoMovimiento), tipoMovimiento);
        Saldo = saldo;
        CreatedOn = createdOn;
        LastModifiedOn = lastModifiedOn;
    }
}
