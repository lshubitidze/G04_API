using AutoMapper;
using Fasade.DTO;
using Fasade.Interfaces.Service;
using Mediator.Commands.UserCommands;
using MediatR;

namespace Mediator.Handlers.UserHandlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UpdateUserHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService ?? throw new ArgumentException(nameof(userService));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }
        public Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            _userService.Update(_mapper.Map<UserDTO>(request.User));
            return Task.CompletedTask;
        }
    }
}
