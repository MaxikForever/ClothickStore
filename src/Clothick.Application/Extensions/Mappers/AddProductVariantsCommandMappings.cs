using Clothick.Application.Commands.Comment;
using Clothick.Application.Commands.ProductVariant;
using Clothick.Domain.Entities;

namespace Clothick.Application.Extensions;

public static class AddProductVariantsCommandMappings
{
    public static ProductVariant ToEntity(this AddProductVariantsCommand request)
    {
        return new ProductVariant()
        {
            ProductID = request.ProductId,
            SizeID = request.SizeId,
            ColorID = request.ColorId,
            Stock = request.Stock,
            DiscountedPrice = request.DiscountedPrice,
            SKU = request.SKU
        };
    }
}

public static class AddCommentsCommandMappings
{
    public static Comment ToEntity(this AddCommentCommand command, int? productRatingId, Guid userId)
    {
        return new Comment
        {
            Content = command.Content,
            StarRating = command.StarRating,
            DatePosted = DateTime.UtcNow,
            ProductRatingId = (int)productRatingId!,
            UserId = userId
        };
    }
}