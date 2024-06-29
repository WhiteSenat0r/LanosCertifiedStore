namespace Application.Contracts.ServicesRelated.RequestRelated;

public interface ITransactionService
{
    Task BeginTransaction(CancellationToken cancellationToken = default);

    Task CommitTransaction(CancellationToken cancellationToken = default);

    Task RollbackTransaction(CancellationToken cancellationToken = default);

    Task SavePerformedChanges(CancellationToken cancellationToken = default);
}