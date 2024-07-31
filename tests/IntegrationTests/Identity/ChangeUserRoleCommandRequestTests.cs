using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using IntegrationTests.Common;
using LanosCertifiedStore.Application.Identity.Commands.ChangeUserRoleCommandRequestRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Domain.Entities.UserRelated;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTests.Identity;

public sealed class ChangeUserRoleCommandRequestTests(IntegrationTestsWebApplicationFactory factory)
    : IntegrationTestBase(factory)
{
    [Fact]
    public async Task Send_Should_ChangeUserRole_IfPassedRoleIsCorrect()
    {
        // Arrange
        var expectedRole = UserRole.Manager;
        var userRepresentation = await RegisterUserOnKeycloakAndAddToDb(
            Faker.Internet.Email(),
            Faker.Internet.Password(),
            Faker.Phone.UkrainianPhoneNumber(),
            UserRole.User);

        var request = new ChangeUserRoleCommandRequest(userRepresentation.Id, expectedRole.Name);

        // Act
        var result = await Sender.Send(request);
        var user = await Context
            .Set<User>()
            .Include(u => u.UserRole)
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == userRepresentation.Id);

        // Assert
        result.Error
            .Should().Be(Error.None);
        user!.UserRole!.Name
            .Should().Be(expectedRole.Name);
    }

    [Fact]
    public async Task Endpoint_Should_ReturnNoContent_IfSenderHasPermission_AndRequestIsValid()
    {
        // Arrange
        var adminUser = await RegisterUserOnKeycloakAndAddToDb(
            Faker.Internet.Email(),
            Faker.Internet.Password(),
            Faker.Phone.UkrainianPhoneNumber(),
            UserRole.Administrator);

        var userToUpdate = await RegisterUserOnKeycloakAndAddToDb(
            Faker.Internet.Email(),
            Faker.Internet.Password(),
            Faker.Phone.UkrainianPhoneNumber(),
            UserRole.User);
        
        var token = await GetAccessTokenAsync(adminUser.Email, adminUser.Credentials.First().Value);

        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            JwtBearerDefaults.AuthenticationScheme,
            token);

        // Act
        var response = await HttpClient.PutAsJsonAsync(
            $"api/identity/changeUserRole/{userToUpdate.Id}",
            UserRole.Manager.Name);

        // Assert
        response.StatusCode
            .Should().Be(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task Endpoint_Should_ReturnForbidden_IfSenderDoesNotHavePermission()
    {
        var user = await RegisterUserOnKeycloakAndAddToDb(
            Faker.Internet.Email(),
            Faker.Internet.Password(),
            Faker.Phone.UkrainianPhoneNumber(),
            UserRole.User);
        
        var token = await GetAccessTokenAsync(user.Email, user.Credentials.First().Value);
        
        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            JwtBearerDefaults.AuthenticationScheme,
            token);
        
        var response = await HttpClient.PutAsJsonAsync(
            $"api/identity/changeUserRole/{user.Id}",
            UserRole.Manager.Name);

        response.StatusCode
            .Should().Be(HttpStatusCode.Forbidden);
    }
}