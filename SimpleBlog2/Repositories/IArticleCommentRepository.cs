using SimpleBlog2.Models;
using SimpleBlog2.ViewModels;
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
        IQueryable<ArticleCommentModel> GetAllForArticle(int articleId);
        void Add(ArticleCommentModel articleComment);
        void Add(ArticleDetailsViewModel viewModel);
        void Update(int articleCommentId, ArticleCommentModel articleComment);
        void Delete(int articleCommentId, ArticleCommentModel articleComment);
        void DeleteByArticleId(int articleId);
    }
}
