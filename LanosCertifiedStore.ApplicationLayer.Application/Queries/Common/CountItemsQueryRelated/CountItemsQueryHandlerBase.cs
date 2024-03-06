using Application.Dtos.Common;
using Domain.Contracts.Common;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Shared;

namespace Application.Queries.Common.CountItemsQueryRelated;

internal abstract class CountItemsQueryHandlerBase<TEntity>(IUnitOfWork unitOfWork)
    where TEntity : class, IIdentifiable<Guid>
{
    protected async Task<Result<ItemsCountDto>> Handle(
        CountItemsQueryBase<TEntity> request, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.RetrieveRepository<TEntity>();
        
        var totalItemsCount = await repository.CountAsync();
        var filteredItemsCount = await repository.CountAsync(request.RequestParameters);

        var itemsCountDto = new ItemsCountDto(totalItemsCount, filteredItemsCount);
        
        return Result<ItemsCountDto>.Success(itemsCountDto);
    }
}