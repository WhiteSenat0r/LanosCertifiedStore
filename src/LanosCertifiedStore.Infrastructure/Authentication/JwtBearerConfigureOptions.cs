using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace LanosCertifiedStore.Infrastructure.Services.Authentication;

internal sealed class JwtBearerConfigureOptions(IConfiguration configuration) : IConfigureNamedOptions<JwtBearerOptions>
{
    private const string AuthenticationSectionName = "Authentication";
    
    public void Configure(JwtBearerOptions options)
    {
        configuration.GetSection(AuthenticationSectionName).Bind(options);
    }

    public void Configure(string? name, JwtBearerOptions options)
    {
        Configure(options);
    }
}