namespace Domain.Contracts.RepositoryRelated;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}