namespace Persistence.Services.QueryRelated.Common.Contracts;

public interface IQueryMappings
{
    IReadOnlyDictionary<Type, Type> Get();
}