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
    private PostgreSqlContainer? _dbContainer;
    private KeycloakContainer? _keycloakContainer;
    private bool _isDockerAvailable = true;

    public IntegrationTestsWebApplicationFactory()
    {
        try
        {
            _dbContainer = new PostgreSqlBuilder()
                .WithImage("postgres")
                .WithDatabase("LanosCertifiedStore")
                .WithUsername("postgres")
                .WithPassword("postgres")
                .Build();

            _keycloakContainer = new KeycloakBuilder()
                .WithImage("quay.io/keycloak/keycloak:25.0.1")
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
        }
        catch (ArgumentException ex) when (ex.Message.Contains("Docker is either not running or misconfigured"))
        {
            _isDockerAvailable = false;
        }
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        if (!_isDockerAvailable || _dbContainer == null || _keycloakContainer == null)
        {
            return;
        }

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
                options.AdminUrl = $"{keycloakAddress}admin/realms/lsc/";
                options.TokenUrl = $"{keycloakRealmUrl}/protocol/openid-connect/token";
            });
        });
    }

    public async Task InitializeAsync()
    {
        if (!_isDockerAvailable || _dbContainer == null || _keycloakContainer == null)
        {
            throw new Xunit.SkipException("Docker is not running or misconfigured. Integration tests require Docker to be running. Please ensure Docker is started and properly configured.");
        }

        await _dbContainer.StartAsync();
        await _keycloakContainer.StartAsync();
    }

    public new async Task DisposeAsync()
    {
        if (_dbContainer != null)
        {
            await _dbContainer.StopAsync();
        }

        if (_keycloakContainer != null)
        {
            await _keycloakContainer.StopAsync();
        }
    }
}