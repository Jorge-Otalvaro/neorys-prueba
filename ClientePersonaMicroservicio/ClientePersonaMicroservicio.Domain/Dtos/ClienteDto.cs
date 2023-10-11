namespace ClientePersonaMicroservicio.Domain.Dtos;

public record ClienteDto(Guid Id, string Nombre, string Genero, int Edad, string Identificacion, string Direccion, string Telefono, string Contrasena);
