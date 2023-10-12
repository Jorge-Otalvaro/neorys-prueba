using AutoMapper;
using CuentaMovimientosMicroservicio.Domain.Dtos;
using CuentaMovimientosMicroservicio.Domain.Services;
using MediatR;

namespace CuentaMovimientosMicroservicio.Application.Movimientos;

public class ListMovimientosQueryHandler : IRequestHandler<ListMovimientosQuery, List<MovimientoDto>>
{
    readonly IMapper _mapper;
    readonly RecordMovimientoService _movimientoRepository;

    public ListMovimientosQueryHandler(IMapper mapper, RecordMovimientoService movimientoRepository) => (_mapper, _movimientoRepository) = (mapper, movimientoRepository);

    public async Task<List<MovimientoDto>> Handle(ListMovimientosQuery request, CancellationToken cancellationToken)
    {
        var movimientos = await _movimientoRepository.ListarTodosLosMovimientos();        
        return _mapper.Map<List<MovimientoDto>>(movimientos);
    }
}
