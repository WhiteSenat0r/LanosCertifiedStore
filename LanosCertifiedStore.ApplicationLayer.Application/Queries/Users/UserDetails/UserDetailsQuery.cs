using Application.Dtos.IdentityDtos.ProfileDtos;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Users.UserDetails;

public sealed record UserDetailsQuery(Guid Id) : IRequest<Result<ProfileDto>>;