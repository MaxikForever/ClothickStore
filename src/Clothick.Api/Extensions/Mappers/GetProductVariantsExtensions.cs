using Clothick.Api.DTO;
using Clothick.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clothick.Api.Extensions.Mappers;

public static class GetProductVariantsExtensions
{
    public static async Task<IEnumerable<GetProductVariantDto>> ToDtoAsync(
        this IQueryable<ProductVariant> productVariantQuery)
    {
        var productVariants = await productVariantQuery.ToListAsync();
        return productVariants.Select(pv => new GetProductVariantDto
        {
            Color = pv.Color.Name,
            DiscountedPrice = pv.DiscountedPrice,
            Size = pv.Size.Name,
            SKU = pv.SKU,
            Stock = pv.Stock
        });
    }
}