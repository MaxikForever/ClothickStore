using Clothick.Contracts.Interfaces.Repositories;
using Clothick.Contracts.Interfaces.Services;
using Clothick.Domain.Constants;
using Clothick.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Clothick.Application.Services;

public class ProductVariantService : IProductVariantService
{
    private readonly IMemoryCache _memoryCache;
    private readonly IBaseRepository<Size> _sizeRepository;
    private readonly IBaseRepository<Color> _colorRepository;
    private readonly IBaseRepository<Category> _categoryRepository;

    public ProductVariantService(IMemoryCache memoryCache, IBaseRepository<Size> sizeRepository,
        IBaseRepository<Color> colorRepository, IBaseRepository<Category> categoryRepository)
    {
        _memoryCache = memoryCache;
        _sizeRepository = sizeRepository;
        _colorRepository = colorRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<bool> CheckIdsValidity(int sizeId, int colorId)
    {
        // Check for sizeId in cache
        bool sizeExists = await CheckIdInCacheOrDb(_sizeRepository, CacheKeyConstants.SizeIds, sizeId);

        // Check for colorId in cache
        bool colorExists = await CheckIdInCacheOrDb(_colorRepository, CacheKeyConstants.ColorIds, colorId);


        return sizeExists && colorExists;
    }

    public void UpdateCacheNames(string cacheKey, string newName)
    {
        HashSet<string> cacheNames;
        if (_memoryCache.TryGetValue(cacheKey, out cacheNames))
        {
            // Add the new ID to the cached set and reset the cache
            cacheNames.Add(newName);
            _memoryCache.Set(cacheKey, cacheNames, TimeSpan.FromHours(1));
        }
        else
        {
            // If the cache entry doesn't exist, create a new one with the new ID
            cacheNames = new HashSet<string> { newName };
            _memoryCache.Set(cacheKey, cacheNames, TimeSpan.FromHours(1));
        }
    }

    public async Task<bool> CheckCategoryIdsValidity(int categoryId)
    {
        // Check for categoryId in cache
        bool categoryExists = await CheckIdInCacheOrDb(_categoryRepository, CacheKeyConstants.CategoryIds, categoryId);

        return categoryExists;
    }

    private async Task<bool> CheckIdInCacheOrDb<T>(IBaseRepository<T> repository, string cacheKey, int id)
    {
        HashSet<int> cacheIds;
        if (!_memoryCache.TryGetValue(cacheKey, out cacheIds))
        {
            var entities = await repository.GetAll().ToListAsync();
            var ids = entities.Select(e => (int)e.GetType().GetProperty("Id").GetValue(e)).ToList();
            cacheIds = new HashSet<int>(ids);
            _memoryCache.Set(cacheKey, cacheIds, TimeSpan.FromHours(1));
        }

        return cacheIds.Contains(id);
    }

    public void UpdateCacheWithNewId(string cacheKey, int newId)
    {
        HashSet<int> cacheIds;
        if (_memoryCache.TryGetValue(cacheKey, out cacheIds))
        {
            // Add the new ID to the cached set and reset the cache
            cacheIds.Add(newId);
            _memoryCache.Set(cacheKey, cacheIds, TimeSpan.FromHours(1));
        }
        else
        {
            // If the cache entry doesn't exist, create a new one with the new ID
            cacheIds = new HashSet<int> { newId };
            _memoryCache.Set(cacheKey, cacheIds, TimeSpan.FromHours(1));
        }
    }
}