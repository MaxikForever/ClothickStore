using Clothick.Api.DTO;
using Clothick.Domain.Entities;

namespace Clothick.Api.Extensions.Mappers;

public static class GetProductDtoExtensions
{
    public static GetProductWithImageDto ToDtoById(this Product product)
    {
        var productRatings = product.ProductRatings.Select(pr => pr);

        var productRatingsDto = productRatings.Select(rating => new GetProductRatingsDto
        {
            StarRating = rating.StarRating,
            DatePosted = rating.DatePosted
        }).ToList();

        var productTest = product.Category.Name;

        var result = new GetProductWithImageDto()
        {
            Id = product.Id,
            BrandName = product.BrandName,
            Title = product.Title,
            Description = product.Description,
            Price = product.Price,
            CategoryName = product.Category.Name,
            ProductRatings = productRatingsDto,
            Image = product.ProductVariants.Select(pv => pv.Images.Select(img => img.ImagePath).FirstOrDefault()).FirstOrDefault()
        };

        return result;
    }

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
            Title = product.Title,
            Description = product.Description,
            Price = product.Price,
            CategoryName = product.Category.Name,
            ProductRatings = productRatingsDto,
        };

        return result;
    }


    public static List<GetProductWithImageDto> ToDtoList(this IList<Product> products)
    {
        var getProductsDtoList = new List<GetProductWithImageDto>();

        foreach (var product in products)
        {
            var productRatings = product.ProductRatings.Select(pr => pr);

            var productRatingsDto = productRatings.Select(rating => new GetProductRatingsDto
            {
                StarRating = rating.StarRating,
                DatePosted = rating.DatePosted
            }).ToList();

            var productTest = product.Category.Name;

            var getProductDto = new GetProductWithImageDto
            {
                Id = product.Id,
                BrandName = product.BrandName,
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                CategoryName = product.Category.Name,
                ProductRatings = productRatingsDto,
                Image = product.ProductVariants.Select(pv => pv.Images.Select(im => im.ImagePath).FirstOrDefault()).FirstOrDefault()
            };

            getProductsDtoList.Add(getProductDto);
        }

        return getProductsDtoList;
    }
}