using Fasade.Models;
using Mediator.Commands.PersonCommands;
using Mediator.Queries.PersonQueryes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TBC_API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/person")]
    public class PersonController : Controller
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Insert")]
        public IActionResult Insert([FromBody] PersonModel person) =>
            Ok(_mediator.Send(new InsertPersonCommand(person)));

        [HttpPut("Update")]
        public IActionResult Update([FromBody] PersonModel person) =>
            Ok(_mediator.Send(new UpdatePersonCommand(person)));

        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody] PersonModel person)
        {
            _mediator.Send(new DeletePersonCommand(person));
            return NoContent();
        }

        [HttpDelete("DeleteById/{id}")]
        public IActionResult DeleteById(int id)
        {
            _mediator.Send(new DeletePersonByIdCommand(id));
            return NoContent();
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id) =>
            Ok(_mediator.Send(new GetPersonByIdQuery(id)));
    }
}
