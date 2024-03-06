using Domain.Contracts.Common;
using Domain.Contracts.RepositoryRelated.Common;

namespace Application.RequestParams.Common.Classes;

public abstract class BaseFilteringRequestParameters<TEntity>(int maxItemsPerPageQuantity = 100) 
    : IFilteringRequestParameters<TEntity> 
    where TEntity : IIdentifiable<Guid>
{
    public int PageIndex { get; set; } = 1;

    public int ItemQuantity
    {
        get => MaxQuantityPerRequest;
        set => MaxQuantityPerRequest = value > MaxQuantityPerRequest ? MaxQuantityPerRequest : value;
    }

    public int MaxQuantityPerRequest { get; private set; } = maxItemsPerPageQuantity;

    public string? SortingType { get; set; }
}