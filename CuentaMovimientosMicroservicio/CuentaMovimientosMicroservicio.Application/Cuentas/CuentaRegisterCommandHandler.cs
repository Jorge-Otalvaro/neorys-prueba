using AutoMapper;
using CuentaMovimientosMicroservicio.Domain.Dtos;
using CuentaMovimientosMicroservicio.Domain.Entities;
using CuentaMovimientosMicroservicio.Domain.Services;
using MediatR;

namespace CuentaMovimientosMicroservicio.Application.Cuentas;

public class CuentaRegisterCommandHandler : IRequestHandler<CuentaRegisterCommand, CuentaDto>
{
    readonly RecordCuentaService _recordCuentaService;
    readonly IMapper _mapper;

    public CuentaRegisterCommandHandler(RecordCuentaService recordCuentaService, IMapper mapper) =>
        (_recordCuentaService, _mapper) = (recordCuentaService, mapper);

    public async Task<CuentaDto> Handle(CuentaRegisterCommand request, CancellationToken cancellationToken)
    {
        Cuenta cuenta = _mapper.Map<Cuenta>(request);
        var cuentaRegistrada = await _recordCuentaService.RegistrarCuenta(cuenta);
        return _mapper.Map<CuentaDto>(cuentaRegistrada);        
    }
}
