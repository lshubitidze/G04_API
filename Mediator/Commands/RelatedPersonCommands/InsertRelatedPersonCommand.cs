using Fasade.Models;
using MediatR;

namespace Mediator.Commands.RelatedPersonCommands
{
    public record InsertRelatedPersonCommand(RelatedPersonModel Model) : IRequest<RelatedPersonModel>
    {
    }
}
