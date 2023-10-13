using ClientePersonaMicroservicio.Domain.Entities;

namespace ClientePersonaMicroservicio.Domain.Ports;

public interface IClienteRepository
{
    Task<Cliente> GetClienteByIdAsync(int id);
    Task<IEnumerable<Cliente>> GetClientesAsync();
    Task<Cliente> CreateClienteAsync(Cliente cliente);
    Task<Cliente> UpdateClienteAsync(Cliente cliente);
    Task<Cliente> DeleteClienteAsync(int id);
}

