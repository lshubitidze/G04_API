using Fasade.Models;
using MediatR;

namespace Mediator.Commands.PersonCommands
{
    public record InsertPersonCommand(PersonModel person) : IRequest<PersonModel>;
}
