using MediatR;

namespace CuentaMovimientosMicroservicio.Application.Cuentas;

public record CuentaRegisterCommand(    
    string NumeroCuenta, 
    string TipoCuenta,
    decimal SaldoInicial
) : IRequest;
