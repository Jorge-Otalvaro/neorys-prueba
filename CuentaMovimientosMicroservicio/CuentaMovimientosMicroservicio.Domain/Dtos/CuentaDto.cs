namespace CuentaMovimientosMicroservicio.Domain.Dtos;

public record CuentaDto(int NumeroCuenta, string TipoCuenta, decimal SaldoInicial, DateTime FechaCreacion);
