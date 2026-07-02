namespace ApplicationUnitTests.HookValidation;

public sealed class HookValidationTextStatisticsTests
{
    private static readonly Lazy<string> _lazySampleText = new(() =>
    {
        var sampleFilePath = Path.Combine(
            AppContext.BaseDirectory,
            "..", "..", "..",
            "HookValidation",
            "hook-validation-sample.txt");

        return File.ReadAllText(sampleFilePath);
    });

    private string _sampleText => _lazySampleText.Value;

    [Fact]
    public void CountLines_Should_ReturnMinusOne_WhenInputIsNull()
    {
        // Act
        var result = HookValidationTextStatistics.CountLines(null);

        // Assert
        result.Should().Be(-1);
    }

    [Fact]
    public void CountWords_Should_ReturnMinusOne_WhenInputIsNull()
    {
        // Act
        var result = HookValidationTextStatistics.CountWords(null);

        // Assert
        result.Should().Be(-1);
    }

    [Fact]
    public void CountCharacters_Should_ReturnMinusOne_WhenInputIsNull()
    {
        // Act
        var result = HookValidationTextStatistics.CountCharacters(null);

        // Assert
        result.Should().Be(-1);
    }

    [Fact]
    public void CountLinesContaining_Should_ReturnMinusOne_WhenInputIsNull()
    {
        // Act
        var result = HookValidationTextStatistics.CountLinesContaining(null, "test");

        // Assert
        result.Should().Be(-1);
    }

    [Fact]
    public void CountLines_Should_ReturnZero_WhenInputIsEmpty()
    {
        // Act
        var result = HookValidationTextStatistics.CountLines("");

        // Assert
        result.Should().Be(0);
    }

    [Fact]
    public void CountWords_Should_ReturnZero_WhenInputIsEmpty()
    {
        // Act
        var result = HookValidationTextStatistics.CountWords(" \n\t ");

        // Assert
        result.Should().Be(0);
    }

    [Fact]
    public void CountCharacters_Should_ReturnZero_WhenInputIsEmptyString()
    {
        // Act
        var result = HookValidationTextStatistics.CountCharacters("");

        // Assert
        result.Should().Be(0);
    }

    [Fact]
    public void CountLinesContaining_Should_ReturnZero_WhenInputIsEmpty()
    {
        // Act
        var result = HookValidationTextStatistics.CountLinesContaining("", "test");

        // Assert
        result.Should().Be(0);
    }

    [Fact]
    public void CountLines_Should_ReturnEight_WhenInputIsSampleFile()
    {
        // Act
        var result = HookValidationTextStatistics.CountLines(_sampleText);

        // Assert
        result.Should().Be(8);
    }

    [Fact]
    public void CountWords_Should_ReturnFortyOrMore_WhenInputIsSampleFile()
    {
        // Act
        var result = HookValidationTextStatistics.CountWords(_sampleText);

        // Assert
        result.Should().BeGreaterOrEqualTo(40);
    }

    [Fact]
    public void CountCharacters_Should_ReturnPositiveValue_WhenInputIsSampleFile()
    {
        // Act
        var result = HookValidationTextStatistics.CountCharacters(_sampleText);

        // Assert
        result.Should().BeGreaterThan(200);
    }

    [Fact]
    public void CountLinesContaining_Should_ReturnFour_WhenSearchingForLanosInSampleFile()
    {
        // Act
        var result = HookValidationTextStatistics.CountLinesContaining(_sampleText, "Lanos");

        // Assert
        result.Should().Be(4);
    }

    [Fact]
    public void CountLinesContaining_Should_BeCaseInsensitive()
    {
        // Arrange
        var lowerCaseResult = HookValidationTextStatistics.CountLinesContaining(_sampleText, "lanos");
        var upperCaseResult = HookValidationTextStatistics.CountLinesContaining(_sampleText, "LANOS");

        // Assert
        lowerCaseResult.Should().Be(4);
        upperCaseResult.Should().Be(4);
    }
}
