namespace Application.Contracts.ServicesRelated.RequestRelated;

public interface ITransactionService
{
    Task BeginTransaction(CancellationToken cancellationToken);

    Task CommitTransaction(CancellationToken cancellationToken);

    Task RollbackTransaction(CancellationToken cancellationToken);
}