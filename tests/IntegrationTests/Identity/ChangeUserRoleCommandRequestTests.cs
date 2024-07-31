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
        var userRepresentation = await RegisterUserOnKeycloakAndAddToDb(UserRole.User);
        var request = new ChangeUserRoleCommandRequest(userRepresentation.Id, expectedRole.Name);

        // Act
        var result = await Sender.Send(request);
        var user = await Context
            .Set<User>()
            .Include(u => u.UserRole)
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == userRepresentation.Id);

        // Arrange
        result.Error
            .Should().Be(Error.None);
        user!.UserRole!.Name
            .Should().Be(expectedRole.Name);
    }

    [Fact]
    public async Task Endpoint_Should_ReturnForbidden_IfDoesNotHavePermission()
    {
        // Arrange
        var adminUser = await RegisterUserOnKeycloakAndAddToDb(
            "admin@test.com",
            UserRole.Administrator);
        var userToUpdate = await RegisterUserOnKeycloakAndAddToDb(UserRole.User);

        var token = await GetAccessTokenAsync(userToUpdate.Email, userToUpdate.Credentials.First().Value);
        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            JwtBearerDefaults.AuthenticationScheme,
            token);
        
        // Act
        var response = await HttpClient.PutAsJsonAsync()
    }
}