using ClientePersonaMicroservicio.Domain.Entities;

namespace ClientePersonaMicroservicio.Domain.Ports
{
    public interface IVoterRepository
    {
        Task<Voter> SaveVoter(Voter v);     
        Task<Voter> SingleVoter(Guid uid);   
        
    }

   
}

