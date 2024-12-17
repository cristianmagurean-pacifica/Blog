namespace Blog.Domain.Exceptions;
public class InvalidConfigurationException : Exception
{
    public InvalidConfigurationException(string message) : base(message)
    {
    }

    public InvalidConfigurationException(string message, Exception inner) : base(message, inner)
    {
    }
}