using ClientePersonaMicroservicio.Domain.Dtos;
using MediatR;

namespace ClientePersonaMicroservicio.Application.Clientes;

public record ListClientesQuery() : IRequest<List<ClienteDto>>;
