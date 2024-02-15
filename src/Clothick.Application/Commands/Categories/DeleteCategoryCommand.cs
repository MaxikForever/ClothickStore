using MediatR;

namespace Clothick.Application.Commands.UserRegistrationCommands.Categories;

public record DeleteCategoryCommand(int Id): IRequest;