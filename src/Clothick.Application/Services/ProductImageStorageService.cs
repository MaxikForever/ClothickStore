using Clothick.Contracts.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace Clothick.Application.Services;

public class ProductImageStorageService : IProductImageStorageService
{
    public async Task<string> SaveFileAsync(IFormFile file, string brandName)
    {
        var fileName = $"{Guid.NewGuid()}_{brandName}{Path.GetExtension(file.FileName)}";

        var filePath = Path.Combine( Constants.Constants.StaticImageFolder, fileName);

        await using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return $"/images/{fileName}";
    }
}