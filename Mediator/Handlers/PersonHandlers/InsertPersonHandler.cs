using AutoMapper;
using Fasade.DTO;
using Fasade.Interfaces.Service;
using Fasade.Models;
using Mediator.Commands.PersonCommands;
using MediatR;

namespace Mediator.Handlers.PersonHandlers
{
    public class InsertPersonHandler : IRequestHandler<InsertPersonCommand, PersonModel>
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public InsertPersonHandler(IPersonService personService, IMapper mapper)
        {
            _personService = personService ?? throw new ArgumentNullException(nameof(personService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task<PersonModel> Handle(InsertPersonCommand request, CancellationToken cancellationToken) =>
            Task.FromResult(_mapper.Map<PersonModel>(_personService.Insert(_mapper.Map<PersonDTO>(request.person))));
    }
}
