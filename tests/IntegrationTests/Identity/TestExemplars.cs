using LanosCertifiedStore.Infrastructure.Authentication.KeyCloak;

namespace IntegrationTests.Identity;

internal static class TestExemplars
{
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