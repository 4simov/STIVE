﻿using Core.DTO.ArticleDTO;
using STIVE.Core.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UseCase.Article
{
    public interface IUpdateArticle : IUseCaseProcess<ArticleUpdateRequest, ArticleResponse>
    {
    }
}
