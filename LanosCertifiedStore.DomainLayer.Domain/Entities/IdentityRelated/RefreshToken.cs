using Domain.Contracts.Common;
using Domain.Entities.UserRelated;

namespace Domain.Entities.IdentityRelated;

public sealed class RefreshToken : IIdentifiable<Guid>
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public User User { get; init; } = default!;
    public string Value { get; init; } = default!;
    public DateTime ExpiryDate { get; init; }
    public DateTime? RevocationDate { get; init; }
    public bool IsExpired { get; init; }
    public bool IsValid { get; init; }
}