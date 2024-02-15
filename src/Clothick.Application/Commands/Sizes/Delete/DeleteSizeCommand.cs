using MediatR;

namespace Clothick.Application.Commands.UserRegistrationCommands.Sizes.Delete;

public record DeleteSizeCommand(int Id): IRequest;