using Clothick.Contracts.Interfaces.Repositories;
using Clothick.Infrastructure.Persistence.Repositories;

namespace Clothick.Api.Extensions;

public static class RepositoriesExtension
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
    }
}