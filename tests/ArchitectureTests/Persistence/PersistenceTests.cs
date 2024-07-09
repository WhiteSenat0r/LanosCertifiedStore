using System.Reflection;
using Persistence.Contexts.ApplicationDatabaseContext;
using Persistence.Queries.Common.Classes.QueryBaseRelated;

namespace ArchitectureTests.Persistence;

public sealed class PersistenceTests
{
    private static readonly Assembly PersistenceAssembly = typeof(ApplicationDatabaseContext).Assembly;

    [Fact]
    public void QueriesNames_Should_EndWithQuery()
    {
        var types = Types.InAssembly(PersistenceAssembly)
            .That()
            .Inherit(typeof(CollectionQueryBase<,>))
            .Or()
            .Inherit(typeof(CountQueryBase<>))
            .Or()
            .Inherit(typeof(SingleQueryBase<,>))
            .GetTypes()
            .Where(type => !type.Name.EndsWith("Query"));

        types.Should()
            .BeEmpty();
    }
}