namespace Application.Shared.ResultRelated;

public class Result
{
    public bool IsSuccess { get; init; }
    public Error? Error { get; private init; }

    protected Result(bool isSuccess, Error error)
    {
        Error = error;
        IsSuccess = isSuccess;
    }
}

public class Result<T> : Result
{
    protected Result(T? value, bool isSuccess, Error? error) : base(isSuccess, error)
    {
        Value = value;

    }
    public T? Value { get; private init; }

    public static Result<T> Success(T value)
    {
        return new Result<T>(value, true, default);
    }

    public static Result<T> Failure(Error error)
    {
        return new Result<T>(default, false, error);
    }
    
    public static implicit operator Result<T>(T value) => Success(value);
}