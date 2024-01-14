using Clothick.Application.Commands.Comment;
using Clothick.Domain.Entities;

namespace Clothick.Application.Extensions;

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