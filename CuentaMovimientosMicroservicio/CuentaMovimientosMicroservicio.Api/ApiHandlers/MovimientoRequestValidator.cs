using CuentaMovimientosMicroservicio.Application.Movimientos;
using FluentValidation;

namespace CuentaMovimientosMicroservicio.Api.ApiHandlers;

public class MovimientoRequestValidator : AbstractValidator<MovimientoRegisterCommand>
{
    public MovimientoRequestValidator()
    {
        RuleFor(x => x.NumeroCuenta).NotEmpty().WithMessage("El número de cuenta es obligatorio.");

        RuleFor(x => x.TipoMovimiento).NotEmpty().WithMessage("El tipo de movimiento es obligatorio.");

        RuleFor(x => x.Monto)
            .NotEmpty().WithMessage("El monto es obligatorio.")
            .GreaterThan(0).WithMessage("El monto debe ser mayor que cero.");

        RuleFor(x => x.NumeroCuenta).NotEmpty().WithMessage("El número de cuenta es obligatorio.");            
    }
}
