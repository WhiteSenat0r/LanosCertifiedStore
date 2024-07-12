using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts.ApplicationDatabaseContext;

namespace IntegrationTests.Common;

public abstract class IntegrationTestBase : IClassFixture<IntegrationTestsWebApplicationFactory>
{
    private readonly IServiceScope _scope;
    private protected readonly ISender Sender;
    private protected readonly ApplicationDatabaseContext Context;

    private protected IntegrationTestBase(IntegrationTestsWebApplicationFactory factory)
    {
        _scope = factory.Services.CreateScope();
        Sender = _scope.ServiceProvider.GetRequiredService<ISender>();
        Context = _scope.ServiceProvider.GetRequiredService<ApplicationDatabaseContext>();
    }
}