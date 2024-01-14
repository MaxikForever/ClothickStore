using Microsoft.Extensions.FileProviders;

namespace Clothick.Api.Extensions;

public static class StaticFilesExtension
{
    public static void UseCustomStaticFiles(this IApplicationBuilder app)
    {
        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "Images")),
            RequestPath = "/Images"
        });
    }
}