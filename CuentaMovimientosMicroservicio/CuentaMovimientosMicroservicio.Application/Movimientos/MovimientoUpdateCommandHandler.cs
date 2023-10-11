using CuentaMovimientosMicroservicio.Domain.Entities;
using CuentaMovimientosMicroservicio.Domain.Services;
using MediatR;

namespace CuentaMovimientosMicroservicio.Application.Movimientos;

public class MovimientoUpdateCommandHandler : IRequestHandler<MovimientoUpdateCommand>
{
    readonly RecordMovimientoService _movimientoRepository;

    public MovimientoUpdateCommandHandler(RecordMovimientoService movimientoRepository) => _movimientoRepository = movimientoRepository;

    public async Task<Unit> Handle(MovimientoUpdateCommand request, CancellationToken cancellationToken)
    {
        Movimiento movimiento = await _movimientoRepository.ObtenerMovimiento(request.Id);        
        await _movimientoRepository.ActualizarMovimiento(movimiento, cancellationToken);
        return Unit.Value;
    }
}
