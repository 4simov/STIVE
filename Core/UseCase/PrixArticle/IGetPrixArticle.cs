using Core.DTO.PrixArticleDTO;
using STIVE.Core.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UseCase.PrixArticle
{
    public interface IGetPrixArticle : IUseCaseProcess<int, PrixArticleResponse>
    {
    }
}
