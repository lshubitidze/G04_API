using Fasade.Models;
using MediatR;

namespace Mediator.Commands.UserCommands
{
    public record InsertUserCommand(UserModel User) : IRequest<UserModel>
    {
    }
}
