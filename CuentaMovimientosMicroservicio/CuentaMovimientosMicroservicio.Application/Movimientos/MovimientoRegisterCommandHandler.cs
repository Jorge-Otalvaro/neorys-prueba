using AutoMapper;
using CuentaMovimientosMicroservicio.Domain.Entities;
using CuentaMovimientosMicroservicio.Domain.Exceptions;
using CuentaMovimientosMicroservicio.Domain.Services;
using MediatR;

namespace CuentaMovimientosMicroservicio.Application.Movimientos;

public class MovimientoRegisterCommandHandler : IRequestHandler<MovimientoRegisterCommand>
{
    readonly IMapper _mapper;
    readonly RecordMovimientoService _movimientoRepository;
    readonly RecordCuentaService _recordCuentaService;

    public MovimientoRegisterCommandHandler(IMapper mapper, RecordMovimientoService movimientoRepository, RecordCuentaService recordCuentaService) =>
        (_mapper, _movimientoRepository, _recordCuentaService) = (mapper, movimientoRepository, recordCuentaService);

    public async Task<Unit> Handle(MovimientoRegisterCommand request, CancellationToken cancellationToken)
    {
        var respuesta = await _recordCuentaService.ObtenerCuenta(request.NumeroCuenta) ?? throw new UnderAgeException("El número de cuenta no existe o es inválido.");
        if (respuesta.SaldoInicial == 0)
        {
            throw new UnderAgeException("La cuenta no tiene saldo.");
        }

        if (request.Valor > respuesta.SaldoInicial)
        {
            throw new UnderAgeException("Saldo insuficiente");
        }
        var movimiento = _mapper.Map<Movimiento>(request);
        await _movimientoRepository.RegistrarMovimiento(movimiento);
        return Unit.Value;
    }
}
