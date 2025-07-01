namespace UseCases;

public class Result
{
    public bool Success { get; }
    public bool Failure => !Success;
    public string? Error { get; }

    protected Result(bool success, string? errorMessage = null)
    {
        Success = success;
        Error = errorMessage;
    }

    public static Result Ok() => new(true);
    public static Result Fail(string errorMessage) =>
        new(false, errorMessage);

    public static Result<T> Ok<T>(T value) => new(value, true, string.Empty);
    public static Result<T> Fail<T>(string errorMessage) =>
        new(default, false, errorMessage);

    public static Result<T> FromValue<T>(T? value) =>
        value is not null ? Ok(value) : Fail<T>("The provided value was null.");
}

public class Result<T> : Result
{
    public T? Value { get; }

    protected internal Result(T? value, bool success, string errorMessage)
        : base(success, errorMessage)
    {
        Value = value;
    }

    public static implicit operator Result<T>(T value) => FromValue(value);
    public static implicit operator T?(Result<T> result) => result.Value;
}
