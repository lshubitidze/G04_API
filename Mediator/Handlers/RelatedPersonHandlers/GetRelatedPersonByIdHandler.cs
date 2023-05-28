using AutoMapper;
using MediatR;
using Mediator.Queries.RelatedPersonQueryes;
using Fasade.Interfaces.Service;
using Fasade.Models;

namespace Mediator.Handlers.RelatedPersonHandlers
{
    public class GetRelatedPersonByIdHandler : IRequestHandler<GetRelatedPersonByIdQuery, RelatedPersonModel>
    {
        private readonly IRelatedPersonService _relatedPersonService;
        private readonly IMapper _mapper;

        public GetRelatedPersonByIdHandler(IRelatedPersonService relatedPersonService, IMapper mapper)
        {
            _relatedPersonService = relatedPersonService ?? throw new ArgumentException(nameof(relatedPersonService));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        public Task<RelatedPersonModel> Handle(GetRelatedPersonByIdQuery request, CancellationToken cancellationToken) =>
            Task.FromResult(_mapper.Map<RelatedPersonModel>(_relatedPersonService.GetById(request.Id)));
    }
}
