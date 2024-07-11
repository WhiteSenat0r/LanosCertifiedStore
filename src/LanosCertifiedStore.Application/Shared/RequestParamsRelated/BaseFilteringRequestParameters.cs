using Domain.Contracts.Common;

namespace Application.Shared.RequestParamsRelated;

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
        set => MaxQuantityPerRequest = (int)value > (int)MaxQuantityPerRequest ? value : MaxQuantityPerRequest;
    }

    public ItemQuantitySelection MaxQuantityPerRequest { get; private set; } = ItemQuantitySelection.Ten;

    public string? SortingType { get; set; }
}