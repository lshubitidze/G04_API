using Fasade.Models;
using MediatR;

namespace Mediator.Commands.CityCommands
{
    public record UpdateCityCommand(CityModel Model) : IRequest
    {
    }
}
