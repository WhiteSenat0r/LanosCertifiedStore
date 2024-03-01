using Domain.Contracts.RepositoryRelated;
using Domain.Shared;

namespace Application.Commands.Common;

internal abstract class CommandBase<TReturnedValue>(IUnitOfWork unitOfWork) 
    where TReturnedValue : struct
{
    private protected string[] PossibleErrorMessages { get; init; } = null!;
    private protected string PossibleErrorCode { get; init; } = null!;
    private protected TReturnedValue ReturnedValue { get; set; } = default;

    private protected async Task<Result<TReturnedValue>> TrySaveChanges(
        CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

            return result
                ? Result<TReturnedValue>.Success(ReturnedValue)
                : Result<TReturnedValue>.Failure(
                    new Error(PossibleErrorCode, PossibleErrorMessages[0]));
        }
        catch
        {
            return Result<TReturnedValue>.Failure(
                new Error(PossibleErrorCode, PossibleErrorMessages[1]));
        }
    }
}