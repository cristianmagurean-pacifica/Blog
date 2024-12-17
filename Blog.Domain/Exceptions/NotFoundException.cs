namespace Blog.Domain.Exceptions;
public class NotFoundException : Exception
{
    public NotFoundException(string message, int id) : base($"{message} not found: {id}")
    {
    }

    public NotFoundException(string message, Exception inner) : base(message, inner)
    {
    }
}