namespace ApplicationUnitTests.HookValidation;

public static class HookValidationTextStatistics
{
    private static int? ValidateText(string? text)
    {
        if (text is null) return -1;
        if (string.IsNullOrWhiteSpace(text)) return 0;
        return null;
    }

    private static string[] GetLines(string text) => text.Split('\n');

    public static int CountLines(string? text)
    {
        if (ValidateText(text) is int earlyResult) return earlyResult;

        return GetLines(text!)
            .Count(line => !string.IsNullOrWhiteSpace(line));
    }

    public static int CountWords(string? text)
    {
        if (ValidateText(text) is int earlyResult) return earlyResult;

        return text!.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
            .Length;
    }

    public static int CountCharacters(string? text)
    {
        if (text is null) return -1;
        return text.Length;
    }

    public static int CountLinesContaining(string? text, string searchTerm)
    {
        if (ValidateText(text) is int earlyResult) return earlyResult;
        if (string.IsNullOrEmpty(searchTerm)) return 0;

        return GetLines(text!)
            .Count(line => line.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
    }
}
