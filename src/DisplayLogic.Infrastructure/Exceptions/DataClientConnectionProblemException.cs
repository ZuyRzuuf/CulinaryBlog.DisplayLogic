namespace DisplayLogic.Infrastructure.Exceptions;

[Serializable]
public class DataClientConnectionProblemException : Exception
{
    public DataClientConnectionProblemException()
    {
    }

    public DataClientConnectionProblemException(string message = "Cannot connect to the client")
        : base(message)
    {
    }

    public DataClientConnectionProblemException(string message, Exception? innerException)
        : base(message, innerException)
    {
    }
}