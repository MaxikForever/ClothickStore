using Clothick.Api.DTO;
using Clothick.Application.Commands.UserRegistrationCommands.Products;
using Clothick.Domain.Entities;

namespace Clothick.Api.Extensions.Mappers;

public static class ProductUploadDtoExtensions
{
    public static UploadProductCommand ToCommand(this ProductUploadDto dto)
    {
        return new UploadProductCommand(
            new Product()
            {
                BrandName = dto.BrandName,
                Description = dto.Description,
                Price = dto.Price,
                SKU = dto.SKU,
                CategoryId = dto.CategoryId,
                ProductImages = dto.ImageURLs.Select(url => new ProductImage { ImageURL = url.ToString() })
                    .ToList(),
                ProductVariants = dto.Variants.Select(v => new ProductVariant
                {
                    SizeID = v.SizeId,
                    ColorID = v.ColorId,
                    Stock = v.Stock,
                    DiscountedPrice = v.DiscountedPrice
                }).ToList()
            });
    }
}