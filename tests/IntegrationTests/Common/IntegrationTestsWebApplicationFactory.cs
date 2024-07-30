using System.Net;
using DotNet.Testcontainers.Builders;
using LanosCertifiedStore.Infrastructure.Authentication.KeyCloak;
using LanosCertifiedStore.Presentation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Testcontainers.Keycloak;
using Testcontainers.PostgreSql;

namespace IntegrationTests.Common;

public sealed class IntegrationTestsWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly PostgreSqlContainer _dbContainer = new PostgreSqlBuilder()
        .WithImage("postgres")
        .WithDatabase("LanosCertifiedStore")
        .WithUsername("postgres")
        .WithPassword("postgres")
        .Build();

    private readonly KeycloakContainer _keycloakContainer = new KeycloakBuilder()
        .WithImage("quay.io/keycloak/keycloak:25.0.1")
        .WithEnvironment("DB_VENDOR", "h2")
        .WithResourceMapping(
            new FileInfo("keycloak/realms/lsc-realm-export.json"),
            new FileInfo("/opt/keycloak/data/import/realm.json"))
        .WithResourceMapping(
            new FileInfo("keycloak/themes/lsc-theme.jar"),
            new FileInfo("/opt/keycloak/providers/lsc-theme.jar"))
        .WithResourceMapping(
            new FileInfo("keycloak/validators/unique-attribute-validator.jar"),
            new FileInfo("/opt/keycloak/providers/unique-attribute-validator.jar"))
        .WithResourceMapping(
            new FileInfo("keycloak/listeners/custom-event-listener.jar"),
            new FileInfo("/opt/keycloak/providers/custom-event-listener.jar"))
        .WithCommand("--import-realm")
        .WithWaitStrategy(Wait.ForUnixContainer().UntilHttpRequestIsSucceeded(r => r
            .ForPath("/realms/master")
            .ForPort(8080)
            .ForStatusCode(HttpStatusCode.OK)))
        .Build();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        Environment.SetEnvironmentVariable(
            "ConnectionStrings:PostgreSqlConnection",
            _dbContainer.GetConnectionString()
        );

        var keycloakAddress = _keycloakContainer.GetBaseAddress();
        var keycloakRealmUrl = $"{keycloakAddress}realms/lsc";

        Environment.SetEnvironmentVariable(
            "Authentication:MetadataAddress",
            $"{keycloakRealmUrl}/.well-known/openid-configuration");

        Environment.SetEnvironmentVariable(
            "Authentication:TokenValidationParameters:ValidIssuer",
            keycloakRealmUrl);

        builder.ConfigureTestServices(services =>
        {
            // Silence logging for integration tests
            services.AddSingleton<ILoggerFactory, NullLoggerFactory>();
            services.Configure<KeycloakOptions>(options =>
            {
                options.AdminUrl = $"{keycloakAddress}/admin/realms/lsc/";
                options.TokenUrl = $"{keycloakRealmUrl}/protocol/openid-connect/token";
            });
        });
    }

    public async Task InitializeAsync()
    {
        await _dbContainer.StartAsync();
        await _keycloakContainer.StartAsync();
    }

    public new async Task DisposeAsync()
    {
        await _dbContainer.StopAsync();
        await _keycloakContainer.StopAsync();
    }
}