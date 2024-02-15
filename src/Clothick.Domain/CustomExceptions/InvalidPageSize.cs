namespace Clothick.Domain.CustomExceptions;

public class InvalidPageSize : BaseException
{
    public InvalidPageSize(string message, int statusCode = 400, string details = null!) : base(message, statusCode, details)
    {
        
    }
}