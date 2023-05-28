using MediatR;

namespace Mediator.Commands.RelatedPersonCommands
{
    public record DeleteRelatedPersonByIdCommand(int Id) : IRequest
    {
    }
}
