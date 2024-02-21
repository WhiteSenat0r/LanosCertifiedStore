using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;

namespace Domain.Contracts.RequestParametersRelated;

public interface IUserFilteringRequestParameters : IFilteringRequestParameters<User>
{
    string? FirstName { get; }
    string? LastName { get; }
    string? Email { get; }
}