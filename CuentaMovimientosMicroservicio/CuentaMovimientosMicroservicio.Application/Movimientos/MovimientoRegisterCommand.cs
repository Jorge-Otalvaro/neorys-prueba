using MediatR;

namespace CuentaMovimientosMicroservicio.Application.Movimientos;

public record MovimientoRegisterCommand(
    int NumeroCuenta,
    decimal Valor,
    DateTime Fecha,
    string TipoMovimiento,
    decimal Monto
) : IRequest;