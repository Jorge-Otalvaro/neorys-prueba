using ClientePersonaMicroservicio.Domain.Entities;
using ClientePersonaMicroservicio.Domain.Ports;

namespace ClientePersonaMicroservicio.Domain.Services;

[DomainService]
public class RecordPersonaService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPersonaRepository _personaRepository;
    
    public RecordPersonaService(IPersonaRepository personaRepository, IUnitOfWork unitOfWork) => 
        (_personaRepository, _unitOfWork) = (personaRepository, unitOfWork);

    public async Task<Persona> GetPersonaByIdAsync(int id)
    {
        var persona = await _personaRepository.GetPersonaByIdAsync(id);        
        return persona;
    }

    public async Task<IEnumerable<Persona>> GetPersonasAsync()
    {
        return await _personaRepository.GetPersonasAsync();
    }

    public async Task<Persona> CreatePersonaAsync(Persona persona)
    {
        return await _personaRepository.CreatePersonaAsync(persona);
    }

    public async Task<Persona> UpdatePersonaAsync(Persona persona)
    {
        return await _personaRepository.UpdatePersonaAsync(persona);
    }

    public async Task<Persona> DeletePersonaAsync(int id)
    {
        return await _personaRepository.DeletePersonaAsync(id);
    }
}
