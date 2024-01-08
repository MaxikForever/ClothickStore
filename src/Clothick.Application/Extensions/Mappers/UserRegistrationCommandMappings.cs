using Clothick.Application.Commands.UserRegistrationCommands;
using Clothick.Domain.Entities;

namespace Clothick.Application.Extensions;

public static class UserRegistrationCommandMappings
{
    public static User ToEntity(this UserRegistrationCommand command)
    {
        return new User()
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            UserName = command.UserName,
            PasswordHash = command.Password
        };
    }
}