using AutoMapper;
using Fasade.DTO;
using Fasade.Interfaces.Service;
using Fasade.Models;
using Mediator.Commands.RelatedPersonCommands;
using MediatR;

namespace Mediator.Handlers.RelatedPersonHandlers
{
    public class InsertRelatedPersonHandle : IRequestHandler<InsertRelatedPersonCommand, RelatedPersonModel>
    {
        private readonly IRelatedPersonService _relatedPersonService;
        private readonly IMapper _mapper;

        public InsertRelatedPersonHandle(IRelatedPersonService relatedPersonService, IMapper mapper)
        {
            _relatedPersonService = relatedPersonService;
            _mapper = mapper;
        }
        public Task<RelatedPersonModel> Handle(InsertRelatedPersonCommand request, CancellationToken cancellationToken) =>
            Task.FromResult(_mapper.Map<RelatedPersonModel>(_relatedPersonService.Insert(_mapper.Map<RelatedPersonDTO>(request.Model))));
    }
}
