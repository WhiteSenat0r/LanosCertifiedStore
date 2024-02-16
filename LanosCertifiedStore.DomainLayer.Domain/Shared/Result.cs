namespace Domain.Shared;

public class Result<T>
{
    protected Result(T? value, bool isSuccess, Error? error)
    {
        Value = value;
        Error = error;
        IsSuccess = isSuccess;
    }

    public bool IsSuccess { get; init; }
    public T? Value { get; private init; }
    public Error? Error { get; private init; }

    public static Result<T> Success(T value)
    {
        return new Result<T>(value, true, default);
    }

    public static Result<T> Failure(Error error)
    {
        return new Result<T>(default, false, error);
    }
}