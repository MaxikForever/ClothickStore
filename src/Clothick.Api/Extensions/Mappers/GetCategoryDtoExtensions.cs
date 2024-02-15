using Clothick.Api.DTO;
using Clothick.Domain.Entities;

namespace Clothick.Api.Extensions.Mappers;

public static class GetCategoryDtoExtensions
{
    public static List<GetCategoryDto> ToDtoList(this List<Category> entity)
    {
        var categoryList = entity.Select(c => new GetCategoryDto() { Id = c.Id, Name = c.Name }).ToList();

        return categoryList;
    }
}