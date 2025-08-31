namespace UseCases.Ports;

public sealed class GatewayException : Exception
{
    public GatewayException() : base() { }
    public GatewayException(string message) : base(message) { }
    public GatewayException(string message, Exception innerException)
        : base(message, innerException) { }
}
