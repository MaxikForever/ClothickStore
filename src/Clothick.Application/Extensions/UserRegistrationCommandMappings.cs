using Clothick.Application.Commands.UserRegistrationCommands;
using Clothick.Application.Commands.UserRegistrationCommands.Products;
using Clothick.Domain.Entities;

namespace Clothick.Application.Extensions;

public static class UserRegistrationCommandMappings
{
    public static User ToEntity(this UserRegistrationCommand command)
    {
        return new User()
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            UserName = command.UserName,
            PasswordHash = command.Password
        };
    }
}

public static class UploadProductCommandMappings
{
    public static Product ToEntity(this UploadProductCommand request)
    {
        return new Product()
        {
            BrandName = request.Product.BrandName,
            Description = request.Product.Description,
            Price = request.Product.Price,
            SKU = request.Product.SKU,
            CategoryId = request.Product.CategoryId,
            ProductImages = request.Product.ProductImages.Select(url => new ProductImage { ImageURL = url.ImageURL })
                .ToList(),
            ProductVariants = request.Product.ProductVariants.Select(v => new ProductVariant
            {
                SizeID = v.SizeID,
                ColorID = v.ColorID,
                Stock = v.Stock,
                DiscountedPrice = v.DiscountedPrice
            }).ToList()
        };
    }
}