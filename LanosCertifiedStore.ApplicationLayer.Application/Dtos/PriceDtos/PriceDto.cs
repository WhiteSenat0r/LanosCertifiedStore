namespace Application.Dtos.PriceDtos;

public sealed class PriceDto
{
    public Guid Id { get; init; }
    public DateTime IssueDate { get; init; }
    public decimal Value { get; init; }
}