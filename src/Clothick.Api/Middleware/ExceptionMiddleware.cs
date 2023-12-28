using System.Net;
using Clothick.Domain.CustomExceptions;

namespace Clothick.Api.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger, RequestDelegate next)
    {
        _logger = logger;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong {ex}");
            await HandleException(context, ex);
        }
    }

    private Task HandleException(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        return context.Response.WriteAsync(new ErrorDetails
        {
            StatusCode = context.Response.StatusCode,
            Message = ex.Message
        }.ToString());
    }
}