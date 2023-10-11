using CuentaMovimientosMicroservicio.Domain.Entities;
using CuentaMovimientosMicroservicio.Domain.Ports;
using CuentaMovimientosMicroservicio.Infrastructure.Ports;

namespace CuentaMovimientosMicroservicio.Infrastructure.Adapters;

[Repository]
public class MovimientoRepository : IMovimientoRepository
{
    readonly IRepository<Movimiento> _dataSource;

    public MovimientoRepository(IRepository<Movimiento> dataSource) => _dataSource = dataSource 
        ?? throw new ArgumentNullException(nameof(dataSource));

    public async Task<Movimiento> RegistrarMovimiento(Movimiento movimiento) => await _dataSource.AddAsync(movimiento);

    public async Task<List<Movimiento>> ListarMovimientos(int numeroCuenta) => await _dataSource.WhereAsync(m => m.NumeroCuenta == numeroCuenta);

    public async Task<Movimiento> ObtenerMovimiento(Guid uid) => await _dataSource.FirstOrDefaultAsync(m => m.Id == uid);

    public async Task<Movimiento> ActualizarMovimiento(Movimiento movimiento)
    {
        _dataSource.UpdateAsync(movimiento);
        return await _dataSource.FirstOrDefaultAsync(m => m.Id == movimiento.Id);
    }

    public async Task EliminarMovimiento(Guid uid)
    {
        var movimiento = await _dataSource.FirstOrDefaultAsync(m => m.Id == uid);
        _dataSource.DeleteAsync(movimiento);        
    }

    public async Task<List<Movimiento>> ListarTodosLosMovimientos() => await _dataSource.ToListAsync();
}
