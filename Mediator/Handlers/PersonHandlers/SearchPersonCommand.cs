using AutoMapper;
using Fasade.Interfaces.Service;
using Fasade.Models;
using Mediator.Queries.PersonQueryes;
using MediatR;

namespace Mediator.Handlers.PersonHandlers
{
    public class SearchPersonCommand : IRequestHandler<SearchPersonQuery, IQueryable<PersonModel>>
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public SearchPersonCommand(IPersonService personService, IMapper mapper)
        {
            _personService = personService ?? throw new ArgumentNullException(nameof(personService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public Task<IQueryable<PersonModel>> Handle(SearchPersonQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_mapper.Map<IQueryable<PersonModel>>(_personService.Search(request.predicate)));
        }
    }
}
