using Fasade.Models;
using MediatR;

namespace Mediator.Commands.PersonCommands
{
    public record DeletePersonCommand(PersonModel Person) : IRequest;
}
