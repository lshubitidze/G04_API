using Fasade.Models;
using MediatR;

namespace Mediator.Queries.CityQueryes
{
    public record GetCityByIdQuery(int Id) : IRequest<CityModel>
    {
    }
}
