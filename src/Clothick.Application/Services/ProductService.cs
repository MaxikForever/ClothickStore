using Clothick.Contracts.Interfaces.Repositories;
using Clothick.Contracts.Interfaces.Services;
using Clothick.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clothick.Application.Services;

public class ProductService : IProductService
{
    private readonly IBaseRepository<Product> _productRepository;

    public ProductService(IBaseRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product?> GetProduct(int id)
    {
        var product = await _productRepository.FindByCondition(p => p.Id == id)
            .Include(p => p.ProductVariants).ThenInclude(pv => pv.Size)
            .Include(p => p.ProductVariants).ThenInclude(pv => pv.Color)
            .Include(p => p.ProductRatings).ThenInclude(pr => pr.Comments)
            .Include(p => p.ProductImages)
            .Include(p => p.Category)
            .FirstOrDefaultAsync();

        return product;
    }
}