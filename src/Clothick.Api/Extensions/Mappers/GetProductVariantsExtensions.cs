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
            Id = pv.Id,
            Color = pv.Color.Name,
            DiscountedPrice = pv.DiscountedPrice,
            Size = pv.Size.Name,
            SKU = pv.SKU,
            Stock = pv.Stock,
            Images = pv.Images.Select(i => i.ImagePath).ToList()
        });
    }
}