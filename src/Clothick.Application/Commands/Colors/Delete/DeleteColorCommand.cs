using MediatR;

namespace Clothick.Application.Commands.UserRegistrationCommands.Colors.Delete;

public record DeleteColorCommand(int Id): IRequest;