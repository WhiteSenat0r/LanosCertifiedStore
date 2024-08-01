using LanosCertifiedStore.Application.Identity;
using LanosCertifiedStore.Application.Identity.Commands.UpdateUserDataCommandRequestRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;

namespace ApplicationUnitTests.Identity;

public sealed class UpdateUserDataCommandRequestTests
{
    private readonly IIdentityProviderService _identityProviderService = Substitute.For<IIdentityProviderService>();

    [Fact]
    public async Task Handle_Should_CallIdentityProviderServiceAndReturnSuccessfulResult_IfSuccess()
    {
        // Arrange
        var request = new UpdateUserDataCommandRequest(
            Guid.NewGuid(),
            "+38925620136",
            "test@test.com",
            true,
            "first",
            "last");

        var handler = new UpdateUserDataCommandRequestHandler(_identityProviderService);
        
        _identityProviderService.UpdateUserDataAsync(
                Arg.Any<Guid>(),
                Arg.Any<string>(),
                Arg.Any<string>(),
                Arg.Any<string>(),
                Arg.Any<string>(),
                Arg.Any<CancellationToken>(),
                Arg.Any<bool>(),
                Arg.Any<List<string>>())
            .Returns(Result.Create(Error.None));
        
        // Act
        var result = await handler.Handle(request, default);
        
        // Assert
        result.IsSuccess
            .Should().BeTrue();

        result.Error
            .Should().Be(Error.None);
    }
}