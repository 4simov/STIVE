
using Core.DTO.FamilleDTO;
using STIVE.Core.UseCase;

namespace Core.UseCase.Famille.Abstraction
{
    public interface IGetFamilleById: IUseCaseProcess<int, FamilleResponse>
    {
    }
}
