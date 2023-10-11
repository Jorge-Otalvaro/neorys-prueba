using CuentaMovimientosMicroservicio.Domain.Entities;
using CuentaMovimientosMicroservicio.Domain.Ports;
using CuentaMovimientosMicroservicio.Infrastructure.Ports;

namespace CuentaMovimientosMicroservicio.Infrastructure.Adapters;

[Repository]
public class CuentaRepository : ICuentaRepository
{
    readonly IRepository<Cuenta> _dataSource;

    public CuentaRepository(IRepository<Cuenta> dataSource) => _dataSource = dataSource 
        ?? throw new ArgumentNullException(nameof(dataSource));

    public async Task<Cuenta> ObtenerCuenta(int numeroCuenta) => await _dataSource.FirstOrDefaultAsync(c => c.NumeroCuenta == numeroCuenta);

    public async Task<IEnumerable<Cuenta>> ListarCuentas() => await _dataSource.ToListAsync();

    public async Task<Cuenta> CrearCuenta(Cuenta cuenta) => await _dataSource.AddAsync(cuenta);

    public async Task<Cuenta> ActualizarCuenta(Cuenta cuenta)
    {
        _dataSource.UpdateAsync(cuenta);
        return await _dataSource.FirstOrDefaultAsync(c => c.NumeroCuenta == cuenta.NumeroCuenta);
    }

    public async Task EliminarCuenta(Guid IdCuenta)
    {
        var cuenta = await _dataSource.FirstOrDefaultAsync(c => c.Id == IdCuenta);
        _dataSource.DeleteAsync(cuenta);
    }

    public async Task<Cuenta> ConsultarCuenta(Guid IdCuenta) => await _dataSource.FirstOrDefaultAsync(c => c.Id == IdCuenta);
}
