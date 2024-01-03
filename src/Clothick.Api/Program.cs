using Clothick.Api.Extensions;
using Clothick.Api.Middleware;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(o => o.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    }));
    builder.Services.AddDatabase(builder.Configuration);
    builder.Services.AddRepositories();
    builder.Services.AddMediator();
    builder.Services.AddValidationServices();
    builder.Services.AddAuthenticationService(builder.Configuration);
    builder.Services.AddCustomServices();
    builder.Services.ConfigureServices();
}

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();