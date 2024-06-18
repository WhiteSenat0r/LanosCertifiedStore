using Domain.Contracts.Common;

namespace Application.Contracts.RepositoryRelated.Common;

// public interface IUnitOfWork
// {
//     IRepository<TEntity> RetrieveRepository<TEntity>() where TEntity : IIdentifiable<Guid>;
//     Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
//     Task BeginTransactionAsync();
//     Task CommitTransactionAsync();
//     Task RollbackTransactionAsync();
//     void ClearChangeTrackerData();
//     Task DisposeAsync();
// }