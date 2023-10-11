using CuentaMovimientosMicroservicio.Domain.Dtos;
using MediatR;

namespace CuentaMovimientosMicroservicio.Application.Movimientos;

public record ListMovimientosQuery() : IRequest<List<MovimientoDto>>;