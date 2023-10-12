using MediatR;

namespace CuentaMovimientosMicroservicio.Application.Movimientos;

public record MovimientoUpdateCommand(
    Guid Id,
    int NumeroCuenta,
    decimal Valor,
    string TipoMovimiento    
) : IRequest;
