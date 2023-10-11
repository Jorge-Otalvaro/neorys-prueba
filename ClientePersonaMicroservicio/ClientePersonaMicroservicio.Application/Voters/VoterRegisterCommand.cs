using ClientePersonaMicroservicio.Domain.Dto;
using MediatR;


namespace ClientePersonaMicroservicio.Application.Voters;

public record VoterRegisterCommand(
    string Nid, string Origin, DateTime Dob
    ) : IRequest<VoterDto>;

