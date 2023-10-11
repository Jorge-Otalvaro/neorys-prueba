namespace ClientePersonaMicroservicio.Domain.Entities;

public class Persona : DomainEntity
{    
    public required string Nombre { get; set; }
    public required string Genero { get; set; }
    public int Edad { get; set; }
    public required string Identificacion { get; set; }
    public string? Direccion { get; set; }
    public string? Telefono { get; set; }
}

