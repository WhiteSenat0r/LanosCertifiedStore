using IntegrationTests.Common;
using LanosCertifiedStore.Application.Identity.Commands.AddUserFromProviderCommandRequestRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Domain.Entities.UserRelated;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTests.Identity;

public sealed class AddUserFromProviderTests(
    IntegrationTestsWebApplicationFactory factory) : IntegrationTestBase(factory)
{
    [Fact]
    public async Task Send_Should_CreateNewUserAndAddToDatabase()
    {
        // Arrange
        var userId = Guid.NewGuid();

        // Act
        var result = await Sender.Send(new AddUserFromProviderCommandRequest(userId));
        var user = await Context
            .Set<User>()
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == userId);

        // Assert
        user.Should()
            .NotBeNull();
        result.Value
            .Should().Be(userId);
        result.Error
            .Should().Be(Error.None);
    }
}