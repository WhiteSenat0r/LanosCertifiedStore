﻿using System.Linq.Expressions;

namespace Domain.Contracts.RepositoryRelated;

public interface IQuerySpecification<TEntity> 
    where TEntity : class
{
    Expression<Func<TEntity, bool>> Criteria { get; }

    List<Expression<Func<TEntity, object>>> Includes { get; }
    
    Expression<Func<TEntity, object>> OrderByAscendingExpression { get; }
    
    Expression<Func<TEntity, object>> OrderByDescendingExpression { get; }
    
    int SkippedItemsQuantity { get; }
    
    int TakenItemsQuantity { get; }
    
    bool IsPagingEnabled { get; set; }
    
    bool IsNotTracked { get; set; }
}