using Fasade.Interfaces.Service;
using Mediator.Commands.PersonCommands;
using MediatR;

namespace Mediator.Handlers.PersonHandlers
{
    public class DeletePersonByIdHandler : IRequestHandler<DeletePersonByIdCommand>
    {
        private readonly IPersonService _personService;

        public DeletePersonByIdHandler(IPersonService personService)
        {
            _personService = personService ?? throw new ArgumentNullException(nameof(personService));
        }
        public Task Handle(DeletePersonByIdCommand request, CancellationToken cancellationToken)
        {
            _personService.Delete(request.id);
            return Task.CompletedTask;
        }
    }
}
