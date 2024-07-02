namespace Application.Shared.ExceptionRelated;

public class ValidationException(string? message = default) : Exception(message);