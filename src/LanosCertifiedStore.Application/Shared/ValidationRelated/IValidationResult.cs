using Application.Shared.ResultRelated;

namespace Application.Shared.ValidationRelated;

public interface IValidationResult
{
    public static readonly Error ValidationError = new(
        "ValidationError",
        "A validation problem has occured");

    Error[] Errors { get; }
}