using CuentaMovimientosMicroservicio.Domain.Dtos;
using MediatR;

namespace CuentaMovimientosMicroservicio.Application.Cuentas;

public record CuentaRegisterCommand(    
    string NumeroCuenta, 
    string TipoCuenta,
    decimal SaldoInicial,
    Guid ClienteId
) : IRequest<CuentaDto>;
