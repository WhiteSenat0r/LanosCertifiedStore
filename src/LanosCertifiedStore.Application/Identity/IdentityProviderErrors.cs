using Application.Shared.ResultRelated;

namespace Application.Identity;

public static class IdentityProviderErrors
{
    public static readonly Error EmailIsNotUnique = new Error(
        "EmailIsNotUnique",
        "The specified email is not unique!");
}