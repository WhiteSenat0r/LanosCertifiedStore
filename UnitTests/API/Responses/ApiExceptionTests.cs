using API.Responses;

namespace UnitTests.API.Responses;

public class ApiExceptionTests
{
    [Fact]
    public void ApiException_InheritsFromApiResponse()
    {
        // Arrange
        var apiException = new ApiException(404);

        // Assert
        Assert.IsAssignableFrom<ApiResponse>(apiException);
    }

    [Fact]
    public void ApiException_DefaultConstructor_InitializesPropertiesCorrectly()
    {
        // Arrange
        var expectedStatusCode = 404;
        var expectedMessage = "Resource was not found";
        var expectedDetails = "Test details";

        // Act
        var apiException = new ApiException(expectedStatusCode)
        {
            Details = expectedDetails
        };

        // Assert
        Assert.Equal(expectedStatusCode, apiException.StatusCode);
        Assert.Equal(expectedMessage, apiException.Message);
        Assert.Equal(expectedDetails, apiException.Details);
    }

    [Fact]
    public void ApiException_Constructor_InitializesPropertiesCorrectly()
    {
        // Arrange
        var expectedStatusCode = 500;
        var expectedMessage = "Internal server error has occurred";
        var expectedDetails = "Additional details";

        // Act
        var apiException = new ApiException(expectedStatusCode, expectedMessage, expectedDetails);

        // Assert
        Assert.Equal(expectedStatusCode, apiException.StatusCode);
        Assert.Equal(expectedMessage, apiException.Message);
        Assert.Equal(expectedDetails, apiException.Details);
    }
}