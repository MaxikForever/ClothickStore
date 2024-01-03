using Clothick.Contracts.Interfaces.Repositories;
using Clothick.Contracts.Interfaces.Services;
using Clothick.Domain.Constants;
using Clothick.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Clothick.Application.Services;

public class ColorService : IColorService
{
    private readonly IMemoryCache _memoryCache;
    private readonly IBaseRepository<Color> _colorRepository;

    public ColorService(IMemoryCache memoryCache, IBaseRepository<Color> colorRepository)
    {
        _memoryCache = memoryCache;
        _colorRepository = colorRepository;
    }

    public async Task<bool> IsColorNameUniqueAsync(string colorName)
    {
        if (_memoryCache.TryGetValue("ColorNames", out List<string> cachedColorNames))
        {
            // Check the cache first
            if (cachedColorNames.Contains(colorName))
            {
                return false; // Color name is not unique
            }
        }
        else
        {
            // If not in cache, query the database
            cachedColorNames = await _colorRepository.GetAll().Select(c => c.Name).ToListAsync();
            _memoryCache.Set("ColorNames", cachedColorNames, TimeSpan.FromHours(1)); // Cache for 1 hour
        }

        return !cachedColorNames.Contains(colorName);
    }


}