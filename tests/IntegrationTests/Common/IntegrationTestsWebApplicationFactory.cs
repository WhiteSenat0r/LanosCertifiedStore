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

    public bool IsDockerAvailable { get; private set; } = true;
    public string? DockerUnavailableReason { get; private set; }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        if (IsDockerAvailable)
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
                    options.AdminUrl = $"{keycloakAddress}admin/realms/lsc/";
                    options.TokenUrl = $"{keycloakRealmUrl}/protocol/openid-connect/token";
                });
            });
        }
        else
        {
            // Provide dummy configuration when Docker is not available
            // This prevents configuration errors, though tests will still fail
            // with a clear message that Docker is required
            builder.ConfigureTestServices(services =>
            {
                services.AddSingleton<ILoggerFactory, NullLoggerFactory>();
            });
        }
    }

    public async Task InitializeAsync()
    {
        try
        {
            await _dbContainer.StartAsync();
            await _keycloakContainer.StartAsync();
            IsDockerAvailable = true;
        }
        catch (Exception ex) when (ex.Message.Contains("Docker") ||
                                   ex.Message.Contains("docker") ||
                                   ex.Message.Contains("Cannot connect to Docker") ||
                                   ex.InnerException?.Message.Contains("Docker") == true ||
                                   ex.InnerException?.Message.Contains("docker") == true)
        {
            IsDockerAvailable = false;
            DockerUnavailableReason = $"Docker is not available or not running. Integration tests require Docker to run Testcontainers. Error: {ex.Message}";
        }
        catch (Exception ex)
        {
            // Catch other exceptions that might indicate Docker issues
            IsDockerAvailable = false;
            DockerUnavailableReason = $"Failed to initialize test containers. This likely means Docker is not available. Error: {ex.Message}";
        }
    }

    public new async Task DisposeAsync()
    {
        if (IsDockerAvailable)
        {
            await _dbContainer.StopAsync();
            await _keycloakContainer.StopAsync();
        }
    }
}