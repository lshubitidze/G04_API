using AutoMapper;
using Fasade.DTO;
using Fasade.Interfaces.Service;
using Mediator.Commands.PersonCommands;
using MediatR;

namespace Mediator.Handlers.PersonHandlers
{
    public class UpdatePersonHandler : IRequestHandler<UpdatePersonCommand>
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public UpdatePersonHandler(IPersonService personService, IMapper mapper)
        {
            _personService = personService ?? throw new ArgumentNullException(nameof(personService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public Task Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            _personService.Update(_mapper.Map<PersonDTO>(request.Person));
            return Task.CompletedTask;
        }
    }
}
