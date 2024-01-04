namespace Clothick.Contracts.Interfaces.Services;

public interface IColorService
{
    Task<bool> IsColorNameUniqueAsync(string colorName);
}