using Domain.Contracts.Common;
using Domain.Contracts.RepositoryRelated;

namespace Application.Core;

public sealed class PaginationResult<T> 
    where T : IEntity<Guid>
{
    public PaginationResult(
        IEnumerable<T> items, IFilteringRequestParameters<T> filteringRequestParameters, int totalItemsQuantity)
    {
        Items = items;
        CurrentPageItemsQuantity = Items.Count();
        PageIndex = filteringRequestParameters.PageIndex;
        TotalItemsQuantity = totalItemsQuantity;
    }
    
    public IEnumerable<T> Items { get; }
    
    public int TotalItemsQuantity { get; }
    
    public int CurrentPageItemsQuantity { get; }
    
    public int PageIndex { get; }
}