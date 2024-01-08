using Clothick.Api.DTO;
using Clothick.Domain.Entities;

namespace Clothick.Api.Extensions.Mappers;

public static class GetProductDtoExtensions
{
    public static GetProductDto ToDto(this Product product)
    {
        var productVariants = product.ProductVariants.Select(pv => pv);

        var productVariantsDto = productVariants.Select(variant => new GetProductVariantDto()
        {
            Size = variant.Size.Name,
            Color = variant.Color.Name,
            Stock = variant.Stock,
            DiscountedPrice = variant.DiscountedPrice,
            SKU = variant.SKU,
        }).ToList();

        var productRatings = product.ProductRatings.Select(pr => pr);

        var productRatingsDto = productRatings.Select(rating => new GetProductRatingsDto()
        {
            StarRating = rating.StarRating,
            Comments = rating.Comments,
            DatePosted = rating.DatePosted
        }).ToList();

        var productTest = product.Category.Name;

        var result = new GetProductDto()
        {
            BrandName = product.BrandName,
            Description = product.Description,
            Price = product.Price,
            CategoryName = product.Category.Name,
            ProductVariants = productVariantsDto,
            ImageURLs = product.ProductImages.Select(url => url.ImageURL).ToList(),
            ProductRatings = productRatingsDto
        };

        return result;

    }
}