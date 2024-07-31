using System.Net;
using IntegrationTests.Common;
using LanosCertifiedStore.Application.Identity.Queries.GetUserDataQueryRequestRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Infrastructure.Authentication.KeyCloak;

namespace IntegrationTests.Identity;

public sealed class GetUserDataQueryRequestTests(
    IntegrationTestsWebApplicationFactory factory) : IntegrationTestBase(factory)
{
    [Fact]
    public async Task Send_Should_ReturnFailureResult_IfUserDoesNotExist()
    {
        // Arrange
        var userId = Guid.NewGuid();

        // Act
        var result = await Sender.Send(new GetUserDataQueryRequest(userId));

        // Assert
        result.Error
            .Should().BeEquivalentTo(Error.NotFound(userId));
        result.IsSuccess
            .Should().BeFalse();
    }

    [Fact]
    public async Task Send_Should_ReturnSuccessResult_IfUserExists()
    {
        // Arrange
        var user = await RegisterNewUser();

        // Act
        var result = await Sender.Send(new GetUserDataQueryRequest((Guid)user.Id!));

        // Assert
        result.Error
            .Should().BeEquivalentTo(Error.None);
        result.Value
            .Should().NotBeNull();
        result.Value!.Email
            .Should().Be(user.Email);
    }

    [Fact]
    public async Task GetUserDataEndpoint_Should_ReturnUnauthorized_IfTokenIsNotPresent()
    {
        var id = Guid.NewGuid();
        var responseMessage = await HttpClient.GetAsync($"api/identity/getUserData/{id}");

        // Assert
        responseMessage.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
    }


    private async Task<UserRepresentationWithPasswordAndId> RegisterNewUser()
    {
        var user = TestExemplars.GetCorrectUserRepresentationWithPasswordAndId();

        var userId = Guid.Parse(await KeycloakClient.RegisterUserAsync(user));

        return user with
        {
            Id = userId
        };
    }
}