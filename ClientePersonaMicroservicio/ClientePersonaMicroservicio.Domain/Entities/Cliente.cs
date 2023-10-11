namespace ClientePersonaMicroservicio.Domain.Entities;

public class Cliente : Persona
{
    public int ClienteId { get; set; }
    public required string Contrasena { get; set; }
    public bool Estado { get; set; }
}