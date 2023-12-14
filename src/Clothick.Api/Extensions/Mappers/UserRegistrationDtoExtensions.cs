using Clothick.Api.DTO;
using Clothick.Application.Commands.UserRegistrationCommands;
using Clothick.Domain.Entities;

namespace Clothick.Api.Extensions.Mappers;

public static class UserRegistrationDtoExtensions
{
    public static UserRegistrationCommand ToCommand(this UserRegistrationDto dto)
    {
        return new UserRegistrationCommand(
            FirstName: dto.FirstName,
            LastName: dto.LastName,
            Email: dto.Email,
            Password: dto.Password,
            UserName: dto.UserName
        );
    }
}