using Clothick.Api.DTO;
using Clothick.Contracts.Interfaces.Repositories;
using Clothick.Contracts.Interfaces.Services;
using Clothick.Domain.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Clothick.Api.Validators;

public class CreateColorDtoValidator : AbstractValidator<CreateColorDto>
{
    private readonly IColorService _colorService;
    public CreateColorDtoValidator(IColorService colorService)
    {
        _colorService = colorService;

        RuleFor(x => x.ColorName)
            .NotEmpty().WithMessage("Color name is required.")
            .Length(2, 50).WithMessage("Color name must be between 2 and 50 characters.")
            .Matches("^[a-zA-Z ]*$").WithMessage("Color name must contain only letters and spaces.")
            .MustAsync(async (colorName, cancellation) =>
            {
                return await _colorService.IsColorNameUniqueAsync(colorName);
            }).WithMessage("Color name must be unique");
    }
}