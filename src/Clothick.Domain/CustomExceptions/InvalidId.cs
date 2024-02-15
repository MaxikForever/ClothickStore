namespace Clothick.Domain.CustomExceptions;

public class InvalidId : BaseException
{
    public InvalidId(string message, int statusCode = 404, string details = null!): base(message, statusCode, details)
    {
        
    }
}