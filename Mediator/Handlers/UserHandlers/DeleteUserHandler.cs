using AutoMapper;
using Fasade.DTO;
using Fasade.Interfaces.Service;
using Mediator.Commands.UserCommands;
using MediatR;

namespace Mediator.Handlers.UserHandlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public DeleteUserHandler(IUserService userservice, IMapper mapper)
        {
            _userService = userservice ?? throw new ArgumentNullException(nameof(userservice));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            _userService.Delete(_mapper.Map<UserDTO>(request.User));
            return Task.CompletedTask;
        }
    }
}
