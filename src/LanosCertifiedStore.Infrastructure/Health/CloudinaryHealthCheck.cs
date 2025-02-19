using System.Net;
using CloudinaryDotNet;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace LanosCertifiedStore.Infrastructure.Health;

internal sealed class CloudinaryHealthCheck(ICloudinary cloudinarySource) : IHealthCheck
{
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
        CancellationToken cancellationToken = new())
    {
        var result = await cloudinarySource.PingAsync(cancellationToken);

        return result.StatusCode == HttpStatusCode.OK
            ? HealthCheckResult.Healthy()
            : HealthCheckResult.Unhealthy();
    }
}