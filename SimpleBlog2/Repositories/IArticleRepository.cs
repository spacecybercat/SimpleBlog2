using SimpleBlog2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBlog2.Repositories
{
    public interface IArticleRepository
    {
        ArticleModel Get(int articleId);
        IQueryable<ArticleModel> GetAll();
        void Add(ArticleModel article);
        void Update(int articleId, ArticleModel article);
        void Delete(int articleId);
    }
}
