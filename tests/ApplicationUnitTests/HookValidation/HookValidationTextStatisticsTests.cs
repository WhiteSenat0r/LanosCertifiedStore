namespace ApplicationUnitTests.HookValidation;

public sealed class HookValidationTextStatisticsTests
{
    [Theory]
    [InlineData(null, 0)]
    [InlineData("", 0)]
    [InlineData("Line one\nLine two\nLine three", 3)]
    public void CountLines_ReturnsExpectedCount(string? text, int expected)
    {
        // Act
        var result = HookValidationTextStatistics.CountLines(text);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(null, 0)]
    [InlineData("", 0)]
    [InlineData("The quick brown fox jumps", 5)]
    public void CountWords_ReturnsExpectedCount(string? text, int expected)
    {
        // Act
        var result = HookValidationTextStatistics.CountWords(text);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(null, 0)]
    [InlineData("", 0)]
    [InlineData("Hello", 5)]
    public void CountCharacters_ReturnsExpectedCount(string? text, int expected)
    {
        // Act
        var result = HookValidationTextStatistics.CountCharacters(text);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(null, "test", 0)]
    [InlineData("sample text", null, 0)]
    [InlineData("sample text", "", 0)]
    [InlineData("Lanos is great\nAnother line\nLANOS is awesome\nlanos again", "lanos", 3)]
    [InlineData("Line one\nLine two\nLine three", "notfound", 0)]
    public void CountLinesContaining_ReturnsExpectedCount(string? text, string? searchTerm, int expected)
    {
        // Act
        var result = HookValidationTextStatistics.CountLinesContaining(text, searchTerm);

        // Assert
        result.Should().Be(expected);
    }
}
