using Domain.Contracts.Common;
using Domain.Models.UserRelated;

namespace Domain.Models.IdentityRelated;

public sealed class RefreshToken : IIdentifiable<Guid>
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public User User { get; init; } = default!;
    public string Value { get; init; } = default!;
    public DateTime ExpiryDate { get; init; } = DateTime.UtcNow.AddDays(14);
    public DateTime? RevocationDate { get; init; }
    public bool IsExpired { get; init; }
    public bool IsValid { get; init; }
    
    public RefreshToken()
    {
        IsValid = RevocationDate is null && !IsExpired;
        IsExpired = DateTime.UtcNow >= ExpiryDate;
    }
}