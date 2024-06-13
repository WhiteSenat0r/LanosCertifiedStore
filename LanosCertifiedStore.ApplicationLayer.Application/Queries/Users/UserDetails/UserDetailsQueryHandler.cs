using Application.Contracts.RepositoryRelated.Common;
using Application.Dtos.IdentityDtos.ProfileDtos;
using Application.Shared;
using AutoMapper;
using Domain.Entities.UserRelated;
using MediatR;

namespace Application.Queries.Users.UserDetails;

internal sealed class UserDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UserDetailsQuery, Result<ProfileDto>>
{
    public async Task<Result<ProfileDto>> Handle(UserDetailsQuery request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.RetrieveRepository<User>().GetEntityByIdAsync(request.Id);

        if (user is null) return null!;

        var userToReturn = mapper.Map<User, ProfileDto>(user);

        return Result<ProfileDto>.Success(userToReturn);
    }
}