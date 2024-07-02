using Application.Contracts.RepositoryRelated.Common;
using Application.RequestParameters.Common.Enums;
using Domain.Contracts.Common;

namespace Application.RequestParameters.Common.Classes;

public abstract class BaseFilteringRequestParameters<TModel> : IFilteringRequestParameters<TModel> 
    where TModel : IIdentifiable<Guid>
{
    private const int InitialPageIndex = 1;
    private int _pageIndex = InitialPageIndex;
    
    public int PageIndex
    {
        get => _pageIndex;
        set => _pageIndex = value < InitialPageIndex 
            ? InitialPageIndex 
            : value;
    }

    public ItemQuantitySelection ItemQuantity
    {
        get => MaxQuantityPerRequest;
        set => MaxQuantityPerRequest = (int)value > (int)MaxQuantityPerRequest ? MaxQuantityPerRequest : value;
    }

    public ItemQuantitySelection MaxQuantityPerRequest { get; private set; } = ItemQuantitySelection.Hundred;

    public string? SortingType { get; set; }
}