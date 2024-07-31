using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using IntegrationTests.Common;
using LanosCertifiedStore.Application.Identity.Commands.UpdateUserDataCommandRequestRelated;
using LanosCertifiedStore.Application.Shared.ValidationRelated;
using LanosCertifiedStore.Domain.Entities.UserRelated;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace IntegrationTests.Identity;

public sealed class UpdateUserCommandRequestTests(
    IntegrationTestsWebApplicationFactory factory) : IntegrationTestBase(factory)
{
    public static readonly TheoryData<Guid, string, string, string, string> InvalidRequests = new()
    {
        { Guid.NewGuid(), "", Faker.Internet.Email(), Faker.Name.FirstName(), Faker.Name.LastName() },
        { Guid.NewGuid(), Faker.Phone.UkrainianPhoneNumber(), "", Faker.Name.FirstName(), Faker.Name.LastName() },
        { Guid.NewGuid(), Faker.Phone.UkrainianPhoneNumber(), Faker.Internet.Email(), "", Faker.Name.LastName() },
        { Guid.NewGuid(), "", Faker.Internet.Email(), Faker.Name.FirstName(), "" },
    };

    [Theory]
    [MemberData(nameof(InvalidRequests))]
    public async Task Send_Should_ReturnValidationError_IfEmailIsInvalid(
        Guid id,
        string phoneNumber,
        string email,
        string firstName,
        string lastName)
    {
        // Arrange
        var request = new UpdateUserDataCommandRequest(id, phoneNumber, email, true, firstName, lastName);

        // Act
        var result = (IValidationResult)await Sender.Send(request);

        // Assert
        (result.Errors.Length != 0)
            .Should().BeTrue();
    }

    [Fact]
    public async Task Endpoint_Should_ReturnNoContent_IfSenderHasPermission_AndRequestIsValid()
    {
        // Arrange
        var user = await RegisterUserOnKeycloakAndAddToDb(
            Faker.Internet.Email(),
            Faker.Internet.Password(),
            Faker.Phone.UkrainianPhoneNumber(),
            UserRole.Administrator);

        var request = new UpdateUserDataCommandRequest(
            user.Id,
            Faker.Phone.UkrainianPhoneNumber(),
            Faker.Internet.Email(),
            true,
            Faker.Name.FirstName(),
            Faker.Name.LastName());

        var token = await GetAccessTokenAsync(user.Email, user.Credentials.First().Value);

        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            JwtBearerDefaults.AuthenticationScheme,
            token);

        // Act
        var response = await HttpClient.PutAsJsonAsync(
            $"api/identity/updateUserData",
            request);
        
        var updatedUser = await KeycloakClient.GetUserDataAsync(user.Id);

        // Assert
        response.StatusCode
            .Should().Be(HttpStatusCode.NoContent);
        updatedUser.FirstName
            .Should().Be(request.FirstName);
        updatedUser.LastName
            .Should().Be(request.LastName);
        updatedUser.Email
            .Should().Be(request.Email.ToLower());
        updatedUser.Attributes!.PhoneNumber.First()
            .Should().Be(request.PhoneNumber);
    }

    [Fact]
    public async Task Endpoint_Should_ReturnForbidden_IfSenderDoesNotHavePermission()
    {
        // Arrange
        var user = await RegisterUserOnKeycloakAndAddToDb(
            Faker.Internet.Email(),
            Faker.Internet.Password(),
            Faker.Phone.UkrainianPhoneNumber(),
            UserRole.User);

        var token = await GetAccessTokenAsync(user.Email, user.Credentials.First().Value);

        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            JwtBearerDefaults.AuthenticationScheme,
            token);

        // Act
        var response = await HttpClient.PutAsync(
            $"api/identity/updateUserData",
            null);

        response.StatusCode
            .Should().Be(HttpStatusCode.Forbidden);
    }
}