using MediatR;

namespace CuentaMovimientosMicroservicio.Application.Cuentas;

public record CuentaUpdateCommand(int NumeroCuenta, string TipoCuenta) : IRequest;
