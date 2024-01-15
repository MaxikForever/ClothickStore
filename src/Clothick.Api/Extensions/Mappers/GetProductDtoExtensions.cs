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
            DatePosted = rating.DatePosted
        }).ToList();

        var productTest = product.Category.Name;

        var result = new GetProductDto
        {
            Id = product.Id,
            BrandName = product.BrandName,
            Description = product.Description,
            Price = product.Price,
            CategoryName = product.Category.Name,
            ProductRatings = productRatingsDto
        };

        return result;
    }


    public static List<GetProductDto> ToDtoList(this IList<Product> products)
    {
        var getProductsDtoList = new List<GetProductDto>();

        foreach (var product in products)
        {
            var productRatings = product.ProductRatings.Select(pr => pr);

            var productRatingsDto = productRatings.Select(rating => new GetProductRatingsDto
            {
                StarRating = rating.StarRating,
                DatePosted = rating.DatePosted
            }).ToList();

            var productTest = product.Category.Name;

            var getProductDto = new GetProductDto
            {
                Id = product.Id,
                BrandName = product.BrandName,
                Description = product.Description,
                Price = product.Price,
                CategoryName = product.Category.Name,
                ProductRatings = productRatingsDto
            };

            getProductsDtoList.Add(getProductDto);
        }

        return getProductsDtoList;
    }
}