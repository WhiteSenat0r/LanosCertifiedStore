using Application.Contracts.RepositoryRelated.Common;
using Domain.Entities.UserRelated;

namespace Application.Contracts.RequestParametersRelated;

public interface IUserFilteringRequestParameters : IFilteringRequestParameters<User>
{
    string? FirstName { get; }
    string? LastName { get; }
    string? Email { get; }
}