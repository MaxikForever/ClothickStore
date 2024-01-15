namespace Clothick.Domain.CustomExceptions;

public class CommentsNotFoundException : BaseException
{
    public CommentsNotFoundException(string message, int statusCode = 404, string details = null) : base(message, statusCode, details)
    {
        
    }
}