using Domain.Entities.VehicleRelated.Classes;

namespace Application.Contracts.ServicesRelated.IdentityRelated;

public interface IJwtProvider
{
    string Generate(User user);
}