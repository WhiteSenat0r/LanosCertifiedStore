using Domain.Contracts.Common;

namespace Application.Contracts;

public interface IUpdateCommand<TEntity>
    where TEntity : class, IIdentifiable<Guid>
{
    Task Execute(TEntity updatedItem, CancellationToken cancellationToken);
}