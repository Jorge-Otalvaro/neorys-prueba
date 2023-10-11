namespace CuentaMovimientosMicroservicio.Domain.Dtos;

public record MovimientoDto(Guid Id, int NumeroCuenta, decimal Valor, DateTime Fecha, string TipoMovimiento, decimal Monto);
