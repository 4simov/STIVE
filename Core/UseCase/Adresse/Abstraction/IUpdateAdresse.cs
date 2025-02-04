using Core.DTO.AdresseDTO;
using STIVE.Core.UseCase;

namespace Core.UseCase.Adresse.Abstraction
{
    public interface IUpdateAdresse : IUseCaseProcess<AdresseUpdateRequest, AdresseResponse>
    {
    }
}
