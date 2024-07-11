using System.Reflection;
using Domain.Contracts.Common;

namespace ArchitectureTests.Domain;

public sealed class DomainTests
{
    private static readonly Assembly DomainAssembly = typeof(IIdentifiable<>).Assembly;

    [Fact]
    public void Entities_Should_HavePublicParameterlessConstructor()
    {
        var entityTypes = Types.InAssembly(DomainAssembly)
            .That()
            .Inherit(typeof(IIdentifiable<>))
            .GetTypes();

        var failingTypes = new List<Type>();

        // ReSharper disable once LoopCanBeConvertedToQuery
        foreach (var entityType in entityTypes)
        {
            var constructors = entityType.GetConstructors(BindingFlags.Default);

            if (!constructors.Any(c => c.IsPublic && c.GetParameters().Length == 0))
            {
                failingTypes.Add(entityType);
            }
        }

        failingTypes.Should().BeEmpty();
    }
}