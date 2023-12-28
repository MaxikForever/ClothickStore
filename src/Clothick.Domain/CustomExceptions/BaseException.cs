namespace Clothick.Domain.CustomExceptions;

public class BaseException : Exception
{
    public int StatusCode { get; }
    public string Details { get; }

    public BaseException(string message, int statusCode = 500, string details = null!)
        : base(message)
    {
        StatusCode = statusCode;
        Details = details;
    }
}