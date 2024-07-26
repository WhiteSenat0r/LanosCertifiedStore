using LanosCertifiedStore.Persistence.Contexts.ApplicationDatabaseContext;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests.Common;

[Collection(CollectionName)]
public abstract class IntegrationTestBase : IClassFixture<IntegrationTestsWebApplicationFactory>, IDisposable
{
    private readonly IServiceScope _scope;
    private protected readonly ISender Sender;
    private protected readonly ApplicationDatabaseContext Context;

    private const string CollectionName = "Integration tests collection";
    private protected IntegrationTestBase(IntegrationTestsWebApplicationFactory factory)
    {
        _scope = factory.Services.CreateScope();
        Sender = _scope.ServiceProvider.GetRequiredService<ISender>();
        Context = _scope.ServiceProvider.GetRequiredService<ApplicationDatabaseContext>();
    }

    public void Dispose()
    {
        _scope.Dispose();
        Context.Dispose();
    }
}