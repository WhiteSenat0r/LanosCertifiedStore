using Application.Dtos.Common;
using Domain.Contracts.RepositoryRelated;
using Domain.Entities.VehicleRelated.Classes;
using Domain.Shared;
using MediatR;

namespace Application.Queries.Users.CountUsers;

internal sealed class CountUsersQueryHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CountUsersQuery, Result<ItemsCountDto>>
{

    public async Task<Result<ItemsCountDto>> Handle(CountUsersQuery request, CancellationToken cancellationToken)
    {
        var totalItemsCount = await unitOfWork.RetrieveRepository<User>().CountAsync();
        var filteredItemsCount = await unitOfWork.RetrieveRepository<User>().CountAsync(request.RequestParameters);

        var itemsCountDto = new ItemsCountDto(totalItemsCount, filteredItemsCount);
        
        return Result<ItemsCountDto>.Success(itemsCountDto);
    }
}