using Domain.Contracts.Common;

namespace Application.Core.Results;

public sealed class PaginationResult<T>
    where T : IIdentifiable<Guid>
{
    public PaginationResult(
        IEnumerable<T> items, 
        int pageIndex)
    {
        Items = items;
        CurrentPageItemsQuantity = Items.Count();
        PageIndex = pageIndex;
    }

    public IEnumerable<T> Items { get; }
    public int CurrentPageItemsQuantity { get; }
    public int PageIndex { get; }
}