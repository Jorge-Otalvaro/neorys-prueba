using ClientePersonaMicroservicio.Domain.Dtos;
using MediatR;

namespace ClientePersonaMicroservicio.Application.Clientes;

public record ClienteUpdateCommand(
       Guid Id, string Nombre, string Apellido, string Direccion, string Telefono, string Email
       ) : IRequest<ClienteDto>;
