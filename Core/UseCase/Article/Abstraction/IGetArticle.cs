using Core.DTO.Article;
using Core.DTO.Famille;
using STIVE.Core.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UseCase.Article.Abstraction
{
    public interface IGetArticle : IUseCaseProcess<List<ArticleResponse>>
    {
    }
}
