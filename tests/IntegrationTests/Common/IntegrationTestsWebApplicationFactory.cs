using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
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
    private bool _dockerAvailable;
    private string? _dockerUnavailabilityReason;

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        if (!_dockerAvailable || _dbContainer == null || _keycloakContainer == null)
        {
            throw new InvalidOperationException(
                $"Docker is not available for integration tests. {_dockerUnavailabilityReason ?? "Please ensure Docker is running and properly configured."}");
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
        // Try to detect and configure Docker
        if (!await TryConfigureDockerAsync())
        {
            _dockerAvailable = false;
            return;
        }

        try
        {
            // Initialize containers
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

            await _dbContainer.StartAsync();
            await _keycloakContainer.StartAsync();
            _dockerAvailable = true;
        }
        catch (Exception ex)
        {
            _dockerAvailable = false;
            _dockerUnavailabilityReason = $"Failed to initialize Docker containers: {ex.Message}";
        }
    }

    private async Task<bool> TryConfigureDockerAsync()
    {
        try
        {
            // Check if Docker is running using docker command
            var isDockerRunning = await IsDockerRunningAsync();

            if (!isDockerRunning)
            {
                // Try to configure alternative Docker endpoints
                TryConfigureAlternativeDockerEndpoints();

                // Check again
                isDockerRunning = await IsDockerRunningAsync();
            }

            if (!isDockerRunning)
            {
                _dockerUnavailabilityReason = "Docker is not running or not accessible. " +
                    "Please ensure Docker Desktop or Docker daemon is running. " +
                    "You can verify by running 'docker ps' in a terminal. " +
                    "If Docker is running at a non-standard endpoint, set the DOCKER_HOST environment variable " +
                    "or configure it in ~/.testcontainers.properties file.";
                return false;
            }

            return true;
        }
        catch (Exception ex)
        {
            _dockerUnavailabilityReason = $"Error while detecting Docker: {ex.Message}";
            return false;
        }
    }

    private void TryConfigureAlternativeDockerEndpoints()
    {
        // Check if DOCKER_HOST is already set
        if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("DOCKER_HOST")))
        {
            return; // Use existing configuration
        }

        // Try to configure common alternative endpoints
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            // On Linux, try common socket locations
            var socketPaths = new[]
            {
                "/var/run/docker.sock",
                "/run/docker.sock"
            };

            foreach (var socketPath in socketPaths)
            {
                if (File.Exists(socketPath))
                {
                    Environment.SetEnvironmentVariable("DOCKER_HOST", $"unix://{socketPath}");
                    return;
                }
            }
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            // On Windows, try named pipe
            Environment.SetEnvironmentVariable("DOCKER_HOST", "npipe://./pipe/docker_engine");
        }
    }

    private async Task<bool> IsDockerRunningAsync()
    {
        try
        {
            var processStartInfo = new ProcessStartInfo
            {
                FileName = "docker",
                Arguments = "info",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var process = Process.Start(processStartInfo);
            if (process == null)
            {
                return false;
            }

            await process.WaitForExitAsync();
            return process.ExitCode == 0;
        }
        catch
        {
            return false;
        }
    }

    public new async Task DisposeAsync()
    {
        if (_dbContainer != null)
        {
            await _dbContainer.StopAsync();
            await _dbContainer.DisposeAsync();
        }

        if (_keycloakContainer != null)
        {
            await _keycloakContainer.StopAsync();
            await _keycloakContainer.DisposeAsync();
        }
    }
}