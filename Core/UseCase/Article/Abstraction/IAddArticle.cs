using Core.DTO.Article;
using STIVE.Core.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UseCase.Article.Abstraction
{
    public interface IAddArticle: IUseCaseProcess<ArticleAddRequest, ArticleResponse>
    {

    }
}
