using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleBlog2.Models;
using SimpleBlog2.ViewModels;

namespace SimpleBlog2.Repositories
{
    public class ArticleCommentRepository : IArticleCommentRepository
    {
        private readonly SimpleBlog2Context _context;

        public ArticleCommentRepository(SimpleBlog2Context context)
        {
            _context = context;
        }

        public ArticleCommentModel Get(int articleCommentId)
            => _context.ArticleComments.SingleOrDefault(x => x.ArticleCommentId == articleCommentId);

        public IQueryable<ArticleCommentModel> GetAll()
            => _context.ArticleComments;

        public void Add(ArticleCommentModel articleComment)
        {
            articleComment.DateOfPublish = DateTime.Now;
            _context.ArticleComments.Add(articleComment);
            _context.SaveChanges();
        }

        public void Add(ArticleDetailsViewModel viewModel)
        {
            if(viewModel != null && viewModel.NewComment.ArticleId != 0)
            {
                var comment = viewModel.NewComment;
                comment.DateOfPublish = DateTime.Now;
                _context.ArticleComments.Add(comment);
                _context.SaveChanges();
            }
        }

        public IQueryable<ArticleCommentModel> GetAllForArticle(int articleId)
        {
            var result = _context.ArticleComments.Where(x => x.ArticleId == articleId);
            return result;
        }

        public void Update(int articleCommentId, ArticleCommentModel articleComment)
        {
            var result = _context.ArticleComments.SingleOrDefault(x => x.ArticleCommentId == articleCommentId);
            if(result != null)
            {
                result.Text = articleComment.Text;
                _context.SaveChanges();
            }
        }

        public void Delete(int articleCommentId, ArticleCommentModel articleComment)
        {
            var result = _context.ArticleComments.SingleOrDefault(x => x.ArticleCommentId == articleCommentId);
            if(result != null)
            {
                _context.ArticleComments.Remove(result);
                _context.SaveChanges();
            }
        }
    }
}
