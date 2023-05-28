using AutoMapper;
using Fasade.DTO;
using Fasade.Interfaces.Service;
using Mediator.Commands.PersonCommands;
using MediatR;

namespace Mediator.Handlers.PersonHandlers
{
    public class DeletePersonHandler : IRequestHandler<DeletePersonCommand>
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public DeletePersonHandler(IPersonService personService, IMapper mapper)
        {
            _personService = personService ?? throw new ArgumentNullException(nameof(personService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            _personService.Delete(_mapper.Map<PersonDTO>(request.Person));
            return Task.CompletedTask;
        }
    }
}
