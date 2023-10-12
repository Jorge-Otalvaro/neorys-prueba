namespace CuentaMovimientosMicroservicio.Domain.Dtos;

public record MovimientoDto(
    Guid Id,
    decimal Valor, 
    decimal Saldo,
    string TipoMovimiento,
    DateTime Fecha,
    int NumeroCuenta 
);