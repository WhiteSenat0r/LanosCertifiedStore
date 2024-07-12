using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests;

public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestsWebApplicationFactory>
{
    private readonly IServiceScope _scope;
    private protected readonly ISender Sender; 
    public BaseIntegrationTest(IntegrationTestsWebApplicationFactory factory)
    {
        _scope = factory.Services.CreateScope();
        Sender = _scope.ServiceProvider.GetRequiredService<ISender>();

    }
}