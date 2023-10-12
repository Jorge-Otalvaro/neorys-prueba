using CuentaMovimientosMicroservicio.Domain.Entities;
using CuentaMovimientosMicroservicio.Domain.Ports;
using CuentaMovimientosMicroservicio.Infrastructure.DataSource;
using Microsoft.EntityFrameworkCore;

namespace CuentaMovimientosMicroservicio.Infrastructure.Adapters;

[Repository]
public class CuentaRepository : ICuentaRepository
{    
    readonly DataContext _context;

    public CuentaRepository(DataContext context) =>
        (_context) = (context);

    public async Task<Cuenta> ObtenerCuenta(int numeroCuenta)
    {
        Cuenta cuenta = await _context.Cuentas.Join(_context.Personas,
        cuenta => cuenta.ClienteId,
        cliente => cliente.Id,
        (cuenta, cliente) => new Cuenta
        {
            NumeroCuenta = cuenta.NumeroCuenta,
            TipoCuenta = cuenta.TipoCuenta,
            SaldoInicial = cuenta.SaldoInicial,
            Estado = cuenta.Estado,
            Cliente = cliente.Nombre
        }).FirstOrDefaultAsync(c => c.NumeroCuenta == numeroCuenta) ?? throw new InvalidOperationException("La cuenta no existe");

        return cuenta;
    }

    public async Task<IEnumerable<Cuenta>> ListarCuentas()
    {
        List<Cuenta> cuentas = await _context.Cuentas.Join(_context.Personas,
            cuenta => cuenta.ClienteId,
            cliente => cliente.Id,
            (cuenta, cliente) => new Cuenta
            {
                NumeroCuenta = cuenta.NumeroCuenta,
                TipoCuenta = cuenta.TipoCuenta,
                SaldoInicial = cuenta.SaldoInicial,
                Estado = cuenta.Estado,
                Cliente = cliente.Nombre
            }).ToListAsync();

        return cuentas;
    }

    public async Task<Cuenta> CrearCuenta(Cuenta cuenta)
    {
        var cuentaExistente = await _context.Cuentas.FirstOrDefaultAsync(c => c.NumeroCuenta == cuenta.NumeroCuenta);
        if (cuentaExistente != null)
        {
            throw new InvalidOperationException("La cuenta ya existe");
        }

        Persona cliente = await _context.Personas.FirstOrDefaultAsync(c => c.Id == cuenta.ClienteId) ?? throw new InvalidOperationException("El cliente no existe");
        cuenta.Cliente = cliente.Nombre;
        cuenta.Estado = true;
        _context.Entry(cuenta).State = EntityState.Added;
        _context.Cuentas.Add(cuenta);
        await _context.SaveChangesAsync();

        return cuenta;
    }

    public async Task<Cuenta> ActualizarCuenta(Cuenta cuentaUpdate)
    {        
        Cuenta cuentaExistente = await _context.Cuentas.Join(_context.Personas,
        cuenta => cuenta.ClienteId,
        cliente => cliente.Id,
        (cuenta, cliente) => new Cuenta
        {
            Id = cuenta.Id,
            ClienteId = cuenta.ClienteId,
            NumeroCuenta = cuenta.NumeroCuenta,
            TipoCuenta = cuenta.TipoCuenta,
            SaldoInicial = cuenta.SaldoInicial,
            Estado = cuenta.Estado,
            Cliente = cliente.Nombre
        }).FirstOrDefaultAsync(c => c.NumeroCuenta == cuentaUpdate.NumeroCuenta) ?? throw new InvalidOperationException("La cuenta no existe");

        _context.Entry(cuentaExistente).State = EntityState.Detached;

        cuentaExistente.TipoCuenta = cuentaUpdate.TipoCuenta ?? cuentaExistente.TipoCuenta;
        cuentaExistente.Estado = cuentaUpdate.Estado;
        cuentaExistente.LastModifiedOn = DateTime.UtcNow;

        _context.Entry(cuentaExistente).State = EntityState.Modified;        
        await _context.SaveChangesAsync();

        return cuentaExistente;
    }

    public async Task EliminarCuenta(Guid IdCuenta)
    {
        Cuenta cuenta = await _context.Cuentas.FirstOrDefaultAsync(c => c.Id == IdCuenta) ?? throw new InvalidOperationException("La cuenta no existe");
        _context.Entry(cuenta).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
    }

    public async Task<Cuenta> ConsultarCuenta(Guid IdCuenta)
    {
        return await _context.Cuentas.FirstOrDefaultAsync(c => c.Id == IdCuenta) ?? throw new InvalidOperationException("La cuenta no existe");
    }
}
