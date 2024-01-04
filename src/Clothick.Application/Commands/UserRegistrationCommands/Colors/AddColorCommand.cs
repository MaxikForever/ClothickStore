using MediatR;

namespace Clothick.Application.Commands.UserRegistrationCommands.Colors;

public record AddColorCommand(string ColorName) : IRequest<string>
{

}