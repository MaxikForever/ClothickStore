using Clothick.Api.DTO;
using Clothick.Domain.Entities;

namespace Clothick.Api.Extensions.Mappers;

public static class GetProductDtoExtensions
{
    public static GetProductDto ToDto(this Product product)
    {
        var productRatings = product.ProductRatings.Select(pr => pr);

        var productRatingsDto = productRatings.Select(rating => new GetProductRatingsDto
        {
            StarRating = rating.StarRating,
            Comments = rating.Comments,
            DatePosted = rating.DatePosted
        }).ToList();

        var productTest = product.Category.Name;

        var result = new GetProductDto
        {
            BrandName = product.BrandName,
            Description = product.Description,
            Price = product.Price,
            CategoryName = product.Category.Name,
            ProductRatings = productRatingsDto
        };

        return result;
    }
}