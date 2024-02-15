namespace Domain.Shared;

public sealed class Result<T>
{
    public bool IsSuccess { get; init; }
    public T? Value { get; private init; }
    public Error? Error { get; private init; }

    public static Result<T> Success(T value)
    {
        return new Result<T>
        {
            IsSuccess = true,
            Value = value
        };
    }

    public static Result<T> Failure(Error error)
    {
        return new Result<T>
        {
            IsSuccess = false,
            Error = error
        };
    }
}