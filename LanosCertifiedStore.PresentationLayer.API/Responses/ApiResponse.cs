namespace API.Responses;

internal class ApiResponse(int statusCode, string? message)
{
    public int StatusCode { get; init; } = statusCode;
    public string Message { get; init; } = message ?? GetDefaultMessageForStatusCode(statusCode);

    private static string GetDefaultMessageForStatusCode(int statusCode)
    {
        return statusCode switch
        {
            400 => "You have made a bad request",
            401 => "You are not authorised",
            404 => "Resource was not found",
            500 => "Internal server error has occurred",
            _ => null!
        };
    }
}