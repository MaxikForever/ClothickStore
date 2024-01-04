using MediatR;

namespace Clothick.Application.Commands.UserRegistrationCommands.Sizes;

public record CreateSizeCommand(string SizeName) : IRequest<string>
{
}