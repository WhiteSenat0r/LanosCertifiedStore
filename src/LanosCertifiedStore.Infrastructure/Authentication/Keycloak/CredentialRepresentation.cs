﻿namespace LanosCertifiedStore.Infrastructure.Authentication.Keycloak;

internal sealed record CredentialRepresentation(string Type, string Value, bool Temporary);