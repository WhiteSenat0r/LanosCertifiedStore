namespace LanosCertifiedStore.Infrastructure.Authentication.KeyCloak;

internal static class KeycloakRequiredActions
{
    public static List<string> GetVerifyEmailCode()
    {
        return ["VERIFY_EMAIL"];
    }
    
    public static List<string> GetUpdatePasswordCode()
    {
        return ["UPDATE_PASSWORD"];
    }
}