using LanosCertifiedStore.Application.Identity;
using LanosCertifiedStore.Application.Identity.Commands.UserEmailUpdateCommandRequestRelated;
using LanosCertifiedStore.Application.Identity.Dtos;
using LanosCertifiedStore.Application.Shared.ResultRelated;

namespace ApplicationUnitTests.Identity;

public sealed class UserEmailUpdateCommandRequestTests
{
    private readonly IIdentityProviderService _identityProviderService = Substitute.For<IIdentityProviderService>();
    private readonly IUserContext _userContext = Substitute.For<IUserContext>();
    private const string NewEmail = "test@test.com";
    private readonly UserEmailUpdateCommandRequest _request = new(NewEmail);
    private readonly Guid _userId = Guid.NewGuid();

    [Fact]
    public async Task Handle_Should_CallIdentityProviderService()
    {
        // Arrange
        _userContext.UserId.Returns(_userId);
        
        _identityProviderService.GetUserDataAsync(_userId)
            .Returns(Result<UserDataDto>.Success(GetUserDataDto()));

        var handler = new UserEmailUpdateCommandRequestHandler(_identityProviderService, _userContext);

        // Act
        await handler.Handle(_request, default);

        // Assert
        await _identityProviderService.Received(1)
            .GetUserDataAsync(_userId);
        await _identityProviderService.Received(1)
            .UpdateUserEmailAsync(_userId, NewEmail);
    }

    [Fact]
    public async Task Handle_Should_ReturnSameEmailError_IfNewEmailIsNotDifferentFromCurrentOne()
    {
        // Arrange
        var userDataDto = GetUserDataDto() with
        {
            Email = NewEmail
        };

        _userContext.UserId.Returns(_userId);

        _identityProviderService.GetUserDataAsync(_userId)
            .Returns(Result<UserDataDto>.Success(userDataDto));

        var handler = new UserEmailUpdateCommandRequestHandler(_identityProviderService, _userContext);
        
        // Act
        var result = await handler.Handle(_request, default);
        
        // Assert
        result.IsSuccess
            .Should().BeFalse();
        result.Error
            .Should().Be(IdentityErrors.SameEmailError);
    }

    [Fact]
    public async Task Handle_Should_ReturnSuccessResult_IfEverythingIsValid()
    {
        // Arrange
        _userContext.UserId.Returns(_userId);
        
        _identityProviderService.GetUserDataAsync(_userId)
            .Returns(Result<UserDataDto>.Success(GetUserDataDto()));
        
        _identityProviderService.UpdateUserEmailAsync(_userId, NewEmail)
            .Returns(Result.Create(Error.None));
        
        var handler = new UserEmailUpdateCommandRequestHandler(_identityProviderService, _userContext);
        
        // Act
        var result = await handler.Handle(_request, default);
        
        // Assert
        result.IsSuccess
            .Should().BeTrue();
        result.Error
            .Should().Be(Error.None);
    }

    private UserDataDto GetUserDataDto()
    {
        return new UserDataDto(
            _userId.ToString(),
            "Test",
            "Test",
            "oldemail@test.com",
            null,
            true,
            [],
            default
        );
    }
}