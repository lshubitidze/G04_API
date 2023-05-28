using Fasade.Models;
using MediatR;

namespace Mediator.Commands.PersonCommands
{
    public record UpdatePersonCommand(PersonModel Person) : IRequest;
}
