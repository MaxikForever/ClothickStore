namespace Clothick.Api.Extensions;

public static class FrameworkServices
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddMemoryCache();
    }
}