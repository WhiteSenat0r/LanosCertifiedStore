using Domain.Contracts.Common;

namespace Domain.Contracts.RepositoryRelated;

public interface IUnitOfWork
{
    IRepository<TEntity> RetrieveRepository<TEntity>() where TEntity : IIdentifiable<Guid>;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    void ClearChangeTrackerData();
    Task DisposeAsync();
}