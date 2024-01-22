using Clothick.Application.Commands.UserRegistrationCommands.Products;
using Clothick.Contracts.Interfaces.Repositories;
using Clothick.Contracts.Interfaces.Services;
using Clothick.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clothick.Application.Extensions;

public static class UpdateProductVariantCommandMappings
{
    public static async Task<ProductVariant> ToEntityAsync(this UpdateProductVariantCommand request,
        IProductImageStorageService imageStorageService, IBaseRepository<Domain.Entities.ProductVariant> repository)
    {
        var productVariant = await repository.FindByCondition(pv => pv.Id == request.Id)
            .Include(pv => pv.Size)
            .Include(pv => pv.Color)
            .Include(pv => pv.Images)
            .SingleOrDefaultAsync();


        if (productVariant == null)
        {
            // Handle the case where the product variant does not exist
            return null;
        }

        if (request.SizeId is not null)
        {
            productVariant.SizeID = request.SizeId.Value;
        }

        if (request.ColorId is not null)
        {
            productVariant.ColorID = request.ColorId.Value;
        }

        if (request.Stock.HasValue)
        {
            productVariant.Stock = request.Stock.Value;
        }

        if (request.DiscountedPrice.HasValue)
        {
            productVariant.DiscountedPrice = request.DiscountedPrice.Value;
        }

        if (!string.IsNullOrEmpty(request.SKU))
        {
            productVariant.SKU = request.SKU;
        }


        // Handle images
        if (request.Images is not null && request.Images.Any())
        {
            // Assuming you want to replace the existing images
            productVariant.Images.Clear();
            var images = await Task.WhenAll(request.Images.Select(async img =>
            {
                var imagePath = await imageStorageService.SaveFileAsync(img, request.SKU);
                return new Image() { ImagePath = imagePath };
            }));
            foreach (var img in images)
            {
                productVariant.Images.Add(img);
            }
        }

        return productVariant;
    }
}