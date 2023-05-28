using Fasade.Interfaces.Service;
using Mediator.Commands.UserCommands;
using MediatR;

namespace Mediator.Handlers.UserHandlers
{
    public class DeleteUserByIdHandler : IRequestHandler<DeleteUserByIdCommand>
    {
        private readonly IUserService _userService;
        public DeleteUserByIdHandler(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }
        public Task Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
        {
            _userService.Delete(request.ID);
            return Task.CompletedTask;
        }
    }
}
