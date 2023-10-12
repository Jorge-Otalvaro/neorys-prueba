using AutoMapper;
using CuentaMovimientosMicroservicio.Domain.Dtos;
using CuentaMovimientosMicroservicio.Domain.Services;
using MediatR;

namespace CuentaMovimientosMicroservicio.Application.Movimientos;

public class ListaMovimientoQueryHandler : IRequestHandler<ListaMovimientoQuery, List<MovimientoDto>>
{
    readonly IMapper _mapper;
    readonly RecordMovimientoService _movimientoRepository;    

    public ListaMovimientoQueryHandler(IMapper mapper, RecordMovimientoService movimientoRepository) => (_mapper, _movimientoRepository) = (mapper, movimientoRepository);

    public async Task<List<MovimientoDto>> Handle(ListaMovimientoQuery request, CancellationToken cancellationToken)
    {
        var movimientos = await _movimientoRepository.ListarMovimientos(request.NumeroCuenta);
        return _mapper.Map<List<MovimientoDto>>(movimientos);
    }
}
