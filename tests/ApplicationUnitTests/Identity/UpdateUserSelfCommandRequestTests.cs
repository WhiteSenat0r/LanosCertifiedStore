using LanosCertifiedStore.Application.Identity;
using LanosCertifiedStore.Application.Identity.Commands.UpdateUserSelfCommandRequestRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;

namespace ApplicationUnitTests.Identity;

public sealed class UpdateUserSelfCommandRequestTests
{
    private readonly IIdentityProviderService _identityProviderService = Substitute.For<IIdentityProviderService>();
    private readonly IUserContext _userContext = Substitute.For<IUserContext>();

    [Fact]
    public async Task Handle_Should_CallIdentityProviderService()
    {
        // Arrange
        var request = new UpdateUserSelfCommandRequest("Test", "AlsoTest", "+389016342967");
        var handler = new UpdateUserSelfCommandRequestHandler(_identityProviderService, _userContext);
        var userId = Guid.NewGuid();
        _userContext.UserId.Returns(userId);
        _identityProviderService.GetUserDataAsync(userId)
            .Returns(Result<UserDataDto>.Failure(Error.NotFound(userId)));

        // Act
        await handler.Handle(request, default);

        // Assert
        await _identityProviderService.Received(1)
            .GetUserDataAsync(userId);
    }

    [Fact]
    public async Task Handle_Should_ReturnFailureResult_IfGetUserDataAsyncReturnFailure()
    {
        // Arrange
        var request = new UpdateUserSelfCommandRequest("Test", "AlsoTest", "+389016342967");
        var handler = new UpdateUserSelfCommandRequestHandler(_identityProviderService, _userContext);
        var userId = Guid.NewGuid();
        _userContext.UserId.Returns(userId);
        _identityProviderService.GetUserDataAsync(userId)
            .Returns(Result<UserDataDto>.Failure(Error.NotFound(userId)));

        // Act
        var result = await handler.Handle(request, default);

        // Assert
        result.IsSuccess
            .Should().BeFalse();
        result.Error
            .Should().BeEquivalentTo(Error.NotFound(userId));
    }

    [Fact]
    public async Task Handle_Should_ReturnSuccessResult_IfUserExistsAndUpdateWasSuccessful()
    {
        // Arrange
        var request = new UpdateUserSelfCommandRequest("Test", "AlsoTest", "+389016342967");
        var handler = new UpdateUserSelfCommandRequestHandler(_identityProviderService, _userContext);
        var userId = Guid.NewGuid();
        _userContext.UserId.Returns(userId);
        _identityProviderService.GetUserDataAsync(userId)
            .Returns(Result<UserDataDto>.Success(GetUserDataDto()));
        _identityProviderService.UpdateUserDataAsync(Arg.Any<Guid>(), Arg.Any<string>(), Arg.Any<string>(),
                Arg.Any<string>(), Arg.Any<string>(), Arg.Any<CancellationToken>())
            .Returns(Result.Create(Error.None));

        // Act
        var result = await handler.Handle(request, default);

        // Assert
        result.IsSuccess
            .Should().BeTrue();
        result.Error
            .Should().Be(Error.None);
    }

    private static UserDataDto GetUserDataDto()
        => new(
            Guid.NewGuid().ToString(),
            "Test",
            "RealTest",
            "test@test.com",
            "+32815143986",
            true,
            [],
            3495754312);
}