using Clothick.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Clothick.Api.Extensions;

public static class DatabaseExtension
{
    public static void AddDatabase(this IServiceCollection serices, IConfiguration configuration)
    {
        serices.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
    }
}