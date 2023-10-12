using MediatR;

namespace CuentaMovimientosMicroservicio.Application.Movimientos;

public record MovimientoRegisterCommand(
    string TipoMovimiento,
    int NumeroCuenta,
    decimal Valor
) : IRequest;