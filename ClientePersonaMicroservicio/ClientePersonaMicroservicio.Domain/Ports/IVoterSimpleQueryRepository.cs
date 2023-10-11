using ClientePersonaMicroservicio.Domain.Dto;

namespace ClientePersonaMicroservicio.Domain.Ports
{
    public interface IVoterSimpleQueryRepository
    {
        Task<VoterDto> Single(Guid id);
    }
}

