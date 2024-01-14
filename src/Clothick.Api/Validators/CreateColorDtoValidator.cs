using Clothick.Api.DTO;
using Clothick.Contracts.Interfaces.Services;
using Clothick.Domain.Constants;
using Clothick.Domain.Entities;
using FluentValidation;

namespace Clothick.Api.Validators;

public class CreateColorDtoValidator : AbstractValidator<CreateColorDto>
{
    public CreateColorDtoValidator(IUniqueService<Color> uniqueService)
    {
        RuleFor(x => x.ColorName)
            .NotEmpty().WithMessage("Color name is required.")
            .Length(2, 50).WithMessage("Color name must be between 2 and 50 characters.")
            .Matches("^[a-zA-Z ]*$").WithMessage("Color name must contain only letters and spaces.")
            .MustAsync(async (colorName, cancellation) =>
            {
                return await uniqueService.IsNameUniqueAsync(CacheKeyConstants.ColorNames, colorName);
            }).WithMessage("Color name must be unique");
    }
}