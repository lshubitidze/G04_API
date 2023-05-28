using Fasade.DTO;
using Fasade.Models;
using MediatR;
using System.Linq.Expressions;

namespace Mediator.Queries.PersonQueryes
{
    public record SearchPersonQuery(Expression<Func<PersonDTO, bool>> predicate) : IRequest<IQueryable<PersonModel>>;
}
