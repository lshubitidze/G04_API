using MediatR;

namespace Mediator.Commands.CityCommands
{
    public record DeleteCityByIdCommand(int Id) : IRequest
    {
    }
}
