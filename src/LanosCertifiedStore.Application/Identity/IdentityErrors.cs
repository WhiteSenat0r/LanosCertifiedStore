using LanosCertifiedStore.Application.Shared.ResultRelated;

namespace LanosCertifiedStore.Application.Identity;

public static class IdentityErrors
{
    public static readonly Error SameEmailError = new(
        "SameEmailUpdate",
        "Current email address is identical to the new one!");

    public static readonly Error ResetPasswordError = new("ResetPasswordFailure", "Failed to reset password");
}