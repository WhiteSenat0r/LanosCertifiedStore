using Application.Contracts.RequestRelated;
using Domain.Contracts.Common;
using Persistence.Factories.QueryRelated.Common.Classes.Common.Classes.Constants;
using Persistence.Factories.QueryRelated.Common.Contracts;
using Persistence.Queries.Common.Contracts;

namespace Persistence.Factories.QueryRelated.Common.Classes;

internal sealed class QueryFactory(IEnumerable<object> queries) : IQueryFactory
{
    public IQuery<TModel, TResult> GetQuery<TModel, TResult, TQueryResult>(
        IQueryRequest<TModel, TResult, TQueryResult> queryRequest)
        where TModel : class, IIdentifiable<Guid>
        where TResult : notnull
        where TQueryResult : notnull
    {
        var query = GetQuery<TModel, TResult>(queries);

        return query;
    }

    private IQuery<TModel, TResult> GetQuery<TModel, TResult>(IEnumerable<object> queryObjects)
        where TModel : class, IIdentifiable<Guid>
        where TResult : notnull
    {
        foreach (var query in queryObjects)
        {
            var queryInterfaceType = query.GetType().BaseType!.GetInterfaces().First();

            if (queryInterfaceType!.GenericTypeArguments[0] != typeof(TModel) ||
                queryInterfaceType!.GenericTypeArguments[1] != typeof(TResult))
                continue;
            
            return (IQuery<TModel, TResult>)query;
        }

        throw new NullReferenceException(QueryFactoryConstants.NotFoundQuery);
    }
}