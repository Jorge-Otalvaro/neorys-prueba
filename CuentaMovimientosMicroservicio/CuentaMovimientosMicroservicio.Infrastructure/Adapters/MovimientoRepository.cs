using CuentaMovimientosMicroservicio.Domain.Entities;
using CuentaMovimientosMicroservicio.Domain.Exceptions;
using CuentaMovimientosMicroservicio.Domain.Ports;
using CuentaMovimientosMicroservicio.Infrastructure.DataSource;
using Microsoft.EntityFrameworkCore;

namespace CuentaMovimientosMicroservicio.Infrastructure.Adapters;

[Repository]
public class MovimientoRepository : IMovimientoRepository
{
    readonly DataContext _context;

    public MovimientoRepository(DataContext context) =>
        (_context) = (context);
    
    public async Task<List<Movimiento>> ListarMovimientos(int numeroCuenta)
    {
        // Obtiene la cuenta por número de cuenta o lanza una excepción si no existe.
        Cuenta cuenta = await ObtenerCuentaPorNumero(numeroCuenta);

        // Obtiene los movimientos de la cuenta.
        List<Movimiento> movimientos = await ObtenerMovimientosDeCuenta(cuenta);

        return movimientos;
    }

    private async Task<Cuenta> ObtenerCuentaPorNumero(int numeroCuenta)
    {
        Cuenta cuenta = await _context.Cuentas.FirstOrDefaultAsync(c => c.NumeroCuenta == numeroCuenta) ?? throw new InvalidOperationException("La cuenta no existe");        
        return cuenta;
    }

    private async Task<List<Movimiento>> ObtenerMovimientosDeCuenta(Cuenta cuenta)
    {
        List<Movimiento> movimientos = await _context.Movimientos
            .Where(m => m.CuentaId == cuenta.Id)
            .Select(m => new Movimiento
            {
                Id = m.Id,
                NumeroCuenta = cuenta.NumeroCuenta,
                TipoMovimiento = m.TipoMovimiento,
                Valor = m.Valor,
                Saldo = m.Saldo,
                Fecha = m.Fecha
            })
            .ToListAsync();

        return movimientos;
    }

    public async Task<Movimiento> ObtenerMovimiento(Guid uid)
    {
        Movimiento movimiento = await ObtenerCuentaMovimiento(uid);

        return movimiento;
    }

    public async Task<Movimiento> RegistrarMovimiento(Movimiento movimiento)
    {
        Cuenta cuenta = await ObtenerCuentaPorNumero(movimiento.NumeroCuenta);
        
        if(movimiento.TipoMovimiento == TipoMovimiento.Debito && movimiento.Valor > cuenta.SaldoInicial)
        {
            throw new UnderAgeException("Saldo no disponible");
        }

        if(movimiento.TipoMovimiento == TipoMovimiento.Credito && movimiento.Valor <= 0)
        {
            throw new UnderAgeException("El valor del crédito debe ser mayor a 0");
        }
        
        try
        {
            Movimiento movimientoCreada = new()
            {
                Fecha = DateTime.UtcNow,
                TipoMovimiento = movimiento.TipoMovimiento,
                Valor = movimiento.Valor,
                Saldo = movimiento.TipoMovimiento == TipoMovimiento.Credito ? cuenta.SaldoInicial + movimiento.Valor : cuenta.SaldoInicial - movimiento.Valor,
                CuentaId = cuenta.Id,                
            };

            // Registro del movimiento
            _context.Entry(movimientoCreada).State = EntityState.Added;
            _context.Movimientos.Add(movimientoCreada);

            cuenta.SaldoInicial = movimiento.TipoMovimiento == TipoMovimiento.Credito ? cuenta.SaldoInicial + movimiento.Valor : cuenta.SaldoInicial - movimiento.Valor;

            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            var innerException = ex.InnerException;
            while (innerException != null)
            {
                Console.WriteLine(innerException.Message);
                innerException = innerException.InnerException;
            }
            throw;
        }

        return movimiento;
    }

