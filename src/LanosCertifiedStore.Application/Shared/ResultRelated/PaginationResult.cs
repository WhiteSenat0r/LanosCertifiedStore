namespace LanosCertifiedStore.Application.Shared.ResultRelated;

public class PaginationResult<T>
{
    public IReadOnlyCollection<T> Items { get; }
    public int CurrentPageItemsQuantity { get; }
    public int PageIndex { get; }
    
    public PaginationResult(IReadOnlyCollection<T> items, int pageIndex)
    {
        Items = items;
        CurrentPageItemsQuantity = Items.Count;
        PageIndex = pageIndex;
    }
}