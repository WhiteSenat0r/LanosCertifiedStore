namespace ApplicationUnitTests.HookValidation;

public static class HookValidationTextStatistics
{
    private static readonly char[] WordSeparators = { ' ', '\t', '\n', '\r' };

    public static int CalculateLineCount(string? text)
    {
        ArgumentNullException.ThrowIfNull(text);

        if (string.IsNullOrWhiteSpace(text))
            return 0;

        return GetNonEmptyLines(text).Length;
    }

    public static int CalculateWordCount(string? text)
    {
        ArgumentNullException.ThrowIfNull(text);

        if (string.IsNullOrWhiteSpace(text))
            return 0;

        return text.Split(WordSeparators, StringSplitOptions.RemoveEmptyEntries).Length;
    }

    public static int CalculateCharacterCount(string? text)
    {
        ArgumentNullException.ThrowIfNull(text);

        return text.Length;
    }

    public static int CountLinesContainingTerm(string? text, string? searchTerm)
    {
        ArgumentNullException.ThrowIfNull(text);
        ArgumentNullException.ThrowIfNull(searchTerm);

        if (string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(searchTerm))
            return 0;

        var lines = GetNonEmptyLines(text);
        return lines.Count(line => line.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
    }

    private static string[] GetNonEmptyLines(string text)
    {
        return text.Split('\n', StringSplitOptions.RemoveEmptyEntries);
    }
}
