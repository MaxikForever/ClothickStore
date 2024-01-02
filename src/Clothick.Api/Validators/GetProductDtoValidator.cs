using System.Data;
using Clothick.Api.Constants;
using Clothick.Api.DTO;
using FluentValidation;

namespace Clothick.Api.Validators;

public class GetProductDtoValidator : AbstractValidator<GetProductDto>
{
    public GetProductDtoValidator()
    {
        RuleFor(x => x.BrandName)
            .NotEmpty().WithMessage(ProductUploadingValidationErrorMessages.BrandNameRequired);

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage(ProductUploadingValidationErrorMessages.DescriptionRequired);

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage(ProductUploadingValidationErrorMessages.PricePositive);



    }
}