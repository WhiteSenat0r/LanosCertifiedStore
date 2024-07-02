using Domain.Contracts.Common;

namespace Application.Contracts;

public interface ICreateCommand<TEntity>
    where TEntity : class, IIdentifiable<Guid>
{
    Task Execute(TEntity addedItem, CancellationToken cancellationToken);
}