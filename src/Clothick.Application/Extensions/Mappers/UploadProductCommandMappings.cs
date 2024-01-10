using Clothick.Application.Commands.UserRegistrationCommands.Products;
using Clothick.Domain.Entities;

namespace Clothick.Application.Extensions;

public static class UploadProductCommandMappings
{
    public static Product ToEntity(this UploadProductCommand request)
    {
        return new Product()
        {
            BrandName = request.Product.BrandName,
            Description = request.Product.Description,
            Price = request.Product.Price,
            CategoryId = request.Product.CategoryId,
            ProductImages = request.Product.ProductImages.Select(url => new ProductImage { ImageURL = url.ImageURL })
                .ToList(),
            ProductVariants = request.Product.ProductVariants.Select(v => new ProductVariant
            {
                SizeID = v.SizeID,
                ColorID = v.ColorID,
                Stock = v.Stock,
                DiscountedPrice = v.DiscountedPrice,
                SKU = v.SKU
            }).ToList(),
            DateAdded = DateTime.UtcNow.Date,
            LastUpdated = DateTime.UtcNow.Date
        };
    }
}