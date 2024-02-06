namespace API.Responses;

internal class ApiException(int statusCode, string message = null, string details = null)
    : ApiResponse(statusCode, message)
{
    public string Details { get; set; } = details;
}