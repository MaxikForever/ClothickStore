using Clothick.Api.DTO;
using Clothick.Contracts.Interfaces.Repositories;
using Clothick.Domain.Entities;

namespace Clothick.Api.Extensions.Mappers;

public static class GetCommentDtoExtensions
{
    public static GetCommentDto ToDto(this Comment comment, IBaseRepository<User> _userRepository)
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

    public static List<GetCommentDto> ToDtoList(this List<Comment> commentList, IBaseRepository<User> userRepository)
    {
        var commentListDto = (from comment in commentList
            let userName = userRepository.FindByCondition(u => u.Id == comment.UserId)
                .Select(u => u.UserName)
                .FirstOrDefault()
            select new GetCommentDto
            {
                Content = comment.Content, StarRating = comment.StarRating, DatePosted = comment.DatePosted,
                UserName = userName!
            }).ToList();

        return commentListDto;
    }
}