    public async Task<Movimiento> ActualizarMovimiento(Movimiento movimiento)
    {
        Movimiento movi = await ObtenerCuentaMovimiento(movimiento.Id);

        if(movi.TipoMovimiento == TipoMovimiento.Debito && movimiento.Valor > movi.Saldo)
        {
            throw new UnderAgeException("Saldo no disponible");
        }

        if(movi.TipoMovimiento == TipoMovimiento.Credito && movimiento.Valor <= 0)
        {
            throw new UnderAgeException("El valor del crédito debe ser mayor a 0");
        }

        Cuenta cuenta = await ObtenerCuentaPorNumero(movimiento.NumeroCuenta);

        cuenta.SaldoInicial = movimiento.TipoMovimiento == TipoMovimiento.Credito ? cuenta.SaldoInicial + movimiento.Valor : cuenta.SaldoInicial - movimiento.Valor;        
        cuenta.LastModifiedOn = DateTime.UtcNow;
        
        movi.Valor = movimiento.Valor;
        movi.Saldo = movimiento.TipoMovimiento == TipoMovimiento.Credito ? cuenta.SaldoInicial + movimiento.Valor : cuenta.SaldoInicial - movimiento.Valor;
        movi.LastModifiedOn = DateTime.UtcNow;
        movi.CuentaId = cuenta.Id;

        _context.Entry(movi).State = EntityState.Modified;
       
        Movimiento nuevoMovimiento = new()
        {
            Fecha = DateTime.UtcNow,
            TipoMovimiento = movimiento.TipoMovimiento,
            Valor = movimiento.Valor,
            Saldo = cuenta.SaldoInicial,
            CuentaId = cuenta.Id,
        };

        // Registro del movimiento
        _context.Entry(nuevoMovimiento).State = EntityState.Added;
        _context.Movimientos.Add(nuevoMovimiento);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            var innerException = ex.InnerException;
            while (innerException != null)
            {
                Console.WriteLine(innerException.Message);
                innerException = innerException.InnerException;
            }
            throw;
        }

        return movimiento;
    }

    public async Task EliminarMovimiento(Guid IdMovimiento)
    {
        Movimiento movimiento = await ObtenerCuentaMovimiento(IdMovimiento);
        _context.Entry(movimiento).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
    }

    private async Task<Movimiento> ObtenerCuentaMovimiento(Guid IdMovimiento)
    {
        Movimiento movimiento = await _context.Movimientos.Join(_context.Cuentas,
        movimiento => movimiento.CuentaId,
        cuenta => cuenta.Id,
        (movimiento, cuenta) => new Movimiento
        {
            Id = movimiento.Id,
            NumeroCuenta = cuenta.NumeroCuenta,            
            Valor = movimiento.Valor,
            Saldo = movimiento.Saldo,
            Fecha = movimiento.Fecha,
        }).FirstOrDefaultAsync(m => m.Id == IdMovimiento) ?? throw new InvalidOperationException("El movimiento no existe");

        return movimiento;
    }

    public async Task<List<Movimiento>> ListarTodosLosMovimientos()
    {
        try
        {
            List<Movimiento> movimientos = await _context.Movimientos.Join(_context.Cuentas,
            movimiento => movimiento.CuentaId,
            cuenta => cuenta.Id,
            (movimiento, cuenta) => new Movimiento
            {
                Id = movimiento.Id,
                CuentaId = cuenta.Id,
                NumeroCuenta = cuenta.NumeroCuenta,                
                Valor = movimiento.Valor,
                Saldo = movimiento.Saldo,
                Fecha = movimiento.Fecha,
            }).ToListAsync();

            return movimientos;
        }
        catch (DbUpdateException ex)
        {
            var innerException = ex.InnerException;
            while (innerException != null)
            {
                Console.WriteLine(innerException.Message);
                innerException = innerException.InnerException;
            }
            throw;
        }        
    }
}