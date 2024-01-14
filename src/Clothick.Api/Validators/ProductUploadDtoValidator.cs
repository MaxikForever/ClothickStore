using Clothick.Api.Constants;
using Clothick.Api.DTO;
using Clothick.Contracts.Interfaces.Services;
using FluentValidation;

namespace Clothick.Api.Validators;

public class ProductUploadDtoValidator : AbstractValidator<ProductUploadDto>
{
    private readonly IProductVariantService _productVariantService;

    public ProductUploadDtoValidator(IProductVariantService productVariantService)
    {
        _productVariantService = productVariantService;
        RuleFor(x => x.BrandName)
            .NotEmpty().WithMessage(ProductUploadingValidationErrorMessages.BrandNameRequired);

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage(ProductUploadingValidationErrorMessages.DescriptionRequired);

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage(ProductUploadingValidationErrorMessages.PricePositive);

        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage(ProductUploadingValidationErrorMessages.CategoryIdRequired)
            .MustAsync(async (categoryId, _) =>
                await _productVariantService.CheckCategoryIdsValidity(categoryId))
            .WithMessage("Check the inserted id for category it doesn't exist");
    }
}