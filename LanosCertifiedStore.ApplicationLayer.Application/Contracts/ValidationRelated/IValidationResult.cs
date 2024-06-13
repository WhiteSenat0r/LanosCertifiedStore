using Application.Shared;

namespace Application.Contracts.ValidationRelated;

public interface IValidationResult
{
    public static readonly Error ValidationError = new(
        "ValidationError",
        "A validation problem has occured");

    Error[] Errors { get; }
}