using Clothick.Api.DTO;
using Clothick.Application.Commands.ProductVariant;

namespace Clothick.Api.Extensions.Mappers;

public static class UploadProductVariantDtoExtensions
{
    public static AddProductVariantsCommand ToCommand(this UploadProductVariantDto dto)
    {
        return new AddProductVariantsCommand
        (
            SizeId: dto.SizeId,
            ColorId: dto.ColorId,
            Stock: dto.Stock,
            DiscountedPrice: dto.DiscountedPrice,
            SKU: dto.SKU
        );
    }
}