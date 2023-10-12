using AutoMapper;
using CuentaMovimientosMicroservicio.Domain.Dtos;
using CuentaMovimientosMicroservicio.Domain.Entities;
using CuentaMovimientosMicroservicio.Domain.Services;
using MediatR;

namespace CuentaMovimientosMicroservicio.Application.Cuentas;

public class CuentaUpdateCommandHandler : IRequestHandler<CuentaUpdateCommand, CuentaDto>
{
    readonly RecordCuentaService _recordCuentaService;
    readonly IMapper _mapper;

    public CuentaUpdateCommandHandler(RecordCuentaService recordCuentaService, IMapper mapper) =>
        (_recordCuentaService, _mapper) = (recordCuentaService, mapper);

    public async Task<CuentaDto> Handle(CuentaUpdateCommand request, CancellationToken cancellationToken)
    {
        Cuenta cuenta = _mapper.Map<Cuenta>(request);
        Cuenta cuentaActualizada = await _recordCuentaService.ActualizarCuenta(cuenta);
        CuentaDto cuentaResponse = _mapper.Map<CuentaDto>(cuentaActualizada);
        return cuentaResponse;
    }
}
