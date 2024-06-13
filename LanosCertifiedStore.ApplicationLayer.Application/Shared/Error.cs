namespace Application.Shared;

public class Error(string code, string message)
{
    public static readonly Error None = new(string.Empty, string.Empty);
    public static Error NotFound => new( "NotFound", "The result with specified value is null");

    public string Code { get; } = code;
    public string Message { get; } = message;
}