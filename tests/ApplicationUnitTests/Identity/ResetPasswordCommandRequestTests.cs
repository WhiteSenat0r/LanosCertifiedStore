using LanosCertifiedStore.Application.Identity;
using LanosCertifiedStore.Application.Identity.Commands.ResetPasswordCommandRequestRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;

namespace ApplicationUnitTests.Identity;

public sealed class ResetPasswordCommandRequestTests
{
    private readonly IIdentityProviderService _identityProviderService = Substitute.For<IIdentityProviderService>();
    private readonly IUserContext _userContext = Substitute.For<IUserContext>();
    private readonly Guid _userId = Guid.NewGuid();
    private readonly ResetPasswordCommandRequest _request = new();

    [Fact]
    public async Task Handle_Should_CallIdentityProviderService()
    {
        // Arrange
        _userContext.UserId
            .Returns(_userId);
        
        _identityProviderService
            .ResetUserPassword(_userId)
            .Returns(Result.Create(Error.None));

        var handler = new ResetPasswordCommandRequestHandler(_userContext, _identityProviderService);
        
        // Act
        await handler.Handle(_request, default);
        
        // Assert
        await _identityProviderService
            .Received(1)
            .ResetUserPassword(_userId);
    }

    [Fact]
    public async Task Handle_ShouldReturnSameResultAsIdentityProviderService()
    {
        // Arrange
        _userContext.UserId
            .Returns(_userId);
        
        _identityProviderService
            .ResetUserPassword(_userId)
            .Returns(Result.Create(Error.None));

        var handler = new ResetPasswordCommandRequestHandler(_userContext, _identityProviderService);
        
        // Act
        var result = await handler.Handle(_request, default);

        // Assert
        result.IsSuccess
            .Should().BeTrue();
        result.Error
            .Should().BeEquivalentTo(Error.None);
    }
}