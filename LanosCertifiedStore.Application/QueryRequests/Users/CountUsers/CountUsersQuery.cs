using Application.Dtos.Common;
using Application.RequestParameters;
using Application.Shared.ResultRelated;
using MediatR;

namespace Application.QueryRequests.Users.CountUsers;

// public record CountUsersQuery(UserFilteringRequestParameters RequestParameters) : IRequest<Result<ItemsCountDto>>;