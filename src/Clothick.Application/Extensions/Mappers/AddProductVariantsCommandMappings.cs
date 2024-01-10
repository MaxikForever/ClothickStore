using Clothick.Application.Commands.ProductVariant;
using Clothick.Domain.Entities;

namespace Clothick.Application.Extensions;

public static class AddProductVariantsCommandMappings
{
    public static ProductVariant ToEntity(this AddProductVariantsCommand request)
    {
        return new ProductVariant()
        {
            ProductID = request.ProductId,
            SizeID = request.SizeId,
            ColorID = request.ColorId,
            Stock = request.Stock,
            DiscountedPrice = request.DiscountedPrice,
            SKU = request.SKU
        };
    }
}