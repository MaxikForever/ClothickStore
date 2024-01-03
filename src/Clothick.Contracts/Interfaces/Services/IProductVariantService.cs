namespace Clothick.Contracts.Interfaces.Services;

public interface IProductVariantService
{
    public Task<bool> CheckIdsValidity(int sizeId, int colorId);
    void UpdateCacheWithNewId(string cacheKey, int newId);
    Task<bool> CheckCategoryIdsValidity(int categoryId);
}