using ClientePersonaMicroservicio.Api.Filters;
using ClientePersonaMicroservicio.Application.Clientes;
using ClientePersonaMicroservicio.Domain.Dtos;
using MediatR;

namespace ClientePersonaMicroservicio.Api.ApiHandlers;

public static class RouteApi
{
    public static RouteGroupBuilder MapRoutes(this IEndpointRouteBuilder routeHandler)
    {
        routeHandler.MapGet("/clientes", async (IMediator mediator) =>
        {
            List<ClienteDto> clientes = await mediator.Send(new ListClientesQuery());
            return Results.Ok(clientes);
        }).Produces(StatusCodes.Status200OK, typeof(List<ClienteDto>));

        routeHandler.MapGet("/clientes/{id}", async (IMediator mediator, Guid id) =>
        {
            ClienteDto cliente = await mediator.Send(new ClienteSimpleQuery(id));

            if (cliente == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(cliente);
        }).Produces(StatusCodes.Status200OK, typeof(ClienteDto));

        routeHandler.MapPost("/clientes", async (IMediator mediator, [Validate] ClienteRegisterCommand cliente) =>
        {
            ClienteDto createdCliente = await mediator.Send(cliente);
            return Results.Created(new Uri($"/api/clientes/{createdCliente.Id}", UriKind.Relative), createdCliente);
        }).Produces(statusCode: StatusCodes.Status201Created);

        routeHandler.MapPut("/clientes/{id}", async (IMediator mediator, Guid id, [Validate] ClienteUpdateCommand cliente) =>
        {
            ClienteDto updatedCliente = await mediator.Send(cliente with { Id = id });
            if (updatedCliente == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(updatedCliente);
        }).Produces(StatusCodes.Status200OK, typeof(ClienteDto));

        routeHandler.MapDelete("/clientes/{id}", async (IMediator mediator, Guid id) =>
        {
            bool deleted = await mediator.Send(new ClienteDeleteCommand(id));
            if (!deleted)
            {
                return Results.NotFound();
            }
            return Results.NoContent();
        }).Produces(StatusCodes.Status204NoContent);

        return (RouteGroupBuilder)routeHandler;
    }
}
