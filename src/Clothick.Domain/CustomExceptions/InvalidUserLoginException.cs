namespace Clothick.Domain.CustomExceptions;

public class InvalidUserLoginException : BaseException
{
    public InvalidUserLoginException(string message): base(message,404)
    {

    }
}