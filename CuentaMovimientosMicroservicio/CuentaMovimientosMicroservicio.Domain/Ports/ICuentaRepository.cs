using CuentaMovimientosMicroservicio.Domain.Entities;

namespace CuentaMovimientosMicroservicio.Domain.Ports;

public interface ICuentaRepository
{
    Task<Cuenta> ObtenerCuenta(int numeroCuenta);
    
    Task<IEnumerable<Cuenta>> ListarCuentas();

    Task<Cuenta> CrearCuenta(Cuenta cuenta);

    Task<Cuenta> ActualizarCuenta(Cuenta cuenta);

    Task EliminarCuenta(Guid IdCuenta);

    Task<Cuenta> ConsultarCuenta(Guid IdCuenta);
}