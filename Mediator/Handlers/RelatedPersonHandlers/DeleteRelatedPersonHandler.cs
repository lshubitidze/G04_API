using AutoMapper;
using Fasade.DTO;
using Fasade.Interfaces.Service;
using Mediator.Commands.RelatedPersonCommands;
using MediatR;

namespace Mediator.Handlers.RelatedPersonHandlers
{
    public class DeleteRelatedPersonHandler : IRequestHandler<DeleteRelatedPersonCommand>
    {
        private readonly IRelatedPersonService _relatedPersonService;
        private readonly IMapper _mapper;

        public DeleteRelatedPersonHandler(IRelatedPersonService relatedPersonService, IMapper mapper)
        {
            _relatedPersonService = relatedPersonService ?? throw new ArgumentException(nameof(relatedPersonService));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        public Task Handle(DeleteRelatedPersonCommand request, CancellationToken cancellationToken)
        {
            _relatedPersonService.Delete(_mapper.Map<RelatedPersonDTO>(request.Model));
            return Task.CompletedTask;
        }
    }
}
