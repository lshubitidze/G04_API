using Fasade.Models;
using MediatR;

namespace Mediator.Commands.CityCommands
{
    public record DeleteCityCommand(CityModel Model) : IRequest
    {
    }
}
