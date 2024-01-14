using Clothick.Api.DTO;
using Clothick.Api.Validators;
using FluentValidation;

namespace Clothick.Api.Extensions;

public static class ValidatorExtensions
{
    public static void AddValidationServices(this IServiceCollection services)
    {
        services.AddScoped<IValidatorFactory, ValidatorFactory>();
        services.AddScoped<IValidator<UserRegistrationDto>, UserRegistrationDtoValidator>();
        services.AddScoped<IValidator<UserLoginDto>, UserLoginDtoValidator>();
        services.AddScoped<IValidator<ProductUploadDto>, ProductUploadDtoValidator>();
        services.AddScoped<IValidator<UploadProductVariantDto>, UploadProductVariantDtoValidator>();
        services.AddScoped<IValidator<CreateColorDto>, CreateColorDtoValidator>();
        services.AddScoped<IValidator<CreateCategoryDto>, CreateCategoryDtoValidator>();
        services.AddScoped<IValidator<CreateSizeDto>, CreateSizeDtoValidator>();
        services.AddScoped<IValidator<AddCommentDto>, AddCommentDtoValidator>();
        /*services.AddValidatorsFromAssemblyContaining<CreateCategoryDtoValidator>();*/
    }
}