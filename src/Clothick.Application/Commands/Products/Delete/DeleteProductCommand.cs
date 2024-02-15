using MediatR;

namespace Clothick.Application.Commands.UserRegistrationCommands.Products.Delete;

public record DeleteProductCommand(int Id): IRequest;