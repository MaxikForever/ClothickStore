using MediatR;

namespace Clothick.Application.Commands.UserRegistrationCommands.Login;

public record UserLoginCommand(string Username, string Password) : IRequest<string>
{
}