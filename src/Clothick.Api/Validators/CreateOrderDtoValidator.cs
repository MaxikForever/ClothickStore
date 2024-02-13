using Clothick.Api.DTO;
using Clothick.Contracts.Interfaces.Repositories;
using Clothick.Domain.Entities;
using FluentValidation;
using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace Clothick.Api.Validators;

public class CreateOrderDtoValidator : AbstractValidator<CreateOrderDto>
{
    private readonly IBaseRepository<ProductVariant> _productVariantRepository;

    public CreateOrderDtoValidator(IBaseRepository<ProductVariant> productVariantRepository)
    {
        _productVariantRepository = productVariantRepository;

        RuleFor(x => x.ProductVariantId)
            .NotEmpty().WithMessage("Product Variant id can't be empty ")
            .MustAsync(async (productVariantId, _) =>
                await ValidProductId(productVariantId))
            .WithMessage("Product Variant Id doesnt exist");


        RuleFor(x => x)
            .CustomAsync(async (dto, context, cancellationToken) =>
            {
                var currentStock = await _productVariantRepository.FindByCondition(pv => pv.Id == dto.ProductVariantId)
                    .Select(pv => pv.Stock).FirstOrDefaultAsync();

                if (currentStock < dto.Quantity)
                {
                    context.AddFailure("This quantity is not available in our stock");
                }
            });
    }


    private async Task<bool> ValidProductId(int productVariantId)
    {
        var product = await _productVariantRepository.FindByCondition(pr => pr.Id == productVariantId)
            .FirstOrDefaultAsync();

        return product is not null;
    }
}