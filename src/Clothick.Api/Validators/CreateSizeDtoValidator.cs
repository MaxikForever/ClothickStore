using Clothick.Api.DTO;
using FluentValidation;

namespace Clothick.Api.Validators;

public class CreateSizeDtoValidator : AbstractValidator<CreateSizeDto>
{
    public CreateSizeDtoValidator()
    {
        RuleFor(x => x.SizeName)
            .NotEmpty().WithMessage("Size name is required.")
            .Must(BeValidSize).WithMessage("Invalid size format.");
    }


    private bool BeValidSize(string sizeName)
    {
        // Check for shoe sizes like "42", "43", etc.
        if (int.TryParse(sizeName, out int numericSize))
        {
            return numericSize >= 15 && numericSize <= 60;
        }

        // Check for clothing sizes like "XXL", "M", "S", etc.
        var validClothingSizes = new HashSet<string> { "XS", "S", "M", "L", "XL", "XXL", "XXXL" };
        return validClothingSizes.Contains(sizeName.ToUpper());
    }


}