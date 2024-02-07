using Domain.Contracts.RepositoryRelated;
using Persistence.Contexts;

namespace Persistence;

internal sealed class UnitOfWork(ApplicationDatabaseContext context) : IUnitOfWork 
{
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await context.SaveChangesAsync(cancellationToken);
    }
}