namespace CuentaMovimientosMicroservicio.Domain.Dtos;

public record CuentaDto(
    int NumeroCuenta, 
    string TipoCuenta, 
    decimal SaldoInicial,    
    bool Estado,
    string Cliente
);
