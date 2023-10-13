namespace ClientePersonaMicroservicio.Domain.Entities;

public class Cliente : Persona
{
    public required string Contrasena { get; set; }
    public string Estado { get; set; }    
}