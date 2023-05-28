using Fasade.Models;
using MediatR;

namespace Mediator.Commands.RelatedPersonCommands
{
    public record DeleteRelatedPersonCommand(RelatedPersonModel Model) : IRequest
    {
    }
}
