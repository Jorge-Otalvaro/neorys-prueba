using ClientePersonaMicroservicio.Domain.Dtos;
using MediatR;

namespace ClientePersonaMicroservicio.Application.Clientes;

public record ClienteRegisterCommand(string Nombre, string Genero, int Edad, string Identificacion, string Direccion, string Telefono, string Contrasena) : IRequest<ClienteDto>;