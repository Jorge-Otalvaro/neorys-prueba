using ClientePersonaMicroservicio.Domain.Dto;
using ClientePersonaMicroservicio.Domain.Ports;
using MediatR;

namespace ClientePersonaMicroservicio.Application.Voters;

public class VoterSimpleQueryHandler : IRequestHandler<VoterSimpleQuery, VoterDto>
{
    private readonly IVoterSimpleQueryRepository _repository;
    public VoterSimpleQueryHandler(IVoterSimpleQueryRepository repository) => _repository = repository;
    

    public async Task<VoterDto> Handle(VoterSimpleQuery request, CancellationToken cancellationToken)
    {
        return await _repository.Single(request.uid);                
    }
}