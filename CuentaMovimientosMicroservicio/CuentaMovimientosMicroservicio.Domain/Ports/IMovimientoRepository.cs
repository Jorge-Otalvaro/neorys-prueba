using CuentaMovimientosMicroservicio.Domain.Entities;

namespace CuentaMovimientosMicroservicio.Domain.Ports;

public interface IMovimientoRepository
{
    Task<Movimiento> RegistrarMovimiento(Movimiento movimiento);
    Task<List<Movimiento>> ListarMovimientos(int numeroCuenta);
    Task<Movimiento> ObtenerMovimiento(Guid uid);
    Task<Movimiento> ActualizarMovimiento(Movimiento movimiento);
    Task EliminarMovimiento(Guid uid);
    Task<List<Movimiento>> ListarTodosLosMovimientos();
}
