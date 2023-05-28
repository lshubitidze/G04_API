using MediatR;

namespace Mediator.Commands.UserCommands
{
    public record DeleteUserByIdCommand(int ID) : IRequest
    {
    }
}
