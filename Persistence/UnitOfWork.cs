using Domain.Contracts.RepositoryRelated;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public sealed class UnitOfWork(DbContext context) : IUnitOfWork 
{
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await context.SaveChangesAsync(cancellationToken);
    }
}