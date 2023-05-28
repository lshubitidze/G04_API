using MediatR;

namespace Mediator.Commands.PersonCommands
{
    public record DeletePersonByIdCommand(int id) : IRequest;
}
