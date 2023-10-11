using AutoMapper;
using CuentaMovimientosMicroservicio.Domain.Entities;
using CuentaMovimientosMicroservicio.Domain.Services;
using MediatR;

namespace CuentaMovimientosMicroservicio.Application.Cuentas;

public class CuentaUpdateCommandHandler : IRequestHandler<CuentaUpdateCommand>
{
    readonly RecordCuentaService _recordCuentaService;
    readonly IMapper _mapper;

    public CuentaUpdateCommandHandler(RecordCuentaService recordCuentaService, IMapper mapper) =>
        (_recordCuentaService, _mapper) = (recordCuentaService, mapper);

    public async Task<Unit> Handle(CuentaUpdateCommand request, CancellationToken cancellationToken)
    {
        var cuenta = _mapper.Map<Cuenta>(request);
        await _recordCuentaService.ActualizarCuenta(cuenta);
        return Unit.Value;
    }
}
