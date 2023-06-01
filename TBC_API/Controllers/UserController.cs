using Fasade.Models;
using Mediator.Commands.UserCommands;
using Mediator.Queries.UserQueryes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TBC_API.ActionFilters.UserController;
using TBC_API.ActionParameters.User;

namespace TBC_API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        [CreateUserFilter]
        [AllowAnonymous]
        public IActionResult Create([FromBody] UserModel user) =>
            Ok(_mediator.Send(new InsertUserCommand(user)));

        [HttpPut("Update")]
        public IActionResult Update([FromBody] UserModel user) =>
            Ok(_mediator.Send(new UpdateUserCommand(user)));

        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody] UserModel user)
        {
            _mediator.Send(new DeleteUserCommand(user));
            return NoContent();
        }

        [HttpDelete("DeleteById/{id}")]
        public IActionResult DeleteById(int id)
        {
            _mediator.Send(new DeleteUserByIdCommand(id));
            return NoContent();
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id) =>
            Ok(_mediator.Send(new GetUserByIdQuery(id)));

        [HttpPost("Login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginParameters parameters) =>
            Ok(_mediator.Send(new LoginUserCommand(parameters.Username, parameters.Password)));
    }
}
