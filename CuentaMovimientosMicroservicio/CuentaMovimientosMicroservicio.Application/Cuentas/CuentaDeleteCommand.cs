using MediatR;

namespace CuentaMovimientosMicroservicio.Application.Cuentas;

public record CuentaDeleteCommand(Guid IdCuenta) : IRequest;
