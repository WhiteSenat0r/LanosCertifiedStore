using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace LanosCertifiedStore.Infrastructure.Images;

internal sealed class CloudinaryConfigureOptions(IConfiguration configuration) : IConfigureNamedOptions<CloudinaryOptions>
{
    private const string CloudinarySectionName = "Cloudinary";
    
    public void Configure(CloudinaryOptions options)
    {
        configuration.GetSection(CloudinarySectionName).Bind(options);
    }

    public void Configure(string? name, CloudinaryOptions options)
    {
        Configure(options);
    }
}