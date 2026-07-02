namespace ApplicationUnitTests.HookValidation;

public static class HookValidationTextStatistics
{
    private static readonly char[] WordSeparators = { ' ', '\t', '\n', '\r' };

    public static int CountLines(string? text)
    {
        if (IsNullOrWhiteSpace(text))
            return 0;

        return SplitIntoLines(text).Length;
    }

    public static int CountWords(string? text)
    {
        if (IsNullOrWhiteSpace(text))
            return 0;

        return text.Split(WordSeparators, StringSplitOptions.RemoveEmptyEntries).Length;
    }

    public static int CountCharacters(string? text)
    {
        if (IsNullOrWhiteSpace(text))
            return 0;

        return text.Length;
    }

    public static int CountLinesContaining(string? text, string searchTerm)
    {
        if (IsNullOrWhiteSpace(text) || IsNullOrWhiteSpace(searchTerm))
            return 0;

        return SplitIntoLines(text).Count(line => line.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
    }

    public static bool ContainsSearchTerm(string? text, string searchTerm)
    {
        if (IsNullOrWhiteSpace(text) || IsNullOrWhiteSpace(searchTerm))
            return false;

        return text.Contains(searchTerm, StringComparison.OrdinalIgnoreCase);
    }

    private static bool IsNullOrWhiteSpace(string? text) => string.IsNullOrWhiteSpace(text);

    private static string[] SplitIntoLines(string text) =>
        text.Split('\n', StringSplitOptions.RemoveEmptyEntries);
}
