namespace Clothick.Domain.CustomExceptions;

public class OrderIdNotFound : BaseException
{
    public OrderIdNotFound(string message, int statusCode = 404, string details = null!): base(message, statusCode, details)
    {
        
    }
}