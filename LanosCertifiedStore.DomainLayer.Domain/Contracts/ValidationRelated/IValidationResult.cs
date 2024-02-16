using Domain.Shared;

namespace Domain.Contracts.ValidationRelated;

public interface IValidationResult
{
    public static readonly Error ValidationError = new(
        "ValidationError",
        "A validation problem has occured");

    Error[] Errors { get; }
}