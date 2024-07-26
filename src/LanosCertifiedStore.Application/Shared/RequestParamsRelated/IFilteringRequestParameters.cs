using LanosCertifiedStore.Domain.Contracts.Common;

namespace LanosCertifiedStore.Application.Shared.RequestParamsRelated;

public interface IFilteringRequestParameters<TModel>
    where TModel : IIdentifiable<Guid>
{
    int PageIndex { get; }
    ItemQuantitySelection ItemQuantity { get; }
    ItemQuantitySelection MaxQuantityPerRequest { get; }
    string? SortingType { get; }
}