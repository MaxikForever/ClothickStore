using Clothick.Api.Constants;
using Clothick.Api.DTO;
using Clothick.Contracts.Interfaces.Services;
using FluentValidation;

namespace Clothick.Api.Validators;

public class UploadProductVariantDtoValidator : AbstractValidator<UploadProductVariantDto>
{
    private readonly IProductVariantService _productVariantService;

    private readonly List<string> _allowedExtensions = new() { ".jpg", ".png", ".jpeg", "jfif", "webp"};
    private readonly long _maxFileSize = 5 * 1024 * 1024; // 5 MB

    public UploadProductVariantDtoValidator(IProductVariantService productVariantService)
    {
        _productVariantService = productVariantService;

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

        /*RuleFor(x => x.Images)
            .Must(BeAValidSize).WithMessage("File must be less than 5 MB");

        RuleFor(x => x.Images)
            .Must(BeAValidFormat).WithMessage("Only JPG, JPEG, and PNG files are allowed");*/
    }

    private bool BeAValidSize(IEnumerable<IFormFile> files)
    {
        return files.All(file => file.Length <= _maxFileSize);
    }

    private bool BeAValidFormat(IEnumerable<IFormFile> files)
    {
        return files.Select(file => Path.GetExtension(file.FileName).ToLowerInvariant())
            .All(extension => _allowedExtensions.Contains(extension));
    }
}