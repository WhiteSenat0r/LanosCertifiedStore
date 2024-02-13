using Domain.Contracts.Common;
using Domain.Contracts.RepositoryRelated;

namespace Application.QuerySpecifications.Common.Classes;

public abstract class BaseQuerySpecification<TEntity> : QuerySpecification<TEntity>
    where TEntity : class, IEntity<Guid>
{
    protected BaseQuerySpecification(IRequestParameters requestParameters)
    {
        DeterminateSortingType(requestParameters);
        AddPaging(requestParameters.ItemQuantity, 
            requestParameters.ItemQuantity * (requestParameters.PageIndex - 1));
    }
    
    private protected abstract void DeterminateSortingType(IRequestParameters requestParameters);
}