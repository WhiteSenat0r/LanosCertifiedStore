namespace Application.Dtos.ColorDtos;

public sealed record CreateColorDto
{
    public string ColorName { get; set; } = null!;
    public string HexValue { get; set; } = null!;
}