using Fasade.Models;
using MediatR;

namespace Mediator.Queries.PersonQueryes
{
    public record GetPersonByIdQuery(int id) : IRequest<PersonModel>;
}
