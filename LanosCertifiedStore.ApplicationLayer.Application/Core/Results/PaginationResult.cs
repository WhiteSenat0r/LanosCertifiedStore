namespace Application.Core.Results;

public sealed class PaginationResult<T>
{
    public IEnumerable<T> Items { get; }
    public int CurrentPageItemsQuantity { get; }
    public int PageIndex { get; }
    
    public PaginationResult(IEnumerable<T> items, int pageIndex)
    {
        Items = items;
        CurrentPageItemsQuantity = Items.Count();
        PageIndex = pageIndex;
    }
}