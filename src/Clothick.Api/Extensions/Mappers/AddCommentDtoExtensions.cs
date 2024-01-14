using Clothick.Api.DTO;
using Clothick.Application.Commands.Comment;

namespace Clothick.Api.Extensions.Mappers;

public static class AddCommentDtoExtensions
{
    public static AddCommentCommand ToCommand(this AddCommentDto dto, int productId)
    {
        return new AddCommentCommand(dto.Content, dto.StarRating, productId);
    }
}