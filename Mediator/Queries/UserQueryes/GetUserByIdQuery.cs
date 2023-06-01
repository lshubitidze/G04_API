using Fasade.Models;
using MediatR;

namespace Mediator.Queries.UserQueryes
{
    public record GetUserByIdQuery(int ID) : IRequest<UserModel>;
}
