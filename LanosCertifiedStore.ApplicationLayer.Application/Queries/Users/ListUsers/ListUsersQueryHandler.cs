using Application.Core.Results;
using Application.Dtos.IdentityDtos.ProfileDtos;
using AutoMapper;
using Domain.Contracts.RepositoryRelated.Common;
using Domain.Entities.UserRelated;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Users.ListUsers;

internal sealed class ListUsersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<ListUsersQuery, Result<PaginationResult<ProfileDto>>>
{
    public async Task<Result<PaginationResult<ProfileDto>>> Handle(ListUsersQuery request,
        CancellationToken cancellationToken)
    {
        var users = await unitOfWork.RetrieveRepository<User>()
            .GetAllEntitiesAsync(request.UserFilteringRequestParameters);

        var mappedUsers = mapper.Map<IReadOnlyList<User>, IReadOnlyList<ProfileDto>>(users);

        var resultToReturn = new PaginationResult<ProfileDto>(
            items: mappedUsers,
            pageIndex: request.UserFilteringRequestParameters.PageIndex); // TODO

        return Result<PaginationResult<ProfileDto>>.Success(resultToReturn);
    }
}