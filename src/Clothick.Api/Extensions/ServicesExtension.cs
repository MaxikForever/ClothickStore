using System.Reflection;
using Clothick.Application.Services;
using Clothick.Contracts.Interfaces.Services;
using Clothick.Domain.Entities;

namespace Clothick.Api.Extensions;

public static class ServicesExtension
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductVariantService, ProductVariantService>();
        services.AddScoped<IUniqueService<Size>, UniqueService<Size>>();
        services.AddScoped<IUniqueService<Category>, UniqueService<Category>>();
        services.AddScoped<IUniqueService<Color>, UniqueService<Color>>();
        services.AddScoped<IProductRatingService, ProductRatingService>();
        services.AddScoped<IUserInfoService, UserInfoService>();
    }
}