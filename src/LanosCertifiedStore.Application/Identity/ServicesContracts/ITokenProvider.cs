namespace Application.Identity.ServicesContracts;

public interface ITokenProvider<out TReturnedType, in TParameterType>
{
    TReturnedType Generate(TParameterType data);
}