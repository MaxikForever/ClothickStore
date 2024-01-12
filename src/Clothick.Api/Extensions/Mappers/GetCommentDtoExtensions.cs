using Clothick.Api.DTO;
using Clothick.Contracts.Interfaces.Repositories;
using Clothick.Domain.Entities;

namespace Clothick.Api.Extensions.Mappers;

public static class GetCommentDtoExtensions
{
    public static GetCommentDto ToDto(this Comment comment,  IBaseRepository<User> _userRepository)
    {
        var userName = _userRepository.FindByCondition(u => u.Id == comment.UserId).Select(u => u.UserName)
            .FirstOrDefault();

        return new GetCommentDto
        {
            Content = comment.Content,
            StarRating = comment.StarRating,
            DatePosted = comment.DatePosted,
            UserName = userName!
        };
    }
}