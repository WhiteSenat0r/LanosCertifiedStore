using Domain.Contracts.Common;
using Domain.Contracts.RepositoryRelated;
using Persistence.Contexts;

namespace Persistence;

internal sealed class UnitOfWork(ApplicationDatabaseContext context) : IUnitOfWork 
{
    public IRepository<TEntity> Repository<TEntity>() where TEntity : IEntity<Guid>
    {
        throw new NotImplementedException();
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await context.SaveChangesAsync(cancellationToken);
    }
} 