using Fasade.Models;
using MediatR;

namespace Mediator.Queries.RelatedPersonQueryes
{
    public record GetRelatedPersonByIdQuery(int Id) : IRequest<RelatedPersonModel>
    {
    }
}
