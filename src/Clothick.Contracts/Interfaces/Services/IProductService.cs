using Clothick.Domain.Entities;

namespace Clothick.Contracts.Interfaces.Services;

public interface IProductService
{
    Task<Product?> GetProduct(int id);
}