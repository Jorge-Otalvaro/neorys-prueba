using CuentaMovimientosMicroservicio.Domain.Dtos;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CuentaMovimientosMicroservicio.Application.Cuentas;

public record CuentaQuery([Required] int NumeroCuenta) : IRequest<CuentaDto>;
