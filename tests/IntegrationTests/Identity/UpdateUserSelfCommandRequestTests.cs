using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using IntegrationTests.Common;
using LanosCertifiedStore.Application.Identity.Commands.UpdateUserSelfCommandRequestRelated;
using LanosCertifiedStore.Application.Shared.ValidationRelated;
using LanosCertifiedStore.Domain.Entities.UserRelated;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace IntegrationTests.Identity;

public sealed class UpdateUserSelfCommandRequestTests(
    IntegrationTestsWebApplicationFactory factory) : IntegrationTestBase(factory)
{
    public static readonly TheoryData<string, string, string> InvalidRequests = new()
    {
        { "", Faker.Name.LastName(), Faker.Phone.UkrainianPhoneNumber() },
        { Faker.Name.FirstName(), "", Faker.Phone.UkrainianPhoneNumber() },
        { Faker.Name.FirstName(), Faker.Name.LastName(), "" },
        { Faker.Name.FirstName(), Faker.Name.LastName(), "12345" }
    };

    [Theory]
    [MemberData(nameof(InvalidRequests))]
    public async Task Send_Should_ReturnValidationError_IfEmailIsInvalid(
        string firstName,
        string lastName,
        string phoneNumber)
    {
        // Arrange
        var request = new UpdateUserSelfCommandRequest(firstName, lastName, phoneNumber);

        // Act
        var result = (IValidationResult)await Sender.Send(request);

        // Assert
        (result.Errors.Length != 0)
            .Should().BeTrue();
    }

    [Fact]
    public async Task Endpoint_Should_ReturnNoContent_IfRequestIsValidAndTokenPresent_AndModifyExistingUserInKeycloak()
    {
        // Arrange
        var user = await RegisterUserOnKeycloakAndAddToDb(
            Faker.Internet.Email(),
            Faker.Internet.Password(),
            Faker.Phone.UkrainianPhoneNumber(),
            UserRole.User);

        var token = await GetAccessTokenAsync(user.Email, user.Credentials.First().Value);

        var request = new UpdateUserSelfCommandRequest(
            Faker.Name.FirstName(),
            Faker.Name.LastName(),
            Faker.Phone.UkrainianPhoneNumber());

        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            JwtBearerDefaults.AuthenticationScheme,
            token);

        // Act
        var responseMessage = await HttpClient.PutAsJsonAsync("api/identity/updateSelf", request);
        var updatedUser = await KeycloakClient.GetUserDataAsync(user.Id);

        // Assert
        responseMessage.StatusCode
            .Should().Be(HttpStatusCode.NoContent);
        updatedUser.FirstName
            .Should().Be(request.FirstName);
        updatedUser.LastName
            .Should().Be(request.LastName);
        updatedUser.Attributes!.PhoneNumber.First()
            .Should().Be(request.PhoneNumber);
    }


    [Fact]
    public async Task Endpoint_Should_ReturnUnauthorized_IfTokenIsNotPresent()
    {
        // Act
        var responseMessage = await HttpClient.PutAsync("api/identity/updateSelf", null);

        // Assert
        responseMessage.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }
}