using MediatR;

namespace ClientePersonaMicroservicio.Application.Clientes;

public record ClienteDeleteCommand(Guid Id) : IRequest<bool>;
