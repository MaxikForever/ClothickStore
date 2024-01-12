using Clothick.Domain.Entities;

namespace Clothick.Contracts.Interfaces.Services;

public interface IProductRatingService
{
    Task<int?> GetProductRatingIdByProductIdAsync(int productId);

    Task UpdateProductRatingAsync(int? productRatingId, decimal newCommentRating);

    Task CreateInitialProductRatingAsync(int productId);
}

