using Fasade.Models;
using Mediator.Commands.RelatedPersonCommands;
using Mediator.Queries.RelatedPersonQueryes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TBC_API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/relatedPerson")]
    public class RelatedPersonController : Controller
    {
        private readonly IMediator _mediator;

        public RelatedPersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Insert")]
        public IActionResult Insert([FromBody] RelatedPersonModel relatedPerson) =>
            Ok(_mediator.Send(new InsertRelatedPersonCommand(relatedPerson)));

        [HttpPut("Update")]
        public IActionResult Update([FromBody] RelatedPersonModel relatedPerson) =>
            Ok(_mediator.Send(new UpdateRelatedPersonCommand(relatedPerson)));

        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody] RelatedPersonModel relatedPerson)
        {
            _mediator.Send(new DeleteRelatedPersonCommand(relatedPerson));
            return NoContent();
        }

        [HttpDelete("DeleteById/{id}")]
        public IActionResult DeleteById(int id)
        {
            _mediator.Send(new DeleteRelatedPersonByIdCommand(id));
            return NoContent();
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id) =>
            Ok(_mediator.Send(new GetRelatedPersonByIdQuery(id)));
    }
}
