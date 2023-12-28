using Clothick.Application.Services;
using Clothick.Contracts.Interfaces.Services;

namespace Clothick.Api.Extensions;

public static class ServicesExtension
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
    }
}