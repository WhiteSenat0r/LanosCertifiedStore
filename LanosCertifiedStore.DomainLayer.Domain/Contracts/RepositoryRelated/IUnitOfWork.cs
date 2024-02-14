using Domain.Contracts.Common;

namespace Domain.Contracts.RepositoryRelated;

public interface IUnitOfWork
{
    IRepository<TEntity> Repository<TEntity>() where TEntity : IEntity<Guid>;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}