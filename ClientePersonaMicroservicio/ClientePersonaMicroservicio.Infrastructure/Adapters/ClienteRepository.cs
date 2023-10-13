using ClientePersonaMicroservicio.Domain.Entities;
using ClientePersonaMicroservicio.Domain.Ports;
using ClientePersonaMicroservicio.Infrastructure.DataSource;
using Microsoft.EntityFrameworkCore;

namespace ClientePersonaMicroservicio.Infrastructure.Adapters;

[Repository]
public class ClienteRepository : IClienteRepository
{
    readonly DataContext _context;

    public ClienteRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Cliente> GetClienteByIdAsync(int id)
    {
        return await _context.Clientes.FindAsync(id);
    }

    public async Task<IEnumerable<Cliente>> GetClientesAsync()
    {
        return await _context.Clientes.ToListAsync();
    }

    public async Task<Cliente> CreateClienteAsync(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
        return cliente;
    }

    public async Task<Cliente> UpdateClienteAsync(Cliente cliente)
    {
        _context.Entry(cliente).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return cliente;
    }

    public async Task<Cliente> DeleteClienteAsync(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();
        return cliente;
    }
}
