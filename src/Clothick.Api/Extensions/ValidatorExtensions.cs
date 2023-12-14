using Clothick.Api.DTO;
using Clothick.Api.Validators;
using FluentValidation;

namespace Clothick.Api.Extensions;

public static class ValidatorExtensions
{
    public static void AddValidationServices(this IServiceCollection services)
    {
        services.AddScoped<IValidator<UserRegistrationDto>, UserRegistrationDtoValidator>();
        services.AddScoped<IValidatorFactory, ValidatorFactory>();
    }
}