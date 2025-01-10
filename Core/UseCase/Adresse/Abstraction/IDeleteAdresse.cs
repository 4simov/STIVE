using Core.DTO.Adresse;
using STIVE.Core.UseCase;

namespace Core.UseCase.Adresse.Abstraction
{
    public interface IDeleteAdresse : IUseCaseProcess<int, AdresseResponse>
    {
    }
}
