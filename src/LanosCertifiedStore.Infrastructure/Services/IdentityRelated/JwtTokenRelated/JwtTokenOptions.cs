namespace LanosCertifiedStore.InfrastructureLayer.Services.Services.IdentityRelated.JwtTokenRelated;

internal sealed class JwtTokenOptions
{
    public string Issuer { get; set; } = default!;
    public string Audience { get; set; } = default!;
    public string SecretKey { get; set; } = default!;
}