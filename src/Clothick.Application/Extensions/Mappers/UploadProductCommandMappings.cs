using Clothick.Application.Commands.UserRegistrationCommands.Products;
using Clothick.Domain.Entities;

namespace Clothick.Application.Extensions;

public static class UploadProductCommandMappings
{
    public static async Task<Product> ToEntity(this UploadProductCommand request)
    {
        return new Product
        {
            BrandName = request.BrandName,
            Title = request.Title,
            Description = request.Description,
            Price = request.Price,
            CategoryId = request.CategoryId,
            DateAdded = DateTime.UtcNow,
            LastUpdated = DateTime.UtcNow
        };
    }
}