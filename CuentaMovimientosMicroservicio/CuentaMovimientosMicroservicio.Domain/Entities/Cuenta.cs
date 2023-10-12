using System.ComponentModel.DataAnnotations.Schema;

namespace CuentaMovimientosMicroservicio.Domain.Entities;

public class Cuenta : DomainEntity
{    
    public int NumeroCuenta { get; set; }
    public required string TipoCuenta { get; set; }
    public decimal SaldoInicial { get; set; }
    public bool Estado { get; set; }
    public Guid ClienteId { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? LastModifiedOn { get; set; }
    [NotMapped]
    public string? Cliente { get; set; }

    public Cuenta()
    {
        CreatedOn = DateTime.UtcNow;
    }

    public Cuenta(int numeroCuenta, string tipoCuenta, decimal saldoInicial, bool estado, Guid clienteId)
    {
        NumeroCuenta = numeroCuenta;
        TipoCuenta = tipoCuenta;
        SaldoInicial = saldoInicial;
        Estado = estado;
        ClienteId = clienteId;
        CreatedOn = DateTime.UtcNow;
    }

    public void ActualizarSaldo(decimal valor)
    {
        SaldoInicial += valor;
        LastModifiedOn = DateTime.UtcNow;
    }

    public void ActualizarEstado(bool estado)
    {
        Estado = estado;
        LastModifiedOn = DateTime.UtcNow;
    }

    public void ActualizarTipoCuenta(string tipoCuenta)
    {
        TipoCuenta = tipoCuenta;
        LastModifiedOn = DateTime.UtcNow;
    }

    public void ActualizarNumeroCuenta(int numeroCuenta)
    {
        NumeroCuenta = numeroCuenta;
        LastModifiedOn = DateTime.UtcNow;
    }
}