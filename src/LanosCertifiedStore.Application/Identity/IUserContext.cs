namespace LanosCertifiedStore.Application.Identity;

public interface IUserContext
{
    bool IsAuthenticated { get; }
    Guid UserId { get; }
}