using Fasade.Models;
using MediatR;

namespace Mediator.Queries.PersonQueryes
{
    public record GetPersonByIdQuery(int Id) : IRequest<PersonModel>;
}
