using Domain.Contracts.Common;

namespace Application.Core.Results;

public sealed class PaginationResult<T>
    where T : IIdentifiable<Guid>
{
    public PaginationResult(
        IEnumerable<T> items, 
        int pageIndex, 
        int totalItemsQuantity, 
        int totalFilteredItemsQuantity)
    {
        Items = items;
        CurrentPageItemsQuantity = Items.Count();
        PageIndex = pageIndex;
        TotalItemsQuantity = totalItemsQuantity;
        TotalFilteredItemsQuantity = totalFilteredItemsQuantity;
    }

    public IEnumerable<T> Items { get; }

    public int TotalItemsQuantity { get; }
    
    public int TotalFilteredItemsQuantity { get; }

    public int CurrentPageItemsQuantity { get; }

    public int PageIndex { get; }
}