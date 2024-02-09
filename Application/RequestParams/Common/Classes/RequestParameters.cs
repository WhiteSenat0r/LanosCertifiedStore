using Domain.Contracts.RepositoryRelated;

namespace Application.RequestParams.Common.Classes;

public abstract class RequestParameters : IRequestParameters
{
    private int _itemQuantity = MaximumItemQuantity;

    public const int MaximumItemQuantity = 24;

    public int PageIndex { get; set; } = 1;

    public int ItemQuantity
    {
        get => _itemQuantity;
        set => _itemQuantity = value > MaximumItemQuantity ? MaximumItemQuantity : value;
    }

    public string SortingType { get; set; }
}