public class UniqueService<T> : IUniqueService<T> where T : class, IEntity // IEntity should be an interface or base class that includes a Name property
{
    private readonly IMemoryCache _memoryCache;
    private readonly IBaseRepository<T> _repository;

    public UniqueService(IMemoryCache memoryCache, IBaseRepository<T> repository)
    {
        _memoryCache = memoryCache;
        _repository = repository;
    }

    public async Task<bool> IsNameUniqueAsync(string cacheKey, string name)
    {
        if (_memoryCache.TryGetValue(cacheKey, out List<string> cachedNames))
        {
            if (cachedNames.Contains(name))
            {
                return false; // Name is not unique
            }
        }
        else
        {
            cachedNames = await _repository.GetAll().Select(c => ((IEntity)c).Name).ToListAsync();
            _memoryCache.Set(cacheKey, cachedNames, TimeSpan.FromHours(1)); // Cache for 1 hour
        }

        return !cachedNames.Contains(name);
    }
}
