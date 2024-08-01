using LanosCertifiedStore.Application.Identity;
using LanosCertifiedStore.Application.Identity.Dtos;
using LanosCertifiedStore.Application.Identity.Queries.GetUserDataQueryRequestRelated;
using LanosCertifiedStore.Application.Shared.ResultRelated;

namespace ApplicationUnitTests.Identity;

public sealed class GetUserDataQueryRequestTests
{
    private readonly IIdentityProviderService _identityProviderService = Substitute.For<IIdentityProviderService>();
    private readonly Guid _userId = Guid.NewGuid();
    private readonly GetUserDataQueryRequest _request;

    public GetUserDataQueryRequestTests()
    {
        _request = new GetUserDataQueryRequest(_userId);
    }

    [Fact]
    public async Task Handle_ShouldInvokeGetUserDataOfIdentityProviderService_AndReturnSameResult()
    {
        // Arrange
        var expectedResult = Result<UserDataDto>.Success(GetUserDataDto());
        _identityProviderService.GetUserDataAsync(_userId)
            .Returns(expectedResult);

        var handler = new GetUserDataQueryRequestHandler(_identityProviderService);

        // Act
        var result = await handler.Handle(_request, default);
        
        // Assert
        result.Should()
            .BeEquivalentTo(expectedResult);

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