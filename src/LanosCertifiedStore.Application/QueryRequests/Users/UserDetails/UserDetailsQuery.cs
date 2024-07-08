using Application.Dtos.IdentityDtos.ProfileDtos;
using Application.Shared.ResultRelated;
using MediatR;

namespace Application.QueryRequests.Users.UserDetails;

public sealed record UserDetailsQuery(Guid Id) : IRequest<Result<ProfileDto>>;