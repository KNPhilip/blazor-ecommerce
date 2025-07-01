using UseCases.Ports;

namespace DataAccess.Exceptions;

public sealed class NotFoundException : DataAccessException
{
    public NotFoundException() : base() { }
    public NotFoundException(string message) : base(message) { }
    public NotFoundException(string message, Exception innerException)
        : base(message, innerException) { }
}
