using Domain.Contracts.RepositoryRelated;
using Domain.Entities.UserRelated;

namespace Domain.Contracts.RequestParametersRelated;

public interface IUserFilteringRequestParameters : IFilteringRequestParameters<User>
{
    string? FirstName { get; }
    string? LastName { get; }
    string? Email { get; }
}