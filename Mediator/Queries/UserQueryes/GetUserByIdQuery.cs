using Fasade.DTO;
using MediatR;

namespace Mediator.Queries.UserQueryes
{
    public record GetUserByIdQuery(int ID) : IRequest<UserDTO>;
}
