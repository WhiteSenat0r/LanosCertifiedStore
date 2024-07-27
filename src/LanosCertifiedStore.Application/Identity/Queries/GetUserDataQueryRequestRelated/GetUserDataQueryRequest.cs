using LanosCertifiedStore.Application.Shared.RequestRelated.QueryRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;

namespace LanosCertifiedStore.Application.Identity.Queries.GetUserDataQueryRequestRelated;

public sealed record GetUserDataQueryRequest(Guid Id) : IQueryRequest<Result<UserDataDto>>;