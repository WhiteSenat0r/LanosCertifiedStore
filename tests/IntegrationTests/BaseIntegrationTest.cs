using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts.ApplicationDatabaseContext;

namespace IntegrationTests;

public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestsWebApplicationFactory>
{
    private readonly IServiceScope _scope;
    private protected readonly ISender Sender;
    private protected readonly ApplicationDatabaseContext Context;
    public BaseIntegrationTest(IntegrationTestsWebApplicationFactory factory)
    {
        _scope = factory.Services.CreateScope();
        Sender = _scope.ServiceProvider.GetRequiredService<ISender>();
        Context = _scope.ServiceProvider.GetRequiredService<ApplicationDatabaseContext>();
    }
}