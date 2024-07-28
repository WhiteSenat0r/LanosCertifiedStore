namespace LanosCertifiedStore.Infrastructure.Authentication.KeyCloak;

internal sealed record CredentialRepresentation(string Type, string Value, bool Temporary);