using AutoMapper;
using Fasade.DTO;
using Fasade.Interfaces.Service;
using Mediator.Commands.RelatedPersonCommands;
using MediatR;

namespace Mediator.Handlers.RelatedPersonHandlers
{
    public class UpdateRelatedPersonHandler : IRequestHandler<UpdateRelatedPersonCommand>
    {
        private readonly IRelatedPersonService _relatedPersonService;
        private readonly IMapper _mapper;

        public UpdateRelatedPersonHandler(IRelatedPersonService relatedPersonService, IMapper mapper)
        {
            _relatedPersonService = relatedPersonService ?? throw new ArgumentException(nameof(relatedPersonService));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        public Task Handle(UpdateRelatedPersonCommand request, CancellationToken cancellationToken)
        {
            _relatedPersonService.Update(_mapper.Map<RelatedPersonDTO>(request.Model));
            return Task.CompletedTask;
        }
    }
}
