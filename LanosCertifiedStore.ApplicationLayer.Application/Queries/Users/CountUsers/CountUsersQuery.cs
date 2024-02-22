using Application.Dtos.Common;
using Application.RequestParams;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Users.CountUsers;

public record CountUsersQuery(UserFilteringRequestParameters RequestParameters) : IRequest<Result<ItemsCountDto>>;