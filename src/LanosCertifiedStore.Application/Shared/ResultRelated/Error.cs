namespace Application.Shared.ResultRelated;

public class Error
{
    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public static Error NotFound(Guid resourceId) => new("NotFound", $"Resource with ID {resourceId} was not found!");

    public string Code { get; }
    public string Message { get; }
}