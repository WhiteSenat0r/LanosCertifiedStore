using System.Reflection;
using LanosCertifiedStore.Presentation.Controllers.Common;
using Microsoft.AspNetCore.Mvc;

namespace ArchitectureTests.Presentation;

public sealed class PresentationTests
{
    private static readonly Assembly PresentationAssembly = typeof(BaseApiController).Assembly;

    [Fact]
    public void Controllers_Should_HaveRouteAttribute()
    {
        var result = Types
            .InAssembly(PresentationAssembly)
            .That()
            .Inherit(typeof(BaseApiController))
            .Should()
            .HaveCustomAttribute(typeof(RouteAttribute))
            .GetResult();

        var reason = "All controllers should have [Route] attribute, but found: " +
                     result.FailingTypeNames?.Aggregate((src, res) => src + ", " + res);

        result.IsSuccessful.Should().BeTrue(because: reason);
    }
}