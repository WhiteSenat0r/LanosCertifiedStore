﻿using Domain.Contracts.Common;

namespace Domain.Contracts.RepositoryRelated;

public interface IFilteringRequestParameters<TEntity>
    where TEntity : class, IEntity<Guid>
{
    int PageIndex { get; set; }

    int ItemQuantity { get; set; }
    
    int MaxQuantityPerRequest { get; }
    
    string SortingType { get; set; }
}