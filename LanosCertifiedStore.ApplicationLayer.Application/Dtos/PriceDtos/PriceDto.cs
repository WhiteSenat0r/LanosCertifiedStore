namespace Application.Dtos.PriceDtos;

public sealed class PriceDto
{
    public Guid Id { get; set; }
    public DateTime IssueDate { get; set; }
    public decimal Value { get; set; }
}