using Application.Core.Results;
using Application.Dtos.IdentityDtos.ProfileDtos;
using Domain.Contracts.RequestParametersRelated;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Users.ListUsers;

public sealed record ListUsersQuery(IUserFilteringRequestParameters UserFilteringRequestParameters)
    : IRequest<Result<PaginationResult<ProfileDto>>>;