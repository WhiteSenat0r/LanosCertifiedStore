using Application.Dtos.IdentityDtos.ProfileDtos;
using AutoMapper;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Users.ListUsers;

internal sealed class ListUsersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<ListUsersQuery, Result<IReadOnlyList<ProfileDto>>>
{
    public async Task<Result<IReadOnlyList<ProfileDto>>> Handle(ListUsersQuery request,
        CancellationToken cancellationToken)
    {
        var users = await unitOfWork.RetrieveRepository<User>()
            .GetAllEntitiesAsync(request.UserFilteringRequestParameters);

        var usersToReturn = mapper.Map<IReadOnlyList<User>, IReadOnlyList<ProfileDto>>(users);

        return Result<IReadOnlyList<ProfileDto>>.Success(usersToReturn);
    }
}