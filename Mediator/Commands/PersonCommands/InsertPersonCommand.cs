using Fasade.Models;
using MediatR;

namespace Mediator.Commands.PersonCommands
{
    public record InsertPersonCommand(PersonModel Person) : IRequest<PersonModel>;
}
