using Clothick.Contracts.Interfaces.Repositories;
using Clothick.Contracts.Interfaces.Services;
using Clothick.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clothick.Application.Services;

public class ProductRatingService : IProductRatingService
{
    private readonly IBaseRepository<ProductRating> _productRatingRepository;

    public ProductRatingService(IBaseRepository<ProductRating> productRatingRepository)
    {
        _productRatingRepository = productRatingRepository;
    }

    public async Task<int?> GetProductRatingIdByProductIdAsync(int productId)
    {
        return await _productRatingRepository
            .FindByCondition(pr => pr.ProductID == productId).AsNoTracking()
            .Select(pr => pr.Id)
            .FirstOrDefaultAsync();
    }

    public async Task UpdateProductRatingAsync(int? productRatingId, decimal newCommentRating)
    {
        var productRating = await _productRatingRepository.FindByCondition(pr => pr.Id == productRatingId)
            .Include(c => c.Comments)
            .FirstOrDefaultAsync();

        if (productRating != null)
        {
            var totalRatings = productRating.Comments.Sum(c => c.StarRating) + newCommentRating;
            var totalRatingsCount = productRating.Comments.Count + 1;
            var newAverageRating = totalRatings / totalRatingsCount;


            productRating.StarRating = Math.Min(newAverageRating, 5);
        }


        _productRatingRepository.UpdateAsync(productRating);

        await _productRatingRepository.SaveAsync();
    }

    public async Task CreateInitialProductRatingAsync(int productId)
    {
        var newRating = new ProductRating()
        {
            ProductID = productId,
            StarRating = 0,
            DatePosted = DateTime.UtcNow
        };

        _productRatingRepository.CreateAsync(newRating);

        await _productRatingRepository.SaveAsync();

    }
}