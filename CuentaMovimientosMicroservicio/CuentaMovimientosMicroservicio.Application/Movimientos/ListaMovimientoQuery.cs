using CuentaMovimientosMicroservicio.Domain.Dtos;
using MediatR;

namespace CuentaMovimientosMicroservicio.Application.Movimientos;

public record ListaMovimientoQuery(int NumeroCuenta) : IRequest<List<MovimientoDto>>;
