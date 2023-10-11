using ClientePersonaMicroservicio.Domain.Dto;
using MediatR;

namespace ClientePersonaMicroservicio.Application.Voters;

public record VoterQuery(
    Guid uid
    ) : IRequest<VoterDto>;

public record VoterSimpleQuery(
    Guid uid
    ) : IRequest<VoterDto>;
