using Fasade;
using Fasade.Models;
using MediatR;

namespace Mediator.Commands.UserCommands
{
    public record DeleteUserCommand(UserModel User) : IRequest
    {
    }
}
