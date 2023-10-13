using ClientePersonaMicroservicio.Domain.Entities;
using ClientePersonaMicroservicio.Domain.Ports;

namespace ClientePersonaMicroservicio.Domain.Services;

[DomainService]
public class RecordClienteService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClienteRepository _clienteRepository;
    
    public RecordClienteService(IClienteRepository clienteRepository, IUnitOfWork unitOfWork) => 
        (_clienteRepository, _unitOfWork) = (clienteRepository, unitOfWork);

    public async Task<Cliente> GetClienteByIdAsync(int id)
    {
        var cliente = await _clienteRepository.GetClienteByIdAsync(id);        
        return cliente;
    }

    public async Task<IEnumerable<Cliente>> GetClientesAsync()
    {
        return await _clienteRepository.GetClientesAsync();
    }

    public async Task<Cliente> CreateClienteAsync(Cliente cliente)
    {
        return await _clienteRepository.CreateClienteAsync(cliente);
    } 

    public async Task<Cliente> UpdateClienteAsync(Cliente cliente)
    {
        return await _clienteRepository.UpdateClienteAsync(cliente);
    }

    public async Task<Cliente> DeleteClienteAsync(int id)
    {
        return await _clienteRepository.DeleteClienteAsync(id);
    }
}
