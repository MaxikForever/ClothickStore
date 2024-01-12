using Clothick.Api.Extensions;
using Clothick.Api.Middleware;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddDatabase(builder.Configuration);
    builder.Services.AddRepositories();
    builder.Services.AddMediator();
    builder.Services.AddValidationServices();
    builder.Services.AddAuthenticationService(builder.Configuration);
    builder.Services.AddCustomServices();
    builder.Services.ConfigureServices();
    builder.Services.AddSwaggerServices();
    builder.Services.AddLogging();
}

var app = builder.Build();


app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();