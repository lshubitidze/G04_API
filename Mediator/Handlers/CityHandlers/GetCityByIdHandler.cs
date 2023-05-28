using AutoMapper;
using Fasade.Interfaces.Service;
using Fasade.Models;
using Mediator.Queries.CityQueryes;
using MediatR;

namespace Mediator.Handlers.CityHandlers
{
    public class GetCityByIdHandler : IRequestHandler<GetCityByIdQuery, CityModel>
    {
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;

        public GetCityByIdHandler(ICityService cityService, IMapper mapper)
        {
            _cityService = cityService ?? throw new ArgumentException(nameof(cityService));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        public Task<CityModel> Handle(GetCityByIdQuery request, CancellationToken cancellationToken) =>
            Task.FromResult(_mapper.Map<CityModel>(_cityService.GetById(request.Id)));
    }
}
