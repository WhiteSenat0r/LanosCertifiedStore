using System.Reflection;
using Application.Shared.RequestRelated;
using Application.Shared.RequestRelated.QueryRelated;
using MediatR;

namespace ArchitectureTests.Application;

public sealed class ApplicationTests
{
    private static readonly Assembly ApplicationAssembly = typeof(ICommandRequest<>).Assembly;

    [Fact]
    public void RequestHandlersNames_Should_EndWithRequestHandler()
    {
        var handlerTypes = GetTypesImplementingInterfaceNotEndingWith(typeof(IRequestHandler<,>), "RequestHandler");

        handlerTypes.Should().BeEmpty();
    }

    [Fact]
    public void RequestHandlers_Should_BeInternalAndSealed()
    {
        var types = Types.InAssembly(ApplicationAssembly)
            .That()
            .ImplementInterface(typeof(IRequestHandler<,>))
            .And().ArePublic()
            .And().AreNotSealed()
            .GetTypes();

        types.Should().BeEmpty();
    }

    [Fact]
    public void CommandRequestsNames_Should_EndWithCommandRequest()
    {
        var handlerTypes = GetTypesImplementingInterfaceNotEndingWith(typeof(ICommandRequest<>), "CommandRequest");

        handlerTypes.Should().BeEmpty();
    }

    [Fact]
    public void QueryRequestsNames_Should_EndWithQueryRequest()
    {
        var handlerTypes = GetTypesImplementingInterfaceNotEndingWith(typeof(IQueryRequest<,>), "QueryRequest");

        handlerTypes.Should().BeEmpty();
    }

    private static IEnumerable<Type> GetTypesImplementingInterfaceNotEndingWith(Type interfaceType, string endsWith)
    {
        return Types.InAssembly(ApplicationAssembly)
            .That()
            .ImplementInterface(interfaceType)
            .GetTypes()
            .ThatAreClasses()
            .Where(handlerType => !handlerType.Name.EndsWith(endsWith));
    }
}