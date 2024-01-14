using Clothick.Api.DTO;
using Clothick.Application.Commands.UserRegistrationCommands;

namespace Clothick.Api.Extensions.Mappers;

public static class UserRegistrationDtoExtensions
{
    public static UserRegistrationCommand ToCommand(this UserRegistrationDto dto)
    {
        return new UserRegistrationCommand(
            dto.FirstName,
            dto.LastName,
            dto.Email,
            dto.Password,
            dto.UserName
        );
    }
}