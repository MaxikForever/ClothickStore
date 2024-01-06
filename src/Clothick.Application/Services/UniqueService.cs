using Clothick.Contracts.Interfaces.Repositories;
using Clothick.Contracts.Interfaces.Services;
using Clothick.Domain.Constants;
using Clothick.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Clothick.Application.Services;

public class UniqueService<T> : IUniqueService<T> where T : class, IEntity
{
    private readonly IMemoryCache _memoryCache;
    private readonly IBaseRepository<T> _colorRepository;

    public UniqueService(IMemoryCache memoryCache, IBaseRepository<T> colorRepository)
    {
        _memoryCache = memoryCache;
        _colorRepository = colorRepository;
    }

    public async Task<bool> IsNameUniqueAsync(string cacheKey,string names)
    {
        if (_memoryCache.TryGetValue(cacheKey, out List<string> cachedNames))
        {
            // Check the cache first
            if (cachedNames.Contains(names))
            {
                return false; // name is not unique
            }
        }
        else
        {
            // If not in cache, query the database
            cachedNames = await _colorRepository.GetAll().Select(c => c.Name).ToListAsync();
            _memoryCache.Set(cacheKey, cachedNames, TimeSpan.FromHours(1)); // Cache for 1 hour
        }

        return !cachedNames.Contains(names);
    }


}