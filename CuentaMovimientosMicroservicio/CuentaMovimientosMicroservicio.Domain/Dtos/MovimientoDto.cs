namespace CuentaMovimientosMicroservicio.Domain.Dtos;

public record MovimientoDto(
    Guid Id, 
    int NumeroCuenta, 
    decimal Valor, 
    decimal Saldo,
    string TipoMovimiento,
    DateTime Fecha
);