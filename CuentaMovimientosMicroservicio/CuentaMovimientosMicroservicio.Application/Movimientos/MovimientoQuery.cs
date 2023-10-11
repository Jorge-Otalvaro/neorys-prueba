using CuentaMovimientosMicroservicio.Domain.Dtos;
using MediatR;

namespace CuentaMovimientosMicroservicio.Application.Movimientos;

public record MovimientoQuery(Guid Id) : IRequest<MovimientoDto>;
