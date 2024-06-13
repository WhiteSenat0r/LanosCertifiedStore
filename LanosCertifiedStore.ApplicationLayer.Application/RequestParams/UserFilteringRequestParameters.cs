using Application.Contracts.RequestParametersRelated;
using Application.RequestParams.Common.Classes;
using Domain.Entities.UserRelated;

namespace Application.RequestParams;

public sealed class UserFilteringRequestParameters : BaseFilteringRequestParameters<User>,
    IUserFilteringRequestParameters
{
    public string? FirstName { get; set; } 
    public string? LastName { get; set; }
    public string? Email { get; set; }
}