using AutoMapper;
using Fasade.DTO;
using Fasade.Interfaces.Service;
using Fasade.Models;
using Mediator.Queries.UserQueryes;
using MediatR;

namespace Mediator.Handlers.UserHandlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserModel>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public GetUserByIdHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task<UserModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_mapper.Map<UserModel>(_userService.GetById(request.ID)));
        }
    }
}
