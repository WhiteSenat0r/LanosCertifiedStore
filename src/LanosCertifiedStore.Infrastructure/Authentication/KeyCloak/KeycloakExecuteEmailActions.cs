namespace LanosCertifiedStore.Infrastructure.Authentication.KeyCloak;

internal sealed class KeycloakExecuteEmailActions
{
    public string ActionCode { get; init; } = null!;

    public static KeycloakExecuteEmailActions VerifyEmail()
    {
        return new KeycloakExecuteEmailActions
        {
            ActionCode = "[VERIFY_EMAIL]"
        };
    }
    
    public static KeycloakExecuteEmailActions UpdatePassword()
    {
        return new KeycloakExecuteEmailActions
        {
            ActionCode = "[UPDATE_PASSWORD]"
        };
    }
}