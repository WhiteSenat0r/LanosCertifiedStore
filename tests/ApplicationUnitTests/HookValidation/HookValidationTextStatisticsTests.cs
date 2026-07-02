namespace ApplicationUnitTests.HookValidation;

public sealed class HookValidationTextStatisticsTests
{
    [Fact]
    public void CalculateLineCount_WithMultipleLines_ReturnsCorrectCount()
    {
        // Arrange
        var text = "Line 1\nLine 2\nLine 3";

        // Act
        var result = HookValidationTextStatistics.CalculateLineCount(text);

        // Assert
        result.Should().Be(3);
    }

    [Fact]
    public void CalculateLineCount_WithEmptyString_ReturnsZero()
    {
        // Arrange
        var text = "";

        // Act
        var result = HookValidationTextStatistics.CalculateLineCount(text);

        // Assert
        result.Should().Be(0);
    }

    [Fact]
    public void CalculateLineCount_WithWhitespaceOnly_ReturnsZero()
    {
        // Arrange
        var text = " \n\t\n ";

        // Act
        var result = HookValidationTextStatistics.CalculateLineCount(text);

        // Assert
        result.Should().Be(0);
    }

    [Fact]
    public void CalculateLineCount_WithNullInput_ThrowsArgumentNullException()
    {
        // Arrange
        string? text = null;

        // Act
        var act = () => HookValidationTextStatistics.CalculateLineCount(text);

        // Assert
        act.Should().Throw<ArgumentNullException>().WithParameterName("text");
    }

    [Fact]
    public void CalculateWordCount_WithMultipleWords_ReturnsCorrectCount()
    {
        // Arrange
        var text = "The quick brown fox jumps";

        // Act
        var result = HookValidationTextStatistics.CalculateWordCount(text);

        // Assert
        result.Should().Be(5);
    }

    [Fact]
    public void CalculateWordCount_WithVariousWhitespace_ReturnsCorrectCount()
    {
        // Arrange
        var text = "Word1\tWord2\nWord3\rWord4 Word5";

        // Act
        var result = HookValidationTextStatistics.CalculateWordCount(text);

        // Assert
        result.Should().Be(5);
    }

    [Fact]
    public void CalculateWordCount_WithEmptyString_ReturnsZero()
    {
        // Arrange
        var text = "";

        // Act
        var result = HookValidationTextStatistics.CalculateWordCount(text);

        // Assert
        result.Should().Be(0);
    }

    [Fact]
    public void CalculateWordCount_WithNullInput_ThrowsArgumentNullException()
    {
        // Arrange
        string? text = null;

        // Act
        var act = () => HookValidationTextStatistics.CalculateWordCount(text);

        // Assert
        act.Should().Throw<ArgumentNullException>().WithParameterName("text");
    }

    [Fact]
    public void CalculateCharacterCount_WithText_ReturnsCorrectCount()
    {
        // Arrange
        var text = "Hello";

        // Act
        var result = HookValidationTextStatistics.CalculateCharacterCount(text);

        // Assert
        result.Should().Be(5);
    }

    [Fact]
    public void CalculateCharacterCount_WithWhitespace_IncludesWhitespace()
    {
        // Arrange
        var text = "A B\tC\nD";

        // Act
        var result = HookValidationTextStatistics.CalculateCharacterCount(text);

        // Assert
        result.Should().Be(7);
    }

    [Fact]
    public void CalculateCharacterCount_WithEmptyString_ReturnsZero()
    {
        // Arrange
        var text = "";

        // Act
        var result = HookValidationTextStatistics.CalculateCharacterCount(text);

        // Assert
        result.Should().Be(0);
    }

    [Fact]
    public void CalculateCharacterCount_WithNullInput_ThrowsArgumentNullException()
    {
        // Arrange
        string? text = null;

        // Act
        var act = () => HookValidationTextStatistics.CalculateCharacterCount(text);

        // Assert
        act.Should().Throw<ArgumentNullException>().WithParameterName("text");
    }

    [Fact]
    public void CountLinesContainingTerm_WithMatchingTerm_ReturnsCorrectCount()
    {
        // Arrange
        var text = "Line with Lanos\nLine without\nAnother Lanos line\nLanos appears here too";
        var searchTerm = "Lanos";

        // Act
        var result = HookValidationTextStatistics.CountLinesContainingTerm(text, searchTerm);

        // Assert
        result.Should().Be(3);
    }

    [Fact]
    public void CountLinesContainingTerm_WithCaseInsensitiveMatch_ReturnsCorrectCount()
    {
        // Arrange
        var text = "LANOS in caps\nlanos in lowercase\nLaNos in mixed";
        var searchTerm = "lanos";

        // Act
        var result = HookValidationTextStatistics.CountLinesContainingTerm(text, searchTerm);

        // Assert
        result.Should().Be(3);
    }

    [Fact]
    public void CountLinesContainingTerm_WithNoMatches_ReturnsZero()
    {
        // Arrange
        var text = "Line 1\nLine 2\nLine 3";
        var searchTerm = "Lanos";

        // Act
        var result = HookValidationTextStatistics.CountLinesContainingTerm(text, searchTerm);

        // Assert
        result.Should().Be(0);
    }

    [Fact]
    public void CountLinesContainingTerm_WithEmptyText_ReturnsZero()
    {
        // Arrange
        var text = "";
        var searchTerm = "Lanos";

        // Act
        var result = HookValidationTextStatistics.CountLinesContainingTerm(text, searchTerm);

        // Assert
        result.Should().Be(0);
    }

    [Fact]
    public void CountLinesContainingTerm_WithNullText_ThrowsArgumentNullException()
    {
        // Arrange
        string? text = null;
        var searchTerm = "Lanos";

        // Act
        var act = () => HookValidationTextStatistics.CountLinesContainingTerm(text, searchTerm);

        // Assert
        act.Should().Throw<ArgumentNullException>().WithParameterName("text");
    }

    [Fact]
    public void CountLinesContainingTerm_WithNullSearchTerm_ThrowsArgumentNullException()
    {
        // Arrange
        var text = "Some text";
        string? searchTerm = null;

        // Act
        var act = () => HookValidationTextStatistics.CountLinesContainingTerm(text, searchTerm);

        // Assert
        act.Should().Throw<ArgumentNullException>().WithParameterName("searchTerm");
    }
}
