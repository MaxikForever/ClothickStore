namespace Clothick.Contracts.Interfaces.Services;

public interface IUniqueService<T>
{
    Task<bool> IsNameUniqueAsync(string cacheKey, string names);
}