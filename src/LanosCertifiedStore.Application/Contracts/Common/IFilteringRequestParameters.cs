using Application.RequestParameters.Common.Enums;
using Domain.Contracts.Common;

namespace Application.Contracts.Common;

public interface IFilteringRequestParameters<TModel>
    where TModel : IIdentifiable<Guid>
{
    int PageIndex { get; }
    ItemQuantitySelection ItemQuantity { get; }
    ItemQuantitySelection MaxQuantityPerRequest { get; }
    string? SortingType { get; }
}