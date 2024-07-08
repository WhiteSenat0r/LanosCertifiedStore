using Application.Contracts.ServicesRelated.RequestRelated;
using Persistence.Contexts.ApplicationDatabaseContext;

namespace Persistence.Services;

internal sealed class TransactionService(ApplicationDatabaseContext context) : ITransactionService
{
    public async Task BeginTransaction(CancellationToken cancellationToken = default) =>
        await context.Database.BeginTransactionAsync(cancellationToken);

    public async Task CommitTransaction(CancellationToken cancellationToken = default) =>
        await context.Database.CommitTransactionAsync(cancellationToken);

    public async Task RollbackTransaction(CancellationToken cancellationToken = default) =>
        await context.Database.RollbackTransactionAsync(cancellationToken);
}