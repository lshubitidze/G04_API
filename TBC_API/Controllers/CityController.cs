using Mediator.Queries.CityQueryes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TBC_API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/city")]
    public class CityController : Controller
    {
        private readonly IMediator _mediator;

        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id) =>
            Ok(_mediator.Send(new GetCityByIdQuery(id)));
    }
}
