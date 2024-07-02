namespace Application.QueryRequests.Users.CountUsers;

// TODO
// internal sealed class CountUsersQueryHandler(IUnitOfWork unitOfWork)
//     : IRequestHandler<CountUsersQuery, Result<ItemsCountDto>>
// {
//
//     public async Task<Result<ItemsCountDto>> Handle(CountUsersQuery request, CancellationToken cancellationToken)
//     {
//         var totalItemsCount = await unitOfWork.RetrieveRepository<User>().CountAsync();
//         var filteredItemsCount = await unitOfWork.RetrieveRepository<User>().CountAsync(request.RequestParameters);
//
//         var itemsCountDto = new ItemsCountDto(totalItemsCount, filteredItemsCount);
//         
//         return Result<ItemsCountDto>.Success(itemsCountDto);
//     }
// }