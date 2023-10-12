using CuentaMovimientosMicroservicio.Domain.Entities;
using CuentaMovimientosMicroservicio.Domain.Ports;

namespace CuentaMovimientosMicroservicio.Domain.Services;

[DomainService]
public class RecordCuentaService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICuentaRepository _cuentaRepository;    

    public RecordCuentaService(IUnitOfWork unitOfWork, ICuentaRepository cuentaRepository) =>
        (_unitOfWork, _cuentaRepository) = (unitOfWork, cuentaRepository);

    // Listar Cuentas
    public async Task<IEnumerable<Cuenta>> ListarCuentas()
    {        
        IEnumerable<Cuenta> cuentas = await _cuentaRepository.ListarCuentas();
        return cuentas;
    }

    // Obtener Cuenta por ID
    public async Task<Cuenta> ObtenerCuenta(int numeroCuenta)
    {
        Cuenta cuenta = await _cuentaRepository.ObtenerCuenta(numeroCuenta);
        return cuenta;
    }

    // Crear Cuenta
    public async Task<Cuenta> RegistrarCuenta(Cuenta cuenta, CancellationToken? cancellationToken = null)
    {        
        CancellationToken token = cancellationToken ?? new CancellationTokenSource().Token;
        var cuentaRegistrada = await _cuentaRepository.CrearCuenta(cuenta);        
        await _unitOfWork.SaveAsync(token);
        return cuentaRegistrada;
    }

    // Actualizar Cuenta
    public async Task<Cuenta> ActualizarCuenta(Cuenta cuenta, CancellationToken? cancellationToken = null)
    {
        CancellationToken token = cancellationToken ?? new CancellationTokenSource().Token;
        Cuenta cuentaActualizada = await _cuentaRepository.ActualizarCuenta(cuenta);
        await _unitOfWork.SaveAsync(token);
        return cuentaActualizada;
    }

    // Eliminar Cuenta
    public async Task<bool> EliminarCuenta(Guid IdCuenta, CancellationToken? cancellationToken = null)
    {
        CancellationToken token = cancellationToken ?? new CancellationTokenSource().Token;
        var cuenta = await _cuentaRepository.ConsultarCuenta(IdCuenta);
        await _cuentaRepository.EliminarCuenta(cuenta.Id);
        await _unitOfWork.SaveAsync(token);
        return true;
    }
}
