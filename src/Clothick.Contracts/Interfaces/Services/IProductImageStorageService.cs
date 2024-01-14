using Microsoft.AspNetCore.Http;

namespace Clothick.Contracts.Interfaces.Services;

public interface IProductImageStorageService
{
    Task<string> SaveFileAsync(IFormFile file, string brandName);
}