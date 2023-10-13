using ClientePersonaMicroservicio.Domain.Entities;

namespace ClientePersonaMicroservicio.Domain.Ports;

public interface IPersonaRepository
{
    Task<Persona> GetPersonaByIdAsync(int id);
    Task<IEnumerable<Persona>> GetPersonasAsync();
    Task<Persona> CreatePersonaAsync(Persona persona);
    Task<Persona> UpdatePersonaAsync(Persona persona);
    Task<Persona> DeletePersonaAsync(int id);
}   

