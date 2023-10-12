using AutoMapper;
using CuentaMovimientosMicroservicio.Domain.Entities;
using CuentaMovimientosMicroservicio.Domain.Services;
using MediatR;

namespace CuentaMovimientosMicroservicio.Application.Movimientos;

public class MovimientoUpdateCommandHandler : IRequestHandler<MovimientoUpdateCommand>
{
    readonly IMapper _mapper;
    readonly RecordMovimientoService _movimientoRepository;

    public MovimientoUpdateCommandHandler(RecordMovimientoService movimientoRepository, IMapper mapper) =>
        (_movimientoRepository, _mapper) = (movimientoRepository, mapper);

    public async Task<Unit> Handle(MovimientoUpdateCommand request, CancellationToken cancellationToken)
    {
        Movimiento movimientoExistente = await _movimientoRepository.ObtenerMovimiento(request.Id) ?? throw new InvalidOperationException("El movimiento no existe");
        Movimiento movimiento = _mapper.Map<Movimiento>(request);
        await _movimientoRepository.ActualizarMovimiento(movimiento, cancellationToken);
        return Unit.Value;
    }
}
