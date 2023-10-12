using CuentaMovimientosMicroservicio.Api.Filters;
using CuentaMovimientosMicroservicio.Application.Cuentas;
using CuentaMovimientosMicroservicio.Application.Movimientos;
using CuentaMovimientosMicroservicio.Domain.Dtos;
using MediatR;

namespace CuentaMovimientosMicroservicio.Api.ApiHandlers;

public static class RouteApi
{
    public static RouteGroupBuilder MapRoutes(this IEndpointRouteBuilder routeHandler)
    {
        routeHandler.MapGet("/cuentas", async (IMediator mediator) => await mediator.Send(new ListCuentasQuery())).Produces(StatusCodes.Status200OK, typeof(List<CuentaDto>));        
        routeHandler.MapGet("/cuentas/{numeroCuenta}", async (IMediator mediator, int numeroCuenta) => await mediator.Send(new CuentaQuery(numeroCuenta))).Produces(StatusCodes.Status200OK, typeof(CuentaDto));        
        routeHandler.MapPost("/cuentas", async (IMediator mediator, [Validate] CuentaRegisterCommand cuenta) => await mediator.Send(cuenta)).Produces(StatusCodes.Status200OK, typeof(CuentaDto));        
        routeHandler.MapPut("/cuentas/{numeroCuenta}", async (IMediator mediator, int numeroCuenta, [Validate] CuentaUpdateCommand cuenta) => await mediator.Send(cuenta)).Produces(StatusCodes.Status200OK, typeof(CuentaDto));
        routeHandler.MapDelete("/cuentas/{id}", async (IMediator mediator, Guid id) => await mediator.Send(new CuentaDeleteCommand(id))).Produces(StatusCodes.Status200OK, typeof(CuentaDto));
                
        routeHandler.MapGet("/movimientos", async (IMediator mediator) => await mediator.Send(new ListMovimientosQuery())).Produces(StatusCodes.Status200OK, typeof(List<MovimientoDto>));                
        routeHandler.MapGet("/movimientos/{id}", async (IMediator mediator, Guid id) => await mediator.Send(new MovimientoQuery(id))).Produces(StatusCodes.Status200OK, typeof(MovimientoDto));
        routeHandler.MapGet("/lista-movimientos/{movimiento}", async (IMediator mediator, int movimiento) => await mediator.Send(new ListaMovimientoQuery(movimiento))).Produces(StatusCodes.Status200OK, typeof(List<MovimientoDto>));
        routeHandler.MapPost("/movimientos", async (IMediator mediator, [Validate] MovimientoRegisterCommand movimiento) => await mediator.Send(movimiento)).Produces(StatusCodes.Status200OK, typeof(MovimientoDto));        
        routeHandler.MapPut("/movimientos/{id}", async (IMediator mediator, Guid id, [Validate] MovimientoUpdateCommand movimiento) => await mediator.Send(movimiento with { Id = id })).Produces(StatusCodes.Status200OK, typeof(MovimientoDto));        
        routeHandler.MapDelete("/movimientos/{id}", async (IMediator mediator, Guid id) => await mediator.Send(new MovimientoDeleteCommand(id))).Produces(StatusCodes.Status200OK, typeof(MovimientoDto));
        
        return (RouteGroupBuilder)routeHandler;
    }
}

