using Domain.Contracts.Common;

namespace Application.Contracts.RepositoryRelated.Common;

public interface IFilteringRequestParameters<TModel>
    where TModel : IIdentifiable<Guid>
{
    int PageIndex { get; set; }
    int ItemQuantity { get; set; }
    int MaxQuantityPerRequest { get; }
    string? SortingType { get; set; }
}