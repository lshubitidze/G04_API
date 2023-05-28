using MediatR;

namespace Mediator.Commands.UserCommands
{
    public record LoginUserCommand(string username, string password) : IRequest<string>
    {
    }
}
