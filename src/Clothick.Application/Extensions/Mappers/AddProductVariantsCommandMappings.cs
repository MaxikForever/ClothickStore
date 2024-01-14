using Clothick.Application.Commands.ProductVariant;
using Clothick.Application.Commands.UserRegistrationCommands.Products;
using Clothick.Contracts.Interfaces.Services;
using Clothick.Domain.Entities;

namespace Clothick.Application.Extensions;

public static class AddProductVariantsCommandMappings
{
    public static async Task<ProductVariant> ToEntity(
        this UploadProductVariantCommand request,
        IProductImageStorageService imageStorageService)
    {
        var images = await Task.WhenAll(request.Images.Select(async img =>
        {
            var imagePath = await imageStorageService.SaveFileAsync(img, request.SKU);
            return imagePath;
        }));

        var productVariant = new ProductVariant
        {
            ProductID = request.ProductId,
            SizeID = request.SizeId,
            ColorID = request.ColorId,
            Stock = request.Stock,
            DiscountedPrice = request.DiscountedPrice,
            SKU = request.SKU,
            Images = new List<Image>()
        };

        foreach (var imgPath in images)
        {
            productVariant.Images.Add(new Image() { ImagePath = imgPath });
        }

        return productVariant;
    }
}