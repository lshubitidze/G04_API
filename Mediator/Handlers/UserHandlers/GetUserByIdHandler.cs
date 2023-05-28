using Fasade.DTO;
using Fasade.Interfaces.Service;
using Mediator.Queries.UserQueryes;
using MediatR;

namespace Mediator.Handlers.UserHandlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserDTO>
    {
        private readonly IUserService _userService;

        public GetUserByIdHandler(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public Task<UserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_userService.GetById(request.ID));
        }
    }
}
