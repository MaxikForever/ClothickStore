using System.Globalization;
using MediatR;

namespace Clothick.Application.Commands.UserRegistrationCommands.Categories;

public record AddCategoryCommand(string CategoryName): IRequest<string>
{

}