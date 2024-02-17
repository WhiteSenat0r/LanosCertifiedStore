namespace LanosCertifiedStore.InfrastructureLayer.Services.ImagesRelated.Common;

internal record CloudinarySettings
{
    public string CloudName { get; set; } = null!;
    public string ApiKey { get; set; } = null!;
    public string ApiSecret { get; set; } = null!;
}