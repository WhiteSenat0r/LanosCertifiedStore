using Application.Core.Results;
using Application.RequestParams.Common.Classes;
using AutoMapper;
using Domain.Contracts.Common;
using Domain.Contracts.RepositoryRelated;
using Domain.Shared;

namespace Application.Queries.Common.QueryRelated;

internal abstract class ListQueryHandlerBase<TEntity, TParamsType, TDto>(IUnitOfWork unitOfWork, IMapper mapper)
    where TEntity : class, IIdentifiable<Guid>
    where TParamsType : BaseFilteringRequestParameters<TEntity>
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