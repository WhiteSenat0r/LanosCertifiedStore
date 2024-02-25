namespace Application.Contracts.ServicesRelated.IdentityRelated;

public interface ITokenProvider<out TReturnedType, in TParameterType>
{
    TReturnedType Generate(TParameterType data);
}