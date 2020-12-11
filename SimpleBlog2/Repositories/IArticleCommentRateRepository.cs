using SimpleBlog2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBlog2.Repositories
{
    public interface IArticleCommentRateRepository
    {
        ArticleCommentRateModel Get(int articleCommentRateId);
        IQueryable<ArticleCommentRateModel> GetAll();
        void Add(ArticleCommentRateModel articleCommentRate);
        void Update(int articleCommentRateId, ArticleCommentRateModel articleCommentRate);
        void Delete(int articleCommentRateId);
    }
}
