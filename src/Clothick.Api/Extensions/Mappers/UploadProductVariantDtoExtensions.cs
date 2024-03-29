using Clothick.Api.DTO;
using Clothick.Application.Commands.ProductVariant;
using Clothick.Application.Commands.UserRegistrationCommands.Products;

namespace Clothick.Api.Extensions.Mappers;

public static class UploadProductVariantDtoExtensions
{
    public static UploadProductVariantCommand ToCommand(this UploadProductVariantDto dto, int productVariantId)
    {
        return new UploadProductVariantCommand
        (
            ProductId: productVariantId,
            SizeId: dto.SizeId,
            ColorId: dto.ColorId,
            Stock: dto.Stock,
            DiscountedPrice: dto.DiscountedPrice,
            SKU: dto.SKU,
            Images: dto.Images
        );
    }
}