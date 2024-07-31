using LanosCertifiedStore.Infrastructure.Authentication.KeyCloak;

namespace IntegrationTests.Identity;

internal static class TestExemplars
{
    internal const string AdminEmail = "admin@test.com";
    internal const string UserEmail = "test@test.com";
    internal const string Password = "123";

    internal static string PhoneNumber1 = "+380681234567";
    internal static string PhoneNumber2 = "+381234567890";

    internal static UserRepresentationWithPasswordAndId GetCorrectUserRepresentationWithPasswordAndId(
        string email,
        string password,
        string phoneNumber)
    {
        var attributes = new Dictionary<string, string>
        {
            { "phoneNumber", phoneNumber }
        };

        return new UserRepresentationWithPasswordAndId(
            default,
            email,
            email,
            true,
            true,
            attributes,
            "test",
            "test",
            [new CredentialRepresentation("password", password, false)]);
    }
}