using API.Responses;

namespace UnitTests.API.Responses;

public class ApiResponseTests
{
    [Theory]
    [InlineData(400, "You have made a bad request")]
    [InlineData(401, "You are not authorised")]
    [InlineData(404, "Resource was not found")]
    [InlineData(500, "Internal server error has occurred")]
    [InlineData(200, null)] // No default message for status code 200
    public void DefaultMessageForStatusCode_ReturnsCorrectMessage(int statusCode, string expectedMessage)
    {
        // Arrange & Act
        var message = new ApiResponse(statusCode);

        // Assert
        Assert.Equal(expectedMessage, message.Message);
    }

    [Fact]
    public void ApiResponse_DefaultConstructor_InitializesPropertiesCorrectly()
    {
        // Arrange
        var expectedStatusCode = 404;
        var expectedMessage = "Resource was not found";

        // Act
        var apiResponse = new ApiResponse(expectedStatusCode);

        // Assert
        Assert.Equal(expectedStatusCode, apiResponse.StatusCode);
        Assert.Equal(expectedMessage, apiResponse.Message);
    }

    [Fact]
    public void ApiResponse_Constructor_InitializesPropertiesCorrectly()
    {
        // Arrange
        var expectedStatusCode = 401;
        var expectedMessage = "Custom message";

        // Act
        var apiResponse = new ApiResponse(expectedStatusCode)
        {
            StatusCode = expectedStatusCode,
            Message = expectedMessage
        };

        // Assert
        Assert.Equal(expectedStatusCode, apiResponse.StatusCode);
        Assert.Equal(expectedMessage, apiResponse.Message);
    }
}