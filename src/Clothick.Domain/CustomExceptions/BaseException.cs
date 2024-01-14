namespace Clothick.Domain.CustomExceptions;

public class BaseException : Exception
{
    public BaseException(string message, int statusCode = 500, string details = null!)
        : base(message)
    {
        StatusCode = statusCode;
        Details = details;
    }

    public int StatusCode { get; }
    public string Details { get; }
}