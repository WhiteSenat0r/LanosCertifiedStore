using Domain.Contracts.Common;

namespace Application.Contracts;

public interface IDeleteCommand<TEntity>
    where TEntity : class, IIdentifiable<Guid>
{
    Task Execute(Guid deletedItemId, CancellationToken cancellationToken);
}