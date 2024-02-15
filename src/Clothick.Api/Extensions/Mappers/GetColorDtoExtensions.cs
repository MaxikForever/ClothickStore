using Clothick.Api.DTO;
using Clothick.Domain.Entities;

namespace Clothick.Api.Extensions.Mappers;

public static class GetColorDtoExtensions
{
    public static List<GetColorDto> ToDtoList(this List<Color> entity)
    {
        var colorList = entity.Select(c => new GetColorDto() { Id = c.Id, Name = c.Name }).ToList();

        return colorList;
    }
}