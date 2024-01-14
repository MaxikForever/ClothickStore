using Clothick.Api.DTO;
using Clothick.Application.Commands.UserRegistrationCommands.Login;

namespace Clothick.Api.Extensions.Mappers;

public static class UserLoginDtoMapper
{
    public static UserLoginCommand ToCommand(this UserLoginDto userDto)
    {
        return new UserLoginCommand(
            userDto.UserName,
            userDto.Password
        );
    }
}