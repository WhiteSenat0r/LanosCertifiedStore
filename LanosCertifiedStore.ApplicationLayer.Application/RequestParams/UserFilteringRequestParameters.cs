using Application.RequestParams.Common.Classes;
using Domain.Contracts.RequestParametersRelated;
using Domain.Entities.VehicleRelated.Classes;

namespace Application.RequestParams;

public sealed class UserFilteringRequestParameters : BaseFilteringRequestParameters<User>,
    IUserFilteringRequestParameters
{
    public string? FirstName { get; set; } 
    public string? LastName { get; set; }
    public string? Email { get; set; }
}