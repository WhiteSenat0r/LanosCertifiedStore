using Domain.Contracts.RepositoryRelated;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Common;

internal abstract class CommandBase(
    IUnitOfWork unitOfWork)
{
    private protected string[] PossibleErrorMessages { get; init; } = null!;
    private protected string PossibleErrorCode { get; init; } = null!;

    private protected async Task<Result<Unit>> TrySaveChanges(
        CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

            return result
                ? Result<Unit>.Success(Unit.Value)
                : Result<Unit>.Failure(
                    new Error(PossibleErrorCode, PossibleErrorMessages[0]));
        }
        catch
        {
            return Result<Unit>.Failure(
                new Error(PossibleErrorCode, PossibleErrorMessages[1]));
        }
    }
}