using CuentaMovimientosMicroservicio.Domain.Dtos;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CuentaMovimientosMicroservicio.Application.Cuentas;

public record CuentaUpdateCommand([Required] int NumeroCuenta, bool Estado, string TipoCuenta) : IRequest<CuentaDto>;
