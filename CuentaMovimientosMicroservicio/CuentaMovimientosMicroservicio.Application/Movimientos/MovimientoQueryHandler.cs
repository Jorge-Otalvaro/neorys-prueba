using AutoMapper;
using CuentaMovimientosMicroservicio.Domain.Dtos;
using CuentaMovimientosMicroservicio.Domain.Services;
using MediatR;

namespace CuentaMovimientosMicroservicio.Application.Movimientos;

public class MovimientoQueryHandler : IRequestHandler<MovimientoQuery, MovimientoDto>
{
    readonly IMapper _mapper;
    readonly RecordMovimientoService _movimientoRepository;

    public MovimientoQueryHandler(IMapper mapper, RecordMovimientoService movimientoRepository) => (_mapper, _movimientoRepository) = (mapper, movimientoRepository);

    public async Task<MovimientoDto> Handle(MovimientoQuery request, CancellationToken cancellationToken)
    {
        var movimiento = await _movimientoRepository.ObtenerMovimiento(request.Id);
        return _mapper.Map<MovimientoDto>(movimiento);
    }
}
