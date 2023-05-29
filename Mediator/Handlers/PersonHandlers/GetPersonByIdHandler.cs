using AutoMapper;
using Fasade.Interfaces.Service;
using Fasade.Models;
using Mediator.Queries.PersonQueryes;
using MediatR;

namespace Mediator.Handlers.PersonHandlers
{
    public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, PersonModel>
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public GetPersonByIdHandler(IPersonService personService, IMapper mapper)
        {
            _personService = personService ?? throw new ArgumentNullException(nameof(personService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<PersonModel> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_mapper.Map<PersonModel>(_personService.GetById(request.Id)));
        }
    }
}
