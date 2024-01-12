using System.Reflection.Metadata.Ecma335;
using Clothick.Api.DTO;
using Clothick.Application.Commands.Comment;

namespace Clothick.Api.Extensions.Mappers;

public static class AddCommentDtoExtensions
{
    public static AddCommentCommand ToCommand(this AddCommentDto dto, int productId)
    {
        return new AddCommentCommand(Content: dto.Content, StarRating: dto.StarRating, ProductId: productId);
    }
}