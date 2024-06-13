using Application.Contracts.RequestParametersRelated;
using Application.Core.Results;
using Application.Dtos.IdentityDtos.ProfileDtos;
using Application.Shared;
using MediatR;

namespace Application.Queries.Users.ListUsers;

public sealed record ListUsersQuery(IUserFilteringRequestParameters UserFilteringRequestParameters)
    : IRequest<Result<PaginationResult<ProfileDto>>>;