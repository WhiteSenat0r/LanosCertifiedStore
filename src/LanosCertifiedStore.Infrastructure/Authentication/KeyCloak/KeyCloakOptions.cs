﻿namespace LanosCertifiedStore.InfrastructureLayer.Services.Authentication.KeyCloak;

internal sealed class KeyCloakOptions
{
    public string AdminUrl { get; set; }
    public string TokenUrl { get; set; }
    public string ConfidentialClientId { get; set; }
    public string ConfidentialClientSecret { get; set; }
    public string PublicClientId { get; set; }
}