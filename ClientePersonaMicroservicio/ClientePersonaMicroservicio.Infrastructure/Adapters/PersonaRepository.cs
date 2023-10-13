using ClientePersonaMicroservicio.Domain.Entities;
using ClientePersonaMicroservicio.Domain.Ports;
using ClientePersonaMicroservicio.Infrastructure.DataSource;
using Microsoft.EntityFrameworkCore;

namespace ClientePersonaMicroservicio.Infrastructure.Adapters;

[Repository]
public class PersonaRepository : IPersonaRepository
{
    readonly DataContext _context;

    public PersonaRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Persona> GetPersonaByIdAsync(int id)
    {
        return await _context.Personas.FindAsync(id);
    }

    public async Task<IEnumerable<Persona>> GetPersonasAsync()
    {
        return await _context.Personas.ToListAsync();
    }

    public async Task<Persona> CreatePersonaAsync(Persona persona)
    {
        _context.Personas.Add(persona);
        await _context.SaveChangesAsync();
        return persona;
    }

    public async Task<Persona> UpdatePersonaAsync(Persona persona)
    {
        _context.Entry(persona).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return persona;
    }

    public async Task<Persona> DeletePersonaAsync(int id)
    {
        var persona = await _context.Personas.FindAsync(id);
        _context.Personas.Remove(persona);
        await _context.SaveChangesAsync();
        return persona;
    }
}
