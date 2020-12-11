using SimpleBlog2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBlog2.Repositories
{
    public interface IArticleCommentRepository
    {
        ArticleCommentModel Get(int articleCommentId);
        IQueryable<ArticleCommentModel> GetAll();
        void Add(ArticleCommentModel articleComment);
        void Update(int articleCommentId, ArticleCommentModel articleComment);
        void Delete(int articleCommentId, ArticleCommentModel articleComment);
    }
}
