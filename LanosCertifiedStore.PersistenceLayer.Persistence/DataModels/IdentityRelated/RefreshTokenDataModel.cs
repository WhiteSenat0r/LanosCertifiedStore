using Domain.Contracts.Common;
using Persistence.DataModels.UserRelated;

namespace Persistence.DataModels.IdentityRelated;

internal sealed class RefreshTokenDataModel : IIdentifiable<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public UserDataModel User { get; set; } = default!;
    public string Value { get; set; } = default!;
    public DateTime ExpiryDate { get; set; } = DateTime.UtcNow.AddDays(14);
    public DateTime? RevocationDate { get; set; }
    public bool IsExpired => DateTime.UtcNow >= ExpiryDate;
    public bool IsValid => RevocationDate is null && !IsExpired;
}