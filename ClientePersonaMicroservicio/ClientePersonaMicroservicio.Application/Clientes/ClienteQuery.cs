using ClientePersonaMicroservicio.Domain.Dtos;
using MediatR;

namespace ClientePersonaMicroservicio.Application.Clientes;

public record ClienteQuery(
       Guid Uid
       ) : IRequest<ClienteDto>;

public record ClienteSimpleQuery(
       Guid Uid
          ) : IRequest<ClienteDto>;
