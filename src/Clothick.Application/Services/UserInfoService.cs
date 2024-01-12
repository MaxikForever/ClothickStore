using System.Security.Claims;
using Clothick.Contracts.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace Clothick.Application.Services;

public class UserInfoService : IUserInfoService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserInfoService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid GetUserId()
    {
        var claimsPrincipal = _httpContextAccessor.HttpContext?.User;
        var userIdClaim = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier);

        Guid.TryParse(userIdClaim?.Value, out var guidUserId);

        return guidUserId;
    }
}