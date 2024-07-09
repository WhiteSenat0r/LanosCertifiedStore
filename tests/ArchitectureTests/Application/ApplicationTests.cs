using System.Reflection;
using Application.Shared.RequestRelated;
using MediatR;

namespace ArchitectureTests.Application;

public sealed class ApplicationTests
{
    private static readonly Assembly DomainAssembly = typeof(ICommandRequest<>).Assembly;

    [Fact]
    public void RequestHandlersNames_Should_EndWithRequestHandler()
    {
        var handlerTypes = Types.InAssembly(DomainAssembly)
            .That()
            .ImplementInterface(typeof(IRequestHandler<,>))
            .GetTypes()
            .Where(handlerType => !handlerType.Name.EndsWith("RequestHandler"));

        handlerTypes.Should()
            .BeEmpty();
    }
}