using AutoMapper;
using CuentaMovimientosMicroservicio.Domain.Entities;
using CuentaMovimientosMicroservicio.Domain.Services;
using MediatR;

namespace CuentaMovimientosMicroservicio.Application.Cuentas;

public class CuentaRegisterCommandHandler : IRequestHandler<CuentaRegisterCommand>
{
    readonly RecordCuentaService _recordCuentaService;
    readonly IMapper _mapper;

    public CuentaRegisterCommandHandler(RecordCuentaService recordCuentaService, IMapper mapper) =>
        (_recordCuentaService, _mapper) = (recordCuentaService, mapper);

    public async Task<Unit> Handle(CuentaRegisterCommand request, CancellationToken cancellationToken)
    {
        var cuenta = _mapper.Map<Cuenta>(request);
        await _recordCuentaService.RegistrarCuenta(cuenta);
        return Unit.Value;
    }
}
