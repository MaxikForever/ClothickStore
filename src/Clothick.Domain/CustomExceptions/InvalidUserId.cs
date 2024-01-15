namespace Clothick.Domain.CustomExceptions;

public class InvalidUserId : BaseException
{
    public InvalidUserId(string message, int statusCode = 400, string details = null!) : base(message, statusCode, details)
    {
        
    }
}