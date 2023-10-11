using AutoMapper;
using CuentaMovimientosMicroservicio.Domain.Dtos;
using CuentaMovimientosMicroservicio.Domain.Entities;
using CuentaMovimientosMicroservicio.Domain.Services;
using MediatR;

namespace CuentaMovimientosMicroservicio.Application.Cuentas;

public class ListCuentasQueryHandler : IRequestHandler<ListCuentasQuery, List<CuentaDto>>
{
    private readonly RecordCuentaService _recordCuentaService;
    readonly IMapper _mapper;

    public ListCuentasQueryHandler(RecordCuentaService recordCuentaService, IMapper mapper) =>
        (_recordCuentaService, _mapper) = (recordCuentaService, mapper);

    public async Task<List<CuentaDto>> Handle(ListCuentasQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Cuenta> cuentas = await _recordCuentaService.ListarCuentas();
        List<CuentaDto> cuentasDto = _mapper.Map<List<CuentaDto>>(cuentas);
        return cuentasDto;
    }
}
