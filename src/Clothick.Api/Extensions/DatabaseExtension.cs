using Clothick.Domain.Entities;
using Clothick.Infrastructure.Persistence;
using Clothick.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Clothick.Api.Extensions;

public static class DatabaseExtension
{
    public static void AddDatabase(this IServiceCollection serices, IConfiguration configuration)
    {
        serices.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        serices.AddIdentity<User, IdentityRole<Guid>>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 6;
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        serices.AddHostedService<DatabaseMigrationService>();
    }
}