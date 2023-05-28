using Fasade.Models;
using MediatR;

namespace Mediator.Commands.CityCommands
{
    public record InsertCityCommand(CityModel Model) : IRequest<CityModel>
    {
    }
}
