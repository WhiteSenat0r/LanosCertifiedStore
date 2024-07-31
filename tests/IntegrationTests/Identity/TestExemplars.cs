using LanosCertifiedStore.Infrastructure.Authentication.KeyCloak;

namespace IntegrationTests.Identity;

internal static class TestExemplars
{
    private const string Email = "test@test.com";
    private const string Password = "123";

    internal static UserRepresentationWithPasswordAndId GetCorrectUserRepresentationWithPasswordAndId()
    {
        var attributes = new Dictionary<string, string>
        {
            { "phoneNumber", "+380123456789" }
        };

        return new UserRepresentationWithPasswordAndId(
            null,
            Email,
            Email,
            true,
            true,
            attributes,
            "test",
            "test",
            [new CredentialRepresentation("password", Password, false)]);
    }
}