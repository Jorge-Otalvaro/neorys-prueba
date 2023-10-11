using CuentaMovimientosMicroservicio.Domain.Entities;
using CuentaMovimientosMicroservicio.Domain.Ports;

namespace CuentaMovimientosMicroservicio.Domain.Services;

[DomainService]
public class RecordMovimientoService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMovimientoRepository _movimientoRepository;    

    public RecordMovimientoService(IUnitOfWork unitOfWork, IMovimientoRepository movimientoRepository) => (_unitOfWork, _movimientoRepository) = (unitOfWork, movimientoRepository);

    // Listar Movimientos de una Cuenta
    public async Task<IEnumerable<Movimiento>> ListarMovimientos(int numeroCuenta)
    {
        return await _movimientoRepository.ListarMovimientos(numeroCuenta);
    }

    // Obtener Movimiento por ID
    public async Task<Movimiento> ObtenerMovimiento(Guid id)
    {
        return await _movimientoRepository.ObtenerMovimiento(id);
    }

    // Crear Movimiento
    public async Task<bool> RegistrarMovimiento(Movimiento movimiento, CancellationToken? cancellationToken = null)
    {
        CancellationToken token = cancellationToken ?? new CancellationTokenSource().Token;        
        await _movimientoRepository.RegistrarMovimiento(movimiento);
        await _unitOfWork.SaveAsync(token);
        return true;
    }

    // Actualizar Movimiento
    public async Task<bool> ActualizarMovimiento(Movimiento movimiento, CancellationToken? cancellationToken = null)
    {
        CancellationToken token = cancellationToken ?? new CancellationTokenSource().Token;        
        await _movimientoRepository.ActualizarMovimiento(movimiento);
        await _unitOfWork.SaveAsync(token);
        return true;
    }

    // Eliminar Movimiento
    public async Task<bool> EliminarMovimiento(Guid id, CancellationToken? cancellationToken = null)
    {
        CancellationToken token = cancellationToken ?? new CancellationTokenSource().Token;        
        await _movimientoRepository.EliminarMovimiento(id);
        await _unitOfWork.SaveAsync(token);
        return true;
    }

    // Listar todos los Movimientos
    public async Task<IEnumerable<Movimiento>> ListarTodosLosMovimientos()
    {
        return await _movimientoRepository.ListarTodosLosMovimientos();
    }
}
