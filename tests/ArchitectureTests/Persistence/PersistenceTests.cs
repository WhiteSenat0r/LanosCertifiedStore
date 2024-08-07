﻿using System.Reflection;
using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using LanosCertifiedStore.Persistence.Queries.Common.Classes.QueryBaseRelated;

namespace ArchitectureTests.Persistence;

public sealed class PersistenceTests
{
    private static readonly Assembly PersistenceAssembly = typeof(ApplicationDatabaseContext).Assembly;

    [Fact]
    public void QueriesNames_Should_EndWithQuery()
    {
        var types = Types.InAssembly(PersistenceAssembly)
            .That().AreNotAbstract()
            .And().Inherit(typeof(CollectionQueryBase<,>))
            .Or().Inherit(typeof(CountQueryBase<>))
            .Or().Inherit(typeof(SingleQueryBase<,>))
            .GetTypes()
            .Where(type => !type.Name.EndsWith("Query"));

        types.Should()
            .BeEmpty();
    }
}