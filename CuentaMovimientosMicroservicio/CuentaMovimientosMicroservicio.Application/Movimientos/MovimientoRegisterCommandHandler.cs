using AutoMapper;
using CuentaMovimientosMicroservicio.Domain.Entities;
using CuentaMovimientosMicroservicio.Domain.Services;
using MediatR;

namespace CuentaMovimientosMicroservicio.Application.Movimientos;

public class MovimientoRegisterCommandHandler : IRequestHandler<MovimientoRegisterCommand>
{
    readonly IMapper _mapper;
    readonly RecordMovimientoService _movimientoRepository;
    
    public MovimientoRegisterCommandHandler(IMapper mapper, RecordMovimientoService movimientoRepository) =>
        (_mapper, _movimientoRepository) = (mapper, movimientoRepository);

    public async Task<Unit> Handle(MovimientoRegisterCommand request, CancellationToken cancellationToken)
    {        
        Movimiento movimiento = _mapper.Map<Movimiento>(request);
        await _movimientoRepository.RegistrarMovimiento(movimiento);
        return Unit.Value;
    }
}
