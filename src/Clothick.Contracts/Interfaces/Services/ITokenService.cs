using Clothick.Domain.Entities;

namespace Clothick.Contracts.Interfaces.Services;

public interface ITokenService
{
    Task<string> GenerateTokenAsync(User user);
}