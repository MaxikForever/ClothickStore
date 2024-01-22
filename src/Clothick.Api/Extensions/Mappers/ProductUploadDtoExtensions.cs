using Clothick.Api.DTO;
using Clothick.Application.Commands.UserRegistrationCommands.Products;
using Clothick.Domain.Entities;

namespace Clothick.Api.Extensions.Mappers;

public static class ProductUploadDtoExtensions
{
    public static UploadProductCommand ToCommand(this ProductUploadDto dto)
    {
        return new UploadProductCommand(
            BrandName: dto.BrandName,
            Title: dto.Title,
            Description: dto.Description,
            Price: dto.Price,
            CategoryId: dto.CategoryId
        );
    }
}