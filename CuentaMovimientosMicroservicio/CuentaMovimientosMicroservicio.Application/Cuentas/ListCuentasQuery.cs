using CuentaMovimientosMicroservicio.Domain.Dtos;
using MediatR;

namespace CuentaMovimientosMicroservicio.Application.Cuentas;

public record ListCuentasQuery() : IRequest<List<CuentaDto>>;
