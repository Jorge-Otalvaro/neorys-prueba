using CuentaMovimientosMicroservicio.Domain.Services;
using MediatR;

namespace CuentaMovimientosMicroservicio.Application.Cuentas;

public class CuentaDeleteCommandHandler : IRequestHandler<CuentaDeleteCommand>
{
    readonly RecordCuentaService _recordCuentaService;

    public CuentaDeleteCommandHandler(RecordCuentaService recordCuentaService) => _recordCuentaService = recordCuentaService;

    public async Task<Unit> Handle(CuentaDeleteCommand request, CancellationToken cancellationToken)
    {
        await _recordCuentaService.EliminarCuenta(request.IdCuenta);
        return Unit.Value;
    }
}
