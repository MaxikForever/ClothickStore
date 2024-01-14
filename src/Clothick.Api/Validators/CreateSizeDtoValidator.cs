using Clothick.Api.DTO;
using Clothick.Contracts.Interfaces.Services;
using Clothick.Domain.Constants;
using Clothick.Domain.Entities;
using FluentValidation;

namespace Clothick.Api.Validators;

public class CreateSizeDtoValidator : AbstractValidator<CreateSizeDto>
{
    public CreateSizeDtoValidator(IUniqueService<Size> uniqueService)
    {
        RuleFor(x => x.SizeName)
            .NotEmpty().WithMessage("Size name is required.")
            .Must(BeValidSize).WithMessage("Invalid size format.")
            .MustAsync(async (sizeName, _) =>
                await uniqueService.IsNameUniqueAsync(CacheKeyConstants.SizeNames, sizeName.ToUpper()))
            .WithMessage("Size should be unique");
    }


    private bool BeValidSize(string sizeName)
    {
        // Check for shoe sizes like "42", "43", etc.
        if (int.TryParse(sizeName, out var numericSize)) return numericSize >= 15 && numericSize <= 60;

        // Check for clothing sizes like "XXL", "M", "S", etc.
        var validClothingSizes = new HashSet<string> { "XS", "S", "M", "L", "XL", "XXL", "XXXL" };
        return validClothingSizes.Contains(sizeName.ToUpper());
    }
}