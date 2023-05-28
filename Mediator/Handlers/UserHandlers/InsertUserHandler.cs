using AutoMapper;
using Fasade.DTO;
using Fasade.Interfaces.Service;
using Fasade.Models;
using Mediator.Commands.UserCommands;
using MediatR;

namespace Mediator.Handlers.UserHandlers
{
    public class InsertUserHandler : IRequestHandler<InsertUserCommand, UserModel>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public InsertUserHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task<UserModel> Handle(InsertUserCommand request, CancellationToken cancellationToken) => 
            Task.FromResult(_mapper.Map<UserModel>(_userService.Insert(_mapper.Map<UserDTO>(request.User))));
    }
}

