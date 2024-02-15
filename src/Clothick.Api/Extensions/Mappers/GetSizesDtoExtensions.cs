using Clothick.Api.DTO;
using Clothick.Domain.Entities;

namespace Clothick.Api.Extensions.Mappers;

public static class GetSizesDtoExtensions
{
    public static List<GetSizesDto> ToDtoList(this List<Size> sizeList)
    {
        return sizeList.Select(s => new GetSizesDto() { Id = s.Id, Name = s.Name }).ToList();
    }
}