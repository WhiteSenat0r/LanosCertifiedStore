using LanosCertifiedStore.Application.Identity.Commands.ChangeUserRoleCommandRequestRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;
using LanosCertifiedStore.Application.Users;
using LanosCertifiedStore.Domain.Entities.UserRelated;
using NSubstitute.ExceptionExtensions;

namespace ApplicationUnitTests.Identity;

public sealed class ChangeUserRoleCommandRequestTests
{
    private readonly IUserService _userService = Substitute.For<IUserService>();

    [Fact]
    public async Task Handle_Should_ReturnFailureResult_IfWrongRoleName()
    {
        // Arrange
        var request = new ChangeUserRoleCommandRequest(Guid.NewGuid(), "rofl");

        var handler = new ChangeUserRoleCommandRequestHandler(_userService);

        // Act
        var result = await handler.Handle(request, default);

        // Arrange
        result.IsSuccess
            .Should().BeFalse();

        var errorMessage = $"Role with code {request.RoleCode} was not found or is inaccessible";
        result.Error
            .Should()
            .BeEquivalentTo(Error.NotFound(errorMessage));
    }

    [Fact]
    public async Task Handle_Should_ReturnFailureResult_IfUserDoesNotExist()
    {
        // Arrange
        var request = new ChangeUserRoleCommandRequest(Guid.NewGuid(), UserRole.User.Name);
        var handler = new ChangeUserRoleCommandRequestHandler(_userService);

        _userService.ChangeUserRole(request.UserId, UserRole.User)
            .ThrowsAsync(new KeyNotFoundException());

        // Act
        var result = await handler.Handle(request, default);

        // Arrange
        result.IsSuccess
            .Should().BeFalse();
        result.Error
            .Should().BeEquivalentTo(Error.NotFound(request.UserId));
    }

    [Fact]
    public async Task Handle_Should_ReturnSuccessfulResult_IfUserAndRoleNameExist()
    {
        // Arrange
        var request = new ChangeUserRoleCommandRequest(Guid.NewGuid(), UserRole.User.Name);
        var handler = new ChangeUserRoleCommandRequestHandler(_userService);

        // Act
        var result = await handler.Handle(request, default);

        // Assert
        result.IsSuccess
            .Should().BeTrue();

        result.Error
            .Should().Be(Error.None);
    }
}