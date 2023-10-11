using AutoMapper;
using CuentaMovimientosMicroservicio.Domain.Dtos;
using CuentaMovimientosMicroservicio.Domain.Services;
using MediatR;

namespace CuentaMovimientosMicroservicio.Application.Cuentas;

public class CuentaQueryHandler : IRequestHandler<CuentaQuery, CuentaDto>
{
    readonly IMapper _mapper;
    readonly RecordCuentaService _recordCuentaService;

    public CuentaQueryHandler(RecordCuentaService recordCuentaService, IMapper mapper) =>
        (_recordCuentaService, _mapper) = (recordCuentaService, mapper);

    public async Task<CuentaDto> Handle(CuentaQuery request, CancellationToken cancellationToken)
    {
        var respuesta = await _recordCuentaService.ObtenerCuenta(request.NumeroCuenta);
        var cuenta = _mapper.Map<CuentaDto>(respuesta);
        return cuenta;
    }
}
