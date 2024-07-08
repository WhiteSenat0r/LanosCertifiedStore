using Domain.Contracts.Common;
using Domain.Entities.UserRelated;

namespace Domain.Entities.IdentityRelated;

public sealed class RefreshToken : IIdentifiable<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public User User { get; set; } = default!;
    public string Value { get; set; } = default!;
    public DateTime ExpiryDate { get; set; } = DateTime.UtcNow.AddDays(14);
    public DateTime? RevocationDate { get; set; }
    public bool IsExpired => DateTime.UtcNow >= ExpiryDate;
    public bool IsValid => RevocationDate is null && !IsExpired;
}