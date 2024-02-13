using Clothick.Api.DTO;
using Clothick.Application.Commands.UserRegistrationCommands.Products;
using Microsoft.AspNetCore.Components;

namespace Clothick.Api.Extensions.Mappers;

public static class UpdateProductVariantDtoExtensions
{
    public static UpdateProductVariantCommand ToCommand(this UpdateProductVariantDto dto, int productVariantId)
    {
        return new UpdateProductVariantCommand
        (
            Id: productVariantId,
            SizeId: dto.SizeId,
            ColorId: dto.ColorId,
            Stock: dto.Stock,
            DiscountedPrice: dto.DiscountedPrice,
            SKU: dto.SKU,
            Images: dto.Images
        );
    }
}