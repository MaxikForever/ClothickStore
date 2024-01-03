using Clothick.Api.Constants;
using Clothick.Api.DTO;
using Clothick.Contracts.Interfaces.Services;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace Clothick.Api.Validators;

public class UploadProductVariantModelValidator : AbstractValidator<UploadProductVariantModel>
{
    public UploadProductVariantModelValidator(IProductVariantService productVariantService)
    {
        RuleFor(v => v)
            .MustAsync(async (dto, _) =>
                await productVariantService.CheckIdsValidity(dto.SizeId, dto.ColorId))
            .WithMessage("Check the inserted id's for size and color, they doesn't exist");

        RuleFor(v => v.SizeId)
            .NotEmpty().WithMessage(ProductUploadingValidationErrorMessages.SizeIdRequired);

        RuleFor(v => v.ColorId)
            .NotEmpty().WithMessage(ProductUploadingValidationErrorMessages.ColorIdRequired);

        RuleFor(v => v.Stock)
            .GreaterThanOrEqualTo(0).WithMessage(ProductUploadingValidationErrorMessages.StockPositive);

        RuleFor(v => v.DiscountedPrice)
            .NotEmpty().WithMessage(ProductUploadingValidationErrorMessages.DiscountRequired);

        RuleFor(v => v.SKU)
            .NotEmpty().WithMessage(ProductUploadingValidationErrorMessages.SKURequired);
    }
}