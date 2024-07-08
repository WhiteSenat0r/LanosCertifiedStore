using Application.Identity.Dtos.ProfileDtos;
using Application.Shared.ResultRelated;
using MediatR;

namespace Application.Identity.Queries.UserDetails;

public sealed record UserDetailsQuery(Guid Id) : IRequest<Result<ProfileDto>>;