namespace LanosCertifiedStore.Application.Shared.ResultRelated;

public class Result
{
    public bool IsSuccess { get; init; }
    public Error? Error { get; private init; }

    public static Result Create(Error error)
    {
        if (error == Error.None)
        {
            return new Result(true, error);
        }

        return new Result(false, error);
    }

    protected Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None)
        {
            throw new InvalidOperationException();
        }

        if (!isSuccess && error == Error.None)
        {
            throw new InvalidOperationException();
        }

        Error = error;
        IsSuccess = isSuccess;
    }
}

public class Result<T> : Result
{
    protected Result(T? value, bool isSuccess, Error error) : base(isSuccess, error)
    {
        Value = value;
    }

    public T? Value { get; private init; }

    public static Result<T> Success(T value)
    {
        return new Result<T>(value, true, Error.None);
    }

    public static Result<T> Failure(Error error)
    {
        return new Result<T>(default, false, error);
    }

    public static implicit operator Result<T>(T value) => Success(value);
}