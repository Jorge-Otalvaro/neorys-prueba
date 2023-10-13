using AutoMapper;
using ClientePersonaMicroservicio.Domain.Dtos;
using ClientePersonaMicroservicio.Domain.Services;
using MediatR;

namespace ClientePersonaMicroservicio.Application.Clientes;

public class ListClientesQueryHandler : IRequestHandler<ListClientesQuery, List<ClienteDto>>
{
    readonly IMapper _mapper;
    private readonly RecordClienteService _clienteService;

    public ListClientesQueryHandler(IMapper mapper, RecordClienteService clienteService) =>
        (_mapper, _clienteService) = (mapper, clienteService);

    public async Task<List<ClienteDto>> Handle(ListClientesQuery request, CancellationToken cancellationToken)
    {
        var clientes = await _clienteService.GetClientesAsync();
        return _mapper.Map<List<ClienteDto>>(clientes);
    }
}