using Domain.Contracts.Common;

namespace Application.Core.Results;

public sealed class PaginationResult<T>
    where T : IIdentifiable<Guid>
{
    public PaginationResult(
        IEnumerable<T> items, 
        int pageIndex,
        int totalItemsCount,
        int totalFilteredItemsCount)
    {
        Items = items;
        CurrentPageItemsQuantity = Items.Count();
        PageIndex = pageIndex;
        TotalItemsCount = totalItemsCount;
        TotalFilteredItemsCount = totalFilteredItemsCount;
    }

    public int TotalItemsCount { get; }
    public int TotalFilteredItemsCount { get; }
    public IEnumerable<T> Items { get; }
    public int CurrentPageItemsQuantity { get; }
    public int PageIndex { get; }
}