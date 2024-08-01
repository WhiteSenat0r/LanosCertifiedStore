using Bogus;
using Bogus.DataSets;

namespace IntegrationTests.Common;

internal static class FakerExtensions
{
    internal static string UkrainianPhoneNumber(this PhoneNumbers phoneNumbers)
    {
        var localPhoneNumber = phoneNumbers.Random.ReplaceNumbers("#########");

        var formattedPhoneNumber = $"+380{localPhoneNumber}";

        return formattedPhoneNumber;
    }
}