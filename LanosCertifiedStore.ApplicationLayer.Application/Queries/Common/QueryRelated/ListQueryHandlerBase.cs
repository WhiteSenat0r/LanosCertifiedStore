using Application.Contracts.RepositoryRelated.Common;
using Application.Core.Results;
using Application.Shared;
using AutoMapper;
using Domain.Contracts.Common;

namespace Application.Queries.Common.QueryRelated;

internal abstract class ListQueryHandlerBase<TEntity, TParamsType, TDto>(IUnitOfWork unitOfWork, IMapper mapper)
    where TEntity : class, IIdentifiable<Guid>
    where TParamsType : IFilteringRequestParameters<TEntity>
    where TDto : class
{
    protected async Task<Result<PaginationResult<TDto>>> Handle(ListQueryBase<TEntity, TParamsType> request,
        CancellationToken cancellationToken)
    {
        var items = await unitOfWork.RetrieveRepository<TEntity>().GetAllEntitiesAsync(
            request.RequestParameters);

        var mappedItems = mapper.Map<IReadOnlyList<TEntity>, IReadOnlyList<TDto>>(items);

        var returnedResult = new PaginationResult<TDto>(
            items: mappedItems,
            pageIndex: request.RequestParameters.PageIndex);

        return Result<PaginationResult<TDto>>.Success(returnedResult);
    }
}