using MediatR;

namespace CuentaMovimientosMicroservicio.Application.Movimientos;

public record MovimientoDeleteCommand(Guid Id) : IRequest;
