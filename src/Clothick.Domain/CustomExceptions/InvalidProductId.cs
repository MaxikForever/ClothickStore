namespace Clothick.Domain.CustomExceptions;

public class InvalidProductId : BaseException
{
    public InvalidProductId(string message, int statusCode = 404, string details = null!): base(message, statusCode, details)
    {
        
    }
}