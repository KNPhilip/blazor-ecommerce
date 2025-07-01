using UseCases.Ports;

namespace DataAccess.Exceptions;

public sealed class EntityAlreadyExistsException : DataAccessException
{
    public EntityAlreadyExistsException() : base() { }
    public EntityAlreadyExistsException(string message) : base(message) { }
    public EntityAlreadyExistsException(string message, Exception innerException)
        : base(message, innerException) { }
}
