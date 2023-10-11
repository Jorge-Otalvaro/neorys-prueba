using CuentaMovimientosMicroservicio.Domain.Services;
using MediatR;

namespace CuentaMovimientosMicroservicio.Application.Movimientos;

public class MovimientoDeleteCommandHandler : IRequestHandler<MovimientoDeleteCommand>
{
    readonly RecordMovimientoService _movimientoRepository;

    public MovimientoDeleteCommandHandler(RecordMovimientoService movimientoRepository) => _movimientoRepository = movimientoRepository;

    public async Task<Unit> Handle(MovimientoDeleteCommand request, CancellationToken cancellationToken)
    {
        await _movimientoRepository.EliminarMovimiento(request.Id);
        return Unit.Value;
    }
}
