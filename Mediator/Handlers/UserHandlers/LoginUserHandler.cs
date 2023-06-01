using AutoMapper;
using Fasade.Interfaces.Service;
using Mediator.Commands.UserCommands;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace Mediator.Handlers.UserHandlers
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand,string>
    {
        private readonly IUserService _userService;
        private readonly IAuthorizationService _authorizationService;

        public LoginUserHandler(IUserService userService, IAuthorizationService authorizationService, IMapper mapper)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _authorizationService = authorizationService ?? throw new ArgumentNullException(nameof(authorizationService));
        }

        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = _userService.Login(request.username, request.password);
            if (user == null)
            {
                throw new NullReferenceException(nameof(user));
            }

            IdentityUser identityUser = new()
            {
                Id = user.ID.ToString(),
                UserName = user.UserName,
                Email = user.Email
            };

            string token = new JwtSecurityTokenHandler().WriteToken(_authorizationService.CreateJwtToken(identityUser));
            return (token);
        }
    }
}
