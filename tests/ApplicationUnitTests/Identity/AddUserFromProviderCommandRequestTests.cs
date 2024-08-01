using LanosCertifiedStore.Application.Identity.Commands.AddUserFromProviderCommandRequestRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.Users;
using LanosCertifiedStore.Domain.Entities.UserRelated;

namespace ApplicationUnitTests.Identity;

public sealed class AddUserFromProviderCommandRequestTests
{
    private readonly IUserService _userService = Substitute.For<IUserService>();

    [Fact]
    public async Task Handle_Should_CallUserServiceAddAsync_AndReturnUserId()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var request = new AddUserFromProviderCommandRequest(userId);
        var handler = new AddUserFromProviderCommandRequestHandler(_userService);

        // Act
        var result = await handler.Handle(request, default);

        // Assert
        result.Value
            .Should().Be(userId);
        result.Error
            .Should().Be(Error.None);
        await _userService
            .Received(1)
            .AddAsync(Arg.Any<User>());
    }
}