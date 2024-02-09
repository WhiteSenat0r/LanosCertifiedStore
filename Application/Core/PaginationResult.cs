using Domain.Contracts.RepositoryRelated;

namespace Application.Core;

public sealed class PaginationResult<T>
{
    public PaginationResult(
        IEnumerable<T> items, IRequestParameters requestParameters, int totalItemsQuantity)
    {
        Items = items;
        CurrentPageItemsQuantity = Items.Count();
        PageIndex = requestParameters.PageIndex;
        TotalItemsQuantity = totalItemsQuantity;
    }
    
    public IEnumerable<T> Items { get; }
    
    public int TotalItemsQuantity { get; }
    
    public int CurrentPageItemsQuantity { get; }
    
    public int PageIndex { get; }
}