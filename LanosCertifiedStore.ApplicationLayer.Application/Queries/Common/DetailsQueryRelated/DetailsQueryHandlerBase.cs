using Application.Contracts.RepositoryRelated.Common;
using Application.Shared;
using AutoMapper;
using Domain.Contracts.Common;

namespace Application.Queries.Common.DetailsQueryRelated;

internal abstract class DetailsQueryHandlerBase<TEntity, TDto>(IUnitOfWork unitOfWork, IMapper mapper)
    where TEntity : class, IIdentifiable<Guid>
    where TDto : class
{
    protected async Task<Result<TDto>> Handle(DetailsQueryBase<TEntity> request,
        CancellationToken cancellationToken)
    {
        var item = await unitOfWork.RetrieveRepository<TEntity>().GetEntityByIdAsync(request.Id);

        if (item is null) return null!;
        
        var mappedItem = mapper.Map<TEntity, TDto>(item);

        return Result<TDto>.Success(mappedItem);
    }
}