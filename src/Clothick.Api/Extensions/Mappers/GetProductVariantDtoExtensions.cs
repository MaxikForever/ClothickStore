using Clothick.Api.DTO;
using Clothick.Domain.Entities;

namespace Clothick.Api.Extensions.Mappers;

public static class GetProductVariantDtoExtensions
{
    public static GetProductVariantDto ToDto(this ProductVariant product)
    {
        return new GetProductVariantDto
        {
            Id = product.Id,
            Size = product.Size.Name,
            Color = product.Color.Name,
            Stock = product.Stock,
            DiscountedPrice = product.DiscountedPrice,
            SKU = product.SKU,
            Images = product.Images.Select(img => img.ImagePath).ToList()
        };
    }
}