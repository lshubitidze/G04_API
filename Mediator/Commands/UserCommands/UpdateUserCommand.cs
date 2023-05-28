using Fasade;
using Fasade.Models;
using MediatR;

namespace Mediator.Commands.UserCommands
{
    public record UpdateUserCommand(UserModel User) : IRequest
    {
    }
}
