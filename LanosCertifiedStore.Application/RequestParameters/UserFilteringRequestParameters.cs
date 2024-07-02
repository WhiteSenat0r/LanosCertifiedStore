using Application.Contracts.RequestParametersRelated;
using Application.RequestParameters.Common.Classes;
using Domain.Entities.UserRelated;

namespace Application.RequestParameters;

public sealed class UserFilteringRequestParameters : BaseFilteringRequestParameters<User>,
    IUserFilteringRequestParameters
{
    public string? FirstName { get; set; } 
    public string? LastName { get; set; }
    public string? Email { get; set; }
}