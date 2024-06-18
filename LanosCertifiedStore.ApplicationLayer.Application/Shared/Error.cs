namespace Application.Shared;

public class Error
{
    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public static Error NotFound => new( "NotFound", "The result with specified value is null");

    public string Code { get; }
    public string Message { get; }
}