using Domain.Contracts.Common;
using Domain.Contracts.RepositoryRelated;

namespace Application.RequestParams.Common.Classes;

internal abstract class BaseFilteringRequestParameters<TEntity>(int maxItemsPerPageQuantity) 
    : IFilteringRequestParameters<TEntity> 
    where TEntity : IEntity<Guid>
{
    public int PageIndex { get; set; } = 1;

    public int ItemQuantity
    {
        get => MaxQuantityPerRequest;
        set => MaxQuantityPerRequest = value > MaxQuantityPerRequest ? MaxQuantityPerRequest : value;
    }

    public int MaxQuantityPerRequest { get; private set; } = maxItemsPerPageQuantity;

    public string SortingType { get; set; } = null!;
}