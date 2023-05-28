using Fasade.Models;
using MediatR;

namespace Mediator.Commands.RelatedPersonCommands
{
    public record UpdateRelatedPersonCommand(RelatedPersonModel Model) : IRequest
    {
    }
}
