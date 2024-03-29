﻿using Domain.Contracts.Common;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Shared;

namespace Application.Commands.Common;

internal abstract class CommandHandlerBase<TReturnedValue>(IUnitOfWork unitOfWork)
    where TReturnedValue : struct
{
    private protected Error[] PossibleErrors { get; init; } = null!;
    private protected TReturnedValue ReturnedValue { get; set; } = default;

    private protected async Task<Result<TReturnedValue>> TrySaveChanges(
        CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await unitOfWork.SaveChangesAsync(cancellationToken) > 0;

            return result
                ? Result<TReturnedValue>.Success(ReturnedValue)
                : Result<TReturnedValue>.Failure(PossibleErrors[0]);
        }
        catch
        {
            return Result<TReturnedValue>.Failure(PossibleErrors[1]);
        }
    }

    private protected IRepository<TEntity> GetRequiredRepository<TEntity>()
        where TEntity : IIdentifiable<Guid> =>
        unitOfWork.RetrieveRepository<TEntity>();
